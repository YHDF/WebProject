using System;

namespace WebApi.Entities
{
    public class User
    {
        // Properties
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Constructor
        public User() {}
        
        public User(string username, string email, string pswd)
        {
            Username = username;
            Email = email;
            Password = pswd;
        }
    }
}
