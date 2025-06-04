using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyApp.Models; // Assuming you have a Models namespace for your data models

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // define the route for the controller
    // This will map to /api/products
    public class ProductsController : ControllerBase
    {
        // In-memory product list for demo
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple" },
            new Product { Id = 2, Name = "Banana" },
            new Product { Id = 3, Name = "Cherry" }
        };

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var productNames = new List<string>();
            foreach (var product in products)
            {
                productNames.Add(product.Name);
            }
            return productNames;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product newProduct)
        {
            newProduct.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            products.Add(newProduct);
            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            product.Name = updatedProduct.Name;
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            products.Remove(product);
            return Ok($"Product with ID {id} deleted successfully.");
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");
            return product;
        }

    }
}