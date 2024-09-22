using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.Image;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The image of the review")]
    public class ImageReview
    {
        [Comment("The image id")]
        [Key]
        public int Id { get; set; }

        [Comment("The path of the image")]
        [MaxLength(ImagePathMaxLength)]
        public required string ImagePath { get; set; }

        [Comment("The review id")]
        public int ReviewId { get; set; }

        [Comment("Navigation Property to review")]
        [ForeignKey(nameof(ReviewId))]
        public Review Review { get; set; } = null!;
    }
}