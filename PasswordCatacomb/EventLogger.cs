using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCatacomb
{
    public static class EventLogger
    {
        private static string connectionString = "server=passwordcatacomb-v2.cj0eaa61ahln.us-east-2.rds.amazonaws.com;user=admin;database=sys;password=Bold0305%";

        public static void AddLog(string eventType, string userName)
        {
            string message = string.Format("[{0}] User: {1} Event: {2}.", DateTime.Now, userName, eventType);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO EventLogs (message) VALUES (@message)", connection))
                    {
                        command.Parameters.AddWithValue("@message", message);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AddLog(string eventType, string userName, string passwordName)
        {
            string message = string.Format("[{0}] User: {1} Event: {2} PasswordName: {3}.", DateTime.Now, userName, eventType, passwordName);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO EventLogs (message) VALUES (@message)", connection))
                    {
                        command.Parameters.AddWithValue("@message", message);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
