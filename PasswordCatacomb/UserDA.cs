using System;
using MySql.Data.MySqlClient;
using PasswordCatacomb;

public static class UserDA
{
    private static string connectionString = "server=passwordcatacomb-v2.cj0eaa61ahln.us-east-2.rds.amazonaws.com;user=admin;database=sys;password=Bold0305%";

    public static void CreateRecord(UserInfo userInfo)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("INSERT INTO Users (User, Password, Salt, AESKey, AESIV) VALUES (@user, @password, @salt, @aes_key, @aes_iv)", connection))
            {
                command.Parameters.AddWithValue("@user", userInfo.Username);
                command.Parameters.AddWithValue("@password", userInfo.EncryptedPassword);
                command.Parameters.AddWithValue("@salt", userInfo.Salt);
                command.Parameters.AddWithValue("@aes_key", userInfo.AESKey);
                command.Parameters.AddWithValue("@aes_iv", userInfo.AESIV);
                command.ExecuteNonQuery();
            }
        }
    }

    public static UserInfo ReadRecord(string user)
    {
        UserInfo userInfo = new UserInfo();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE User=@user", connection))
            {
                command.Parameters.AddWithValue("@user", user);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userInfo.Username = reader.GetString("User");
                        userInfo.EncryptedPassword = (byte[])reader.GetValue(reader.GetOrdinal("Password"));
                        userInfo.Salt = (byte[])reader.GetValue(reader.GetOrdinal("Salt"));
                        userInfo.AESKey = (byte[])reader.GetValue(reader.GetOrdinal("AESKey"));
                        userInfo.AESIV = (byte[])reader.GetValue(reader.GetOrdinal("AESIV"));
                    }
                }
            }
        }
        return userInfo;
    }
}
