using CarvedRock.API.APIModels;
using CarvedRock.API.Interfaces;

namespace CarvedRock.API.Domain
{
    public class ProductLogic : IProduct
    {
        private readonly ILogger<ProductLogic> logger;

        private readonly List<string> ProductCategory = new List<string> { "all", "Phones", "HomeAppliances" };

        public ProductLogic(ILogger<ProductLogic> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<Product> GetProductsForCategory(string categoryName)
        {
            this.logger.LogInformation("Starting logic to get products by category.");

            if (!ProductCategory.Any(p => p.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Enumerable.Empty<Product>();
            }

            return GetProducts().Where(p =>
            string.Equals(p.Category, "all", StringComparison.OrdinalIgnoreCase)
                || string.Equals(p.Category, categoryName, StringComparison.OrdinalIgnoreCase));
        }


        private static IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProdcuID = 1,
                    Name = "Iphone 15",
                    Description="New version, lunch was 2023",
                    Price =1500,
                    Category = "Phones"
                },
                new Product
                {
                    ProdcuID = 2,
                    Name = "Iphone 14",
                    Description="One year old version, lunch was 2022",
                    Price =1200,
                    Category = "Phones"
                },
                new Product
                {
                    ProdcuID = 3,
                    Name = "Mixer",
                    Description="New version, lunch was 2023",
                    Price =500,
                    Category = "HomeAppliances"
                },
                new Product
                {
                    ProdcuID = 1,
                    Name = "InstaPot",
                    Description="New version, lunch was 2023",
                    Price =400,
                    Category = "HomeAppliances"
                }
            };
        }
    }
}
