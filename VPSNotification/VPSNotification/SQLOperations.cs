using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace VPSNotification
{
    class SQLOperations
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        static SqlConnection conn;
        public SQLOperations()
        {
            // TODO: Add constructor logic here
        }        


        public static DataTable GetTable(string query)
        {            
            conn = new SqlConnection(connectionString);
            try
            {
                DataTable dt = new DataTable();

                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(query, conn);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static void ExecuteQuery(string query)
        {            
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 50000000;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();                

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }        
    }
}
