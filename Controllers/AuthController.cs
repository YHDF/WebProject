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
        
    }
}