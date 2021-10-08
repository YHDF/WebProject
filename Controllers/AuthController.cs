using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using EFTechCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private static string GenerateToken()
        {
            var chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[64];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        [HttpPost]
        [Route("login")]
        public User Login(User user)
        {
            UserDAO usr = new UserDAO();
            User userInfo = usr.GetUser(user.Email);
            string userMail = userInfo.Email;
            string userPswd = userInfo.Password;

            Console.WriteLine(userMail);
            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);
            Console.WriteLine(userPswd);
            string token = "";
            if (
                userMail == user.Email && user.Password == userPswd) // Check mail & pswd
            {

                token = "GeneratedToken";
                usr.InsertToken (userMail, token);
            }
            User returneduser = new User(userMail, "", token);
            return returneduser;
        }

        /*[HttpPost]
        [Route("logout")]
        public User Logout(User user)
        {
            UserDAO usr = new UserDAO();
            usr.InsertToken(user.Email, ""); // Destroy the token
        }*/

        [HttpGet]
        [Route("gettoken")]
        public User GetToken(string email)
        {

            UserDAO usr = new UserDAO();
            User userInfo = usr.GetUser(email);

            Console.WriteLine("this is : " + userInfo.Token);
            return userInfo;
        }
    }
}
