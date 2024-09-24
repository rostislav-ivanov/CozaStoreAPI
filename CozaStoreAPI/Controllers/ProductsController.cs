using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(
            [FromQuery] string? category,
            [FromQuery] int offset,
            [FromQuery] int pageSize)
        {
            var products = await _productService.GetProductsQueryAsync(category, offset, pageSize);

            if (products is null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET: api/products/count
        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> GetProductCount([FromQuery] string? category)
        {

            int productsCount = await _productService.GetProductsCountAsync(category);

            return Ok(productsCount);
        }

        // GET: api/products/{id}/quick
        [HttpGet("{id}/quick")]
        [AllowAnonymous]
        public async Task<ActionResult<QuickProductDTO>> GetQuickViewProduct(int id)
        {
            QuickProductDTO? product = await _productService.GetQuickProductAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductDetails(int id)
        {
            ProductDetailsDTO? product = await _productService.GetProductDetailsAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/products/user
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllUserProducts()
        {
            Guid userId = User.GetUserId();

            var products = await _productService.GetProductsUserAsync(userId);

            if (products is null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
