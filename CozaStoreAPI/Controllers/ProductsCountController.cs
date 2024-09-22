using CozaStoreAPI.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCountController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsCountController(IProductsService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsCountController>
        [HttpGet]
        [AllowAnonymous]
        public int Get([FromQuery] string? category)
        {

            int productsCount = _productService.GetProductsCountAsync(category).Result;

            return productsCount;
        }
    }
}
