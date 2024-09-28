﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Many to many relation between products and orders")]
    [PrimaryKey("ProductId", "OrderId")]
    public class ProductOrder
    {
        public int ProductId { get; set; }
        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public int OrderId { get; set; }
        [Comment("Navigation property to the order")]
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Comment("The quantity of the product in the order")]
        public int Quantity { get; set; }

        [Comment("The price of the product at the time of the order")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("The image path of the product at the time of the order")]
        [MaxLength(DataConstants.Image.ImagePathMaxLength)]
        public string? ImagePath { get; set; } = string.Empty;

        [Comment("The size of the product at the time of the order")]
        [MaxLength(DataConstants.Size.NameMaxLength)]
        public string? Size { get; set; } = string.Empty;

        [Comment("The color of the product at the time of the order")]
        [MaxLength(DataConstants.Color.NameMaxLength)]
        public string? Color { get; set; } = string.Empty;
    }
}