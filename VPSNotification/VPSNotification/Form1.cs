using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VPSNotification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                status.Visible = true;
                status.ForeColor = Color.Blue;
                status.Text = "Generating Reports...";

                //Main Working for Reports Generating...
                Report rpt = new Report();
                rpt.GenerateReports(Report.dtPortfoliosEmail, Report.dtPortfoliosDispatch);
                Email.Setup(Report.dtPortfoliosEmail);
                Email.InsertToEmailPool();

                if (Report.dtPortfoliosEmail.Rows.Count > 0 || Report.dtPortfoliosDispatch.Rows.Count > 0)
                {
                    status.ForeColor = Color.Green;
                    status.Text = "Notification Generated Successfully.";
                }
                else
                {
                    status.ForeColor = Color.Green;
                    status.Text = "No Portfolio Available.";
                }
            }
            catch (Exception ex)
            {
                status.ForeColor = Color.Red;
                status.Text = "Error occured: " + ex.Message;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                status.Visible = true;
                status.ForeColor = Color.Blue;
                status.Text = "Generating Reports...";

                //Main Working for Reports Generating...
                Report rpt = new Report();
                rpt.GenerateReports(Report.dtPortfoliosEmail, Report.dtPortfoliosDispatch);
                Email.Setup(Report.dtPortfoliosEmail);
                Email.InsertToEmailPool();

                if (Report.dtPortfoliosEmail.Rows.Count > 0 || Report.dtPortfoliosDispatch.Rows.Count > 0)
                {
                    status.ForeColor = Color.Green;
                    status.Text = "Notification Generated Successfully.";
                }
                else
                {
                    status.ForeColor = Color.Green;
                    status.Text = "No Portfolio Available.";
                }
                
            }
            catch (Exception ex)
            {
                status.ForeColor = Color.Red;
                status.Text = "Error occured: " + ex.Message;
            }
            finally
            {
                SqlConnection.ClearAllPools();
                Application.Exit();
            }
        }

        private void SendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                status2.ForeColor = Color.Blue;
                status2.Text = "Sending...";

                //Email.SendEmail(Report.dtPortfoliosEmail);

                if (Report.dtPortfoliosEmail.Rows.Count > 0)
                {
                    status2.ForeColor = Color.Green;
                    status2.Text = "Email Sent Successfully.";
                }
                else
                {
                    status2.ForeColor = Color.Green;
                    status2.Text = "No Email Available.";
                }                
            }
            catch (Exception ex)
            {
                status2.ForeColor = Color.Red;
                status2.Text = "Error occured: " + ex.Message;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }
    }
}
