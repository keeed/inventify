using System.Collections.Generic;
using System.Net.Mime;
using Inventify.App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventify.App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>()
        {
                new Product()
                {
                    Id = 0,
                    Name = "Apple",
                    Description = "Red Apple"
                },
                new Product()
                {
                    Id = 1,
                    Name = "Orange",
                    Description = "Fresh Orange"
                }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return _products;
        }

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(long id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product != null)
            {
                return product;
            }

            return NotFound();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Product> AddProduct(Product product)
        {
            _products.Add(product);

            return product;
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> DeleteProduct(long id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            return product;
        }

        [HttpPut()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> PutProduct([FromQuery]long id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productFound = _products.Find(p => p.Id == id);

            if (productFound == null)
            {
                return NotFound();
            }

            _products.Remove(productFound);
            _products.Add(product);


            return NoContent();
        }
    }
}