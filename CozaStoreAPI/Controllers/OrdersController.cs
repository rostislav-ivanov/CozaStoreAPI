using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetOrders()
        {
            Guid userId = User.GetUserId();

            var orders = await _ordersService.GetOrdersAsync(userId);

            return Ok(orders);
        }

        // POST api/orders
        [HttpPost]
        public async Task<ActionResult<string>> CreateOrder([FromBody] OrderDTO order)
        {
            Guid userId = User.GetUserId();

            try
            {
                string orderNumber = await _ordersService.CreateOrderAsync(order, userId);

                return Ok(orderNumber);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
