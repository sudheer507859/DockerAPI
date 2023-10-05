using CarvedRock.API.APIModels;
using CarvedRock.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct product;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IProduct product, ILogger<ProductsController> logger)
        {
            this.product = product;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(string categoryType = "all")
        {
            this.logger.LogInformation("Starting controller action to getproducts.");
            return this.product.GetProductsForCategory(categoryType);
        }
    }
}
