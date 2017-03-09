using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace VPSNotification
{
    class Email
    {
        private struct UserInfo
        {
            public string ToEmail;
            public string EmailAttachment;
            public string PortfolioID;
            
            public UserInfo(string toemail, string EmailAttach, string PfID)
            {
                ToEmail = toemail;
                EmailAttachment = EmailAttach;
                PortfolioID = PfID;
            }
        };
        private static List<UserInfo> _UserInfo = new List<UserInfo>();
        //private static string[] ToEmail { get; set; }
        private static string FromEmail { get; set; }
        private static string Body { get; set; }
        private static string Subject { get; set; }
        //private static string[] EmailAttachment { get; set; }
        //private static string[] PortfolioID { get; set; }
        private string emailServer = ConfigurationManager.AppSettings["emailServer"];
        //private static string emailBodyFile = Directory.GetCurrentDirectory() + "/EBody.txt";
        private static string emailBodyFile = ConfigurationManager.AppSettings["htmlBody"];
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public static void Setup(DataTable dtPortfolio)
        {
            try
            {
                StreamReader sr = new StreamReader(emailBodyFile);
                Body = sr.ReadToEnd();
                FromEmail = "AL MEEZAN ACCOUNT STATEMENT<account.statement@almeezangroup.com>";
                Subject = "Al Meezan VPS Notification";
                for (int i = 0; i < dtPortfolio.Rows.Count; i++)
                {
                    UserInfo UI = new UserInfo(dtPortfolio.Rows[i]["Email"].ToString(), ServerDetails.outputPath_Email + dtPortfolio.Rows[i]["Portfolio_ID"].ToString() + ".pdf", dtPortfolio.Rows[i]["Portfolio_ID"].ToString());
                    _UserInfo.Add(UI);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsertToEmailPool()
        {
            try
            {
                for (int i = 0; i < _UserInfo.Count; i++)
                {
                    string query = "INSERT INTO [172.16.1.42].[ISMS].[dbo].EmailPool_VPS_Notifcation (toemail,fromemail,subject,body,attachment,entrydate,flag,PortfolioID)";
                    query += "VALUES (@ToEmail,@FromEmail,@Subject,@Body,@Attachment,@EntryDate,@Flag,@PortfolioID)";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandText = query;                            
                            cmd.Parameters.AddWithValue("@ToEmail", _UserInfo[i].ToEmail);
                            cmd.Parameters.AddWithValue("@FromEmail", FromEmail);
                            cmd.Parameters.AddWithValue("@Subject", Subject);
                            cmd.Parameters.AddWithValue("@Body", Body);
                            cmd.Parameters.AddWithValue("@Attachment", _UserInfo[i].EmailAttachment);
                            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"));
                            cmd.Parameters.AddWithValue("@Flag", "N");
                            cmd.Parameters.AddWithValue("@PortfolioID", _UserInfo[i].PortfolioID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception)
            {
                _UserInfo.Clear();
                throw;
            }
        }

        public static void SendEmail()
        {
            try
            {
                string query = "Select * from [172.16.1.42].[ISMS].[dbo].EmailPool_VPS_Notifcation where flag = 'N'";
                string queryUpdate = string.Empty;
                DataTable dtVPS_Notification = SQLOperations.GetTable(query);
                SmtpClient smpt = new SmtpClient("192.168.1.1");
                foreach (DataRow item in dtVPS_Notification.Rows)
                {
                    try
                    {
                        MailMessage msg = new MailMessage(FromEmail,item["toemail"].ToString());
                        Attachment _attachment = new Attachment(item["attachment"].ToString());
                        msg.Subject = item["subject"].ToString();
                        msg.Body = item["body"].ToString();
                        msg.IsBodyHtml = true;
                        msg.Attachments.Add(_attachment);
                        //smpt.Send(msg);

                        queryUpdate = "update [172.16.1.42].[ISMS].[dbo].EmailPool_VPS_Notifcation set sentdate = '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:s") + "', flag = 'Y' ,message = 'Successfully Sent' where toemail = '" + item["toemail"].ToString() + "' and flag = 'N' ";
                        SQLOperations.ExecuteQuery(queryUpdate);
                    }
                    catch (Exception ex)
                    {
                        queryUpdate = "update [172.16.1.42].[ISMS].[dbo].EmailPool_VPS_Notifcation set sentdate = '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:s") + "' ,message = '" + ex.Message + "' where toemail = '" + item["toemail"].ToString() + "' and flag = 'N' ";
                        SQLOperations.ExecuteQuery(queryUpdate);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
