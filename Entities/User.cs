using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User
    {
        // Properties
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }

        // Constructor
        public User() {}

        public User(string email, string pswd)
        {
            Email = email;
            Password = pswd;
        }


        public User(string email, string pswd, string token)
        {
            Email = email;
            Password = pswd;
            Token = token;
        }
    }
}