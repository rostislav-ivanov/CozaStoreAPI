namespace CozaStoreAPI.Core.ModelsDTO
{
    public class OrderGetDTO
    {
        public string OrderNumber { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public IEnumerable<Product> Products { get; set; } = [];

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string? ImagePath { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string? Size { get; set; } = string.Empty;
            public string? Color { get; set; } = string.Empty;
        }
    }
}
