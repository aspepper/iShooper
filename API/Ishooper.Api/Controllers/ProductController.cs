using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ishooper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "product1", "product2" };
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public string Get(int id)
        {
            return $"product {id}";
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
