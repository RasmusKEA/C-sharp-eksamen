using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChristiansØ_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductController : ControllerBase
    {
        private string[] test = new[] {"string1", "string2"};

        [HttpGet]
        public IEnumerable<string> GetProducts()
        {
            return test;
        }

        [HttpGet("{id}")]
        public string getID(int id)
        {
            return test[id];
        }

        [HttpPost]
        public IEnumerable<string> Post([FromBody]IEnumerable<string> value)
        {
            foreach (var s in value)
            {
                Console.WriteLine(s);
            }
            
            Console.WriteLine("First " + value.ToArray()[0]);

            return value;
        }
    }
}