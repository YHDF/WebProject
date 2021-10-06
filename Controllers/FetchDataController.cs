using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFTechCommerce.Services;

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
        public IActionResult FetchData(string searchName)
        {
            using (var db = new TechCommerceContext())
            {
                var prods = db.Products.OrderBy(order => order.ProductId);

                List<string> strList = new List<string>();

                foreach (var item in prods)
                {
                    if(item.Name.Contains(searchName))
                    {
                        strList.Add(item.Name);
                    }
                }

                foreach(var s in strList)
                    Console.WriteLine(s);

                // Console.WriteLine(prods.Name);
            }
            return Ok();
        }
    }
}
