using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.Review;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The review of the product")]
    public class Review
    {
        [Comment("The review's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The product Id")]
        public int ProductId { get; set; }

        [Comment("Navigation Property to product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Comment("The author Id")]
        public Guid AuthorId { get; set; }

        [Comment("Navigation Property to user")]
        [ForeignKey(nameof(AuthorId))]
        public AppUser Author { get; set; } = null!;

        [Comment("The rating of the review.")]
        public int Rating { get; set; }

        [Comment("The title of the review.")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Comment("The comment of the review.")]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; } = string.Empty;

        [Comment("The images of the review.")]
        public List<ImageReview> Images { get; set; } = [];

        [Comment("The date when the review was created.")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}