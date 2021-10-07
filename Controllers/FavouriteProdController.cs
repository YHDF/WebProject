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
    [Route("[controller]")]
    public class FavouriteProdController : ControllerBase
    {

        private readonly ILogger<FavouriteProdController> _logger;

        public FavouriteProdController(ILogger<FavouriteProdController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("addfav")]
        public void AddToFavourite(string prodLink, string username) // The username = email (The username is unique)
        {
            // Retrieve the user id from the UserTechCommerce.db
            UserDTO usr = new UserDTO();
            string usrID = usr.GetUser(username);

            //Add the fav product into the db
            ProductDTO prd = new ProductDTO();
            prd.AddProductToFavourite(prodLink, usrID, username);

        }

        
    }
}
