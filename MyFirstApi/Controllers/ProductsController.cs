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
        public ActionResult<List<string>> Get() {
            return new List<string>{"Apple", "Banana", "Cherry"};
        }
    }
}