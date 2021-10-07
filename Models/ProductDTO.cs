using System;
using System.Data.SQLite;

namespace WebApi.Models
{
    public class ProductDTO
    {
        public void AddProductToFavourite(string prodLink, string userId, string userMail) // Add product link to TechCommerce.db
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            string DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}DataFixtures{System.IO.Path.DirectorySeparatorChar}TechCommerce.db";
            SQLiteConnection conn = new SQLiteConnection($"data source = {DbPath}");
            conn.Open();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText =
                "INSERT INTO Favourites (UserId, UserMail, ProductLink) VALUES ('"+userId+"','"+userMail+"','"+prodLink+"');";
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}