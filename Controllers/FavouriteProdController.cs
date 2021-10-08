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
        public void AddToFavourite(User user, Product product) // The email is unique
        {
            ProductDAO prodToFav = new ProductDAO();
            prodToFav.AddProductToFavourite(product.ProductURL, user.Email, product.ImageURL, product.Price);
        }

        
    }
}
