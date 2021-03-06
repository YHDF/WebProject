using System;
using System.Data.SQLite;
using WebApi.Entities;

namespace WebApi.Models
{
    public class UserDAO
    {
        public string Username { get; set; }

        public User GetUser(string username) // Get user from TechCommerce.db
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string UserDbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}DataFixtures{System.IO.Path.DirectorySeparatorChar}TechCommerce.db";
            SQLiteConnection conn = new SQLiteConnection($"data source = {UserDbPath}");
            conn.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT Email, Password, Token FROM Users WHERE Email = '" + username + "'";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // string userId = sqlite_datareader.GetString(0);
            // string userMail = sqlite_datareader.GetString(1);

            string userMail = "";
            string userPswd = "";
            string userTkn = "userTkn";
            while (sqlite_datareader.Read())
            {
                userMail = sqlite_datareader.GetString(1);
                userPswd = sqlite_datareader.GetString(2);
                //userTkn = sqlite_datareader.GetString(3);
            }
            User user = new User(userMail, userPswd, "userTkn");
            //string[] userInfo = new string[] {userId, userMail, userPswd};

            conn.Close();
            return user;
        }

        public void InsertToken(string email, string token)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}DataFixtures{System.IO.Path.DirectorySeparatorChar}TechCommerce.db";
            SQLiteConnection conn = new SQLiteConnection($"data source = {DbPath}");
            conn.Open();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText =
                "UPDATE Users SET Token = '" + token + "' WHERE Email = '" + email + "'";
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}