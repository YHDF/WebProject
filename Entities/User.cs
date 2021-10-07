using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User
    {
        // Properties
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
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
