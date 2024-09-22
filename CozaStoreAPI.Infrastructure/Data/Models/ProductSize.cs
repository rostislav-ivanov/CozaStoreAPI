using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Many to many relation between products and sizes")]
    [PrimaryKey(nameof(ProductId), nameof(SizeId))]
    public class ProductSize
    {
        [Comment("The product's id")]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("The size's id")]
        public int SizeId { get; set; }

        [Comment("Navigation property to the size")]
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; } = null!;

    }
}