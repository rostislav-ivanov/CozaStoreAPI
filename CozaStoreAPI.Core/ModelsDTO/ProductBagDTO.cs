namespace CozaStoreAPI.Core.ModelsDTO
{
    public class ProductBagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}

