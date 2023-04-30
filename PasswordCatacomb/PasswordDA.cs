using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

public static class PasswordDA
{
    private static string connectionString = "server=passwordcatacomb-v2.cj0eaa61ahln.us-east-2.rds.amazonaws.com;user=admin;database=sys;password=Bold0305%";

    public static void CreateRecord(PasswordInfo passwordInfo)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO PasswordData (User, PasswordName, Password, AESKey, AESIV) VALUES (@user, @password_name, @password, @aes_key, @aes_iv)", connection))
                {
                    command.Parameters.AddWithValue("@user", passwordInfo.User);
                    command.Parameters.AddWithValue("@password_name", passwordInfo.PasswordName);
                    command.Parameters.AddWithValue("@password", passwordInfo.EncryptedPassword);
                    command.Parameters.AddWithValue("@aes_key", passwordInfo.AESKey);
                    command.Parameters.AddWithValue("@aes_iv", passwordInfo.AESIV);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password created successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static PasswordInfo ReadRecord(string user, string passwordName)
    {
        PasswordInfo result = new PasswordInfo();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM PasswordData WHERE User=@user AND PasswordName=@password_name", connection))
            {
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password_name", passwordName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.User = reader.GetString("User");
                        result.PasswordName = reader.GetString("PasswordName");
                        result.EncryptedPassword = (byte[])reader.GetValue(reader.GetOrdinal("Password"));
                        result.AESKey = (byte[])reader.GetValue(reader.GetOrdinal("AESKey"));
                        result.AESIV = (byte[])reader.GetValue(reader.GetOrdinal("AESIV"));
                    }
                }
            }
        }
        return result;
    }

    public static void UpdateRecord(PasswordInfo passwordInfo)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE PasswordData SET Password=@password, AESKey=@aes_key, AESIV=@aes_iv WHERE User=@user AND PasswordName=@password_name", connection))
                {
                    command.Parameters.AddWithValue("@user", passwordInfo.User);
                    command.Parameters.AddWithValue("@password_name", passwordInfo.PasswordName);
                    command.Parameters.AddWithValue("@password", passwordInfo.EncryptedPassword);
                    command.Parameters.AddWithValue("@aes_key", passwordInfo.AESKey);
                    command.Parameters.AddWithValue("@aes_iv", passwordInfo.AESIV);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password updated successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    public static void DeleteRecord(string user, string passwordName)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM PasswordData WHERE User=@user AND PasswordName=@password_name", connection))
                {
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@password_name", passwordName);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Password deleted successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static List<string> GetPasswordNamesForUser(string user)
    {
        List<string> passwordNames = new List<string>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT PasswordName FROM PasswordData WHERE User=@user", connection))
                {
                    command.Parameters.AddWithValue("@user", user);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string passwordName = reader.GetString("PasswordName");
                            passwordNames.Add(passwordName);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return passwordNames;
    }
}

