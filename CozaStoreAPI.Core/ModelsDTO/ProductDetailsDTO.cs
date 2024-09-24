namespace CozaStoreAPI.Core.ModelsDTO
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<string> Images { get; set; } = [];

        public decimal Price { get; set; }

        public IEnumerable<string> Sizes { get; set; } = [];

        public IEnumerable<string> Colors { get; set; } = [];

        public string Description { get; set; } = string.Empty;

        public string Material { get; set; } = string.Empty;

    }
}


