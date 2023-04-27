using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public static class PasswordDA
{
    private static string connectionString = "server=passwordcatacomb-v2.cj0eaa61ahln.us-east-2.rds.amazonaws.com;user=admin;database=sys;password=Bold0305%";

    public static void CreateRecord(PasswordInfo passwordInfo)
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
                        //Console.WriteLine($"{retrievedUser} {retrievedPasswordName} {BitConverter.ToString(password)} {BitConverter.ToString(aesKey)} {BitConverter.ToString(aesIV)}");
                    }
                }
            }
        }
        return result;
    }

    public static void UpdateRecord(PasswordInfo passwordInfo)
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
    }

    public static void DeleteRecord(string user, string passwordName)
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
    }
}

