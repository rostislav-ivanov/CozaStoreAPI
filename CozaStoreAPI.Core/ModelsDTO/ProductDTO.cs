﻿namespace CozaStoreAPI.Core.ModelsDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Images { get; set; } = [];
    }
}
