using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductsService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductsService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(string? category, int offset, int pageSize)
        {
            try
            {
                var products = await _productService.GetProductsQueryAsync(category, offset, pageSize);

                if (products is null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving products");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // GET: api/products/count
        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> GetProductCount(string? category)
        {
            try
            {
                int productsCount = await _productService.GetProductsCountAsync(category);

                return Ok(productsCount);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving products count");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products count");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // GET: api/products/{id}/quick
        [HttpGet("{id}/quick")]
        [AllowAnonymous]
        public async Task<ActionResult<QuickProductDTO>> GetQuickViewProduct(int id)
        {
            try
            {
                QuickProductDTO? product = await _productService.GetQuickProductAsync(id);

                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving quick product");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving quick product");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductDetails(int id)
        {
            try
            {
                ProductDetailsDTO? product = await _productService.GetProductDetailsAsync(id);

                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving product details");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product details");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }

        // GET: api/products/user
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllUserProducts()
        {
            try
            {
                Guid userId = User.GetUserId();

                var products = await _productService.GetProductsUserAsync(userId);

                if (products is null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving user products");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user products");
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
