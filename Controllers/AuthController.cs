using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFTechCommerce.Services;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

//         private string GenerateToken()
//         {
//             var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
// var stringChars = new char[8];
// var random = new Random();

// for (int i = 0; i < stringChars.Length; i++)
// {
//     stringChars[i] = chars[random.Next(chars.Length)];
// }

// var finalString = new String(stringChars);
//         }

        [HttpPost]
        [Route("login")]
        public void Login(User user)
        {
            UserDAO usr = new UserDAO();
            User userInfo = usr.GetUser(user.Email);
            string userMail = userInfo.Email;
            string userPswd = userInfo.Password;
            Console.WriteLine(userMail);
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);
            Console.WriteLine(userPswd);
            if(userMail == user.Email && user.Password == userPswd) // Check mail & pswd
            {
                string token = "test token";
                usr.InsertToken(userMail, token);

            }
        }

        [HttpPost]
        [Route("login")]
        public User Login(User user)
        {
            UserDAO usr = new UserDAO();
            User userInfo = usr.GetUser(user.Email);
            string userMail = userInfo.Email;
            string userPswd = userInfo.Password;
            // Console.WriteLine(userMail);
            // Console.WriteLine(user.Email);
            // Console.WriteLine(user.Password);
            // Console.WriteLine(userPswd);
            
            string token = "";
            if(userMail == user.Email && user.Password == userPswd) // Check mail & pswd
            {
                token = "test token";
                usr.InsertToken(userMail, token);
            }

            return new User(userMail, token);
        }
        
    }
}