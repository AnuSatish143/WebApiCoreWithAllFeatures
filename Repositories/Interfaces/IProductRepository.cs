using WebApiCoreWithAllFeatures.Models;
namespace WebApiCoreWithAllFeatures.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}
