using System;
using System.Data.SQLite;

namespace WebApi.Models
{
    public class UserDTO
    {
        public string Username { get; set; }

        public string GetUser(string username) // Get user from UserTechCommerce.db
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string UserDbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}DataFixtures{System.IO.Path.DirectorySeparatorChar}UsersTechCommerce.db";
            SQLiteConnection conn = new SQLiteConnection($"data source = {UserDbPath}");
            conn.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT Id, UserName, Email FROM AspNetUsers WHERE UserName = '" + username + "'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // string userId = sqlite_datareader.GetString(0);
            // string userMail = sqlite_datareader.GetString(1);

            string userId = "";
            // string userMail = "";
            while (sqlite_datareader.Read())
            {
                userId = sqlite_datareader.GetString(0);
            }

            conn.Close();

            return userId;
        }
    }
}
