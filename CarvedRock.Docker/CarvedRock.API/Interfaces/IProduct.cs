using CarvedRock.API.APIModels;

namespace CarvedRock.API.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetProductsForCategory(string categoryName);
    }
}
