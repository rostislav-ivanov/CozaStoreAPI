using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Many to many relation between products and colors")]
    [PrimaryKey(nameof(ProductId), nameof(ColorId))]
    public class ProductColor
    {
        [Comment("The product's id")]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("The size's id")]
        public int ColorId { get; set; }

        [Comment("Navigation property to the size")]
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; } = null!;
    }
}