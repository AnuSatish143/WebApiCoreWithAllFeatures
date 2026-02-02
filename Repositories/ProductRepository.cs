using Microsoft.AspNetCore.Mvc;
using WebApiCoreWithAllFeatures.Data;
using WebApiCoreWithAllFeatures.Models;
using WebApiCoreWithAllFeatures.Repositories.Interfaces;
namespace WebApiCoreWithAllFeatures.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
           return _context.products.ToList();
        }
    }
}
