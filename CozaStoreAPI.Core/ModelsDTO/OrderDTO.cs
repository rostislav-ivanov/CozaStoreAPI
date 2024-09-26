namespace CozaStoreAPI.Core.ModelsDTO
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Office { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<ProductBagDTO> Products { get; set; } = [];
        public decimal ShippingPrice { get; set; }
        public decimal Total { get; set; }
    }
}




