using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.Image;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The image of the product")]
    public class ImageProduct
    {
        [Comment("The image id")]
        [Key]
        public int Id { get; set; }

        [Comment("The path of the image")]
        [MaxLength(ImagePathMaxLength)]
        public required string ImagePath { get; set; }

        [Comment("The image's order in slider")]
        public int ImageOrder { get; set; }

        public int ProductId { get; set; }

        [Comment("Navigation Property to product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

    }
}