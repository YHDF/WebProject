using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFTechCommerce.Services;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FetchDataController : ControllerBase
    {

        private readonly ILogger<FetchDataController> _logger;

        public FetchDataController(ILogger<FetchDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Product> FetchData(string searchName)
        {
            List<Product> productList = new List<Product>();

            using (var db = new TechCommerceContext())
            {
                var prods = db.Products.OrderBy(order => order.ProductId);


                foreach (var item in prods)
                {
                    if(item.Name.ToLower().Contains(searchName.ToLower()))
                    {
                        productList.Add(item);
                    }
                }

                foreach(var s in productList)
                    Console.WriteLine(s.Name);

                // Console.WriteLine(prods.Name);
            }
            return productList;
        }
    }
}
