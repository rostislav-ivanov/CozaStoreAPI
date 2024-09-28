using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CozaStoreAPI.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrdersService> _logger;

        public OrdersService(ApplicationDbContext context, ILogger<OrdersService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> CreateOrderAsync(OrderDTO orderDTO, Guid userId)
        {
            try
            {
                var order = new Order
                {
                    AppUserId = userId,
                    OrderNumber = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                    CreatedOn = DateTime.UtcNow,
                    StatusOrderId = 1,
                    IsPaid = false,
                    ShippingPrice = orderDTO.ShippingPrice,
                    TotalPrice = orderDTO.Total,
                    FirstName = orderDTO.FirstName,
                    LastName = orderDTO.LastName,
                    PhoneNumber = orderDTO.Phone,
                    ShippingProvider = "EKONT",
                    ShippingCity = orderDTO.City,
                    ShippingOffice = orderDTO.Office
                };

                foreach (ProductBagDTO product in orderDTO.Products)
                {
                    var productExists = await _context.Products.AnyAsync(p => p.Id == product.Id);
                    if (!productExists)
                    {
                        _logger.LogWarning("Product with id {ProductId} does not exist", product.Id);
                        throw new ArgumentException("Product does not exist");
                    }

                    var productOrder = new ProductOrder
                    {
                        ProductId = product.Id,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        ImagePath = product.Image,
                        Size = product.Size,
                        Color = product.Color,
                        Order = order
                    };

                    order.ProductsOrders.Add(productOrder);
                }

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                return order.OrderNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<OrderGetDTO>> GetOrdersAsync(Guid userId)
        {
            try
            {
                var orders = await _context.Orders
                    .AsNoTracking()
                    .Where(o => o.AppUserId == userId)
                    .Select(o => new OrderGetDTO
                    {
                        OrderNumber = o.OrderNumber,
                        CreatedOn = o.CreatedOn.ToString("dd/MM/yyyy"),
                        OrderStatus = o.StatusOrder.Name,
                        TotalPrice = o.TotalPrice,
                        ShippingPrice = o.ShippingPrice,
                        Products = o.ProductsOrders.Select(po => new OrderGetDTO.Product
                        {
                            Id = po.ProductId,
                            Name = po.Product.Name,
                            ImagePath = po.ImagePath,
                            Quantity = po.Quantity,
                            Price = po.Price,
                            Size = po.Size,
                            Color = po.Color
                        }).ToList()
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for user {UserId}", userId);
                throw;
            }
        }
    }
}
