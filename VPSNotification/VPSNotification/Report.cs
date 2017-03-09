using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer;
using System.Data;
using System.Collections;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions;
using CrystalDecisions.Shared;
using System.Windows.Forms;

namespace VPSNotification
{
    class Report
    {
        //public static ArrayList portfolios;
        public static DataTable dtPortfoliosEmail;
        public static DataTable dtPortfoliosDispatch;
        string FilePath;
        ReportDocument report;

        public Report()
        {
            ServerDetails.Set();
            SetPortfolios();
        }

        private void SetPortfolios()
        {
            try
            {
                string queryEmail = "Select * from Customer";
                //queryEmail = queryEmail + " where Portfolio_ID='137683-905'";
                queryEmail += " where SUBSTRING(Portfolio_ID,8,3) >= '900' AND EMAIL LIKE '%@%' AND DATEDIFF(day,GETDATE(),Ret_Date) =30 ";
                string queryDispatch = "Select Portfolio_ID, ret_Date, Email from Customer ";
                queryDispatch += " where SUBSTRING(Portfolio_ID,8,3) >= '900' AND EMAIL NOT LIKE '%@%' AND DATEDIFF(day,GETDATE(),Ret_Date) =30";
                dtPortfoliosEmail = SQLOperations.GetTable(queryEmail);
                dtPortfoliosDispatch = SQLOperations.GetTable(queryDispatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerateReports(DataTable pfid_email, DataTable pfid_dispatch)
        {
            MakeReport(pfid_email, ServerDetails.outputPath_Email);
            MakeReport(pfid_dispatch, ServerDetails.outputPath_Dispatch);
        }

        private void MakeReport(DataTable pfid, string outputPath)
        {
            try
            {
                foreach (DataRow PortfolioID in pfid.Rows)
                {
                    report = new ReportDocument();
                    report.Load(ServerDetails.reportPath);
                    report.DataSourceConnections[0].SetConnection(ServerDetails.servername, ServerDetails.database, ServerDetails.username, ServerDetails.password);
                    report.RecordSelectionFormula = "({Customer.Portfolio_ID} ='" + PortfolioID["Portfolio_ID"].ToString() + "')";
                    report.SetParameterValue("pf_id", PortfolioID["Portfolio_ID"].ToString());
                    string retDate = Convert.ToDateTime(PortfolioID["ret_Date"].ToString()).ToString("dd/MMM/yyyy");
                    report.SetParameterValue("ret_Date", retDate);
                    FilePath = outputPath + PortfolioID["Portfolio_ID"].ToString() + ".pdf";
                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }
                    report.ExportToDisk(ExportFormatType.PortableDocFormat, FilePath);
                    report.Close();
                    report.Dispose();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (report != null)
                {
                    report.Close();
                    report.Dispose();
                }
            }
        }
    }
}
