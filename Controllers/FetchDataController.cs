using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFTechCommerce;

namespace WebProject.Controllers
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

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        [HttpGet]
        public IActionResult FetchData(string searchName)
        {
            using (var db = new TechCommerceContext())
            {
                var prods = db.Products.OrderBy(order => order.ProductDTOId);

                List<string> strList = new List<string>();

                foreach (var item in prods)
                {
                    if(item.Name.Contains(searchName))
                    {
                        strList.Add(item.Name);
                    }
                }
                
                // Console.WriteLine(prods.Name);
            }
            return Ok();
        }
    }
}
