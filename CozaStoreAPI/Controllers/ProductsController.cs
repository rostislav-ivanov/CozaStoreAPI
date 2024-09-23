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

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(
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

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        [Route("Count")]
        public async Task<ActionResult<int>> Get([FromQuery] string? category)
        {

            int productsCount = await _productService.GetProductsCountAsync(category);

            return Ok(productsCount);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            Guid userId = User.GetUserId();

            var products = await _productService.GetProductsUserAsync(userId);

            if (products is null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
