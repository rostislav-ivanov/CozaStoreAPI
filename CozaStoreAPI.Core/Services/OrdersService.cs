using CozaStoreAPI.Core.Contracts;
using CozaStoreAPI.Core.ModelsDTO;
using CozaStoreAPI.Infrastructure.Data;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;

        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateOrderAsync(OrderDTO orderDTO, Guid userId)
        {
            Order order = new Order
            {
                AppUserId = userId,
                OrderNumber = (DateTimeOffset.UtcNow).ToUnixTimeMilliseconds().ToString(),
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                IsPaid = false,
                ShippingPrice = orderDTO.ShippingPrice,
                TotalPrice = orderDTO.Total,
                FirstName = orderDTO.FirstName,
                LastName = orderDTO.LastName,
                PhoneNumber = orderDTO.Phone,
                ProductsOrders = new List<ProductOrder>(),
                ShippingProvider = "ЕКОНТ",
                ShippingCity = orderDTO.City,
                ShippingOffice = orderDTO.Office
            };

            foreach (ProductBagDTO product in orderDTO.Products)
            {
                ProductOrder productOrder = new()
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

        public async Task<IEnumerable<OrderGetDTO>> GetOrdersAsync(Guid userId)
        {
            var orders = await _context.Orders
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
                    })
                })
                .ToListAsync();

            return orders;
        }
    }
}
