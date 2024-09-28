using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozaStoreAPI.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IOrdersService _ordersService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrdersService ordersService, ILogger<OrdersController> logger)
        {
            _ordersService = ordersService;
            _logger = logger;
        }

        // GET api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetOrders()
        {
            Guid userId = User.GetUserId();

            try
            {
                var orders = await _ordersService.GetOrdersAsync(userId);
                return Ok(orders);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when retrieving orders for user {UserId}", userId);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for user {UserId}", userId);
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
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
                _logger.LogWarning(ex, "Invalid argument when creating order for user {UserId}", userId);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order for user {UserId}", userId);
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }
}
