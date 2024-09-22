using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The product")]
    public class Product
    {
        [Comment("The product's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The product's name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Navigation Property to product's images")]
        public List<ImageProduct> Images { get; set; } = [];

        [Comment("The product's description")]
        public string Description { get; set; } = string.Empty;

        [Comment("The product's price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("The product's category id")]
        public int? CategoryId { get; set; }

        [Comment("Navigation Property to product's category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;


        [Comment("Navigation Property to product's sizes")]
        public List<ProductSize> Sizes { get; set; } = [];


        [Comment("Navigation Property to product's colors")]
        public List<ProductColor> Colors { get; set; } = [];

        [Comment("The product's material")]
        public string Material { get; set; } = string.Empty;

        [Comment("Navigation property to the product's Reviews")]
        public List<Review> Reviews { get; set; } = [];

        [Comment("The product is deleted or not")]
        public bool IsDeleted { get; set; }

        [Comment("The product's created date")]
        public DateTimeOffset CreatedAt { get; set; }

        [Comment("The product's updated date")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
