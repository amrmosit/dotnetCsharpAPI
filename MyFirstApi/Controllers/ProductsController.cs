using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // define the route for the controller
    // This will map to /api/products
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return new List<string> { "Apple", "Banana", "Cherry" };
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] string newProduct)
        {
            // In a real application, you would save the new product to a database
            return $"Product '{newProduct}' created successfully!";
        }
        [HttpPut("{id}")]
        // This method updates a product by its ID
        public ActionResult<string> Put(int id, [FromBody] string updatedProduct)
        {
            // In a real application, you would update the product in the database
            return $"Product with ID {id} updated to '{updatedProduct}' successfully!";
        }
        [HttpDelete("{id}")]
        // This method deletes a product by its ID
        public ActionResult<string> Delete(int id)
        {
            // In a real application, you would delete the product from the database
            return $"Product with ID {id} deleted successfully!";
        }

    }
}