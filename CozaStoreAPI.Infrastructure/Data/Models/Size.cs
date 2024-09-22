using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The size of the product")]
    public class Size
    {
        [Comment("The size's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The size's name")]
        public required string Name { get; set; }

        [Comment("Navigation Property to product's sizes")]
        public List<ProductSize> ProductsSizes { get; set; } = [];
    }
}