using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApiCoreWithAllFeatures.Models;
using WebApiCoreWithAllFeatures.Repositories.Interfaces;

namespace WebApiCoreWithAllFeatures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 120)] // Enable response caching for 60 seconds
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMemoryCache _cache;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger, IMemoryCache cache)
        {
            _productRepository = productRepository;
            _logger = logger;
            _cache = cache;
        }
        //[Authorize]
        [Authorize(Roles = "Dev")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            if (!_cache.TryGetValue("products", out IEnumerable<Product> products))
            {
                _logger.LogInformation("Fetching from DB");
                products = _productRepository.GetAllProducts();
                _cache.Set("products", products, TimeSpan.FromMinutes(5));
            }

            return Ok(products);
        }
        [HttpGet("test-exception")]
        [Authorize(Roles ="Tester")]
        public IActionResult TestException()
        {
            throw new Exception("This is a test exception for logging purposes.");

        }
        [HttpGet("test-exception1")]
        [Authorize]
        public IActionResult TestExceptions()
        {
            throw new Exception("This is a test exception for logging purposes.");

        }
    }
}
