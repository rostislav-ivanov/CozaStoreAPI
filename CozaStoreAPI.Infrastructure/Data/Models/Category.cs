using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The category of the product")]
    public class Category
    {
        [Comment("The category's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The category's name")]
        public required string Name { get; set; }

        [Comment("Navigation Property to product's category")]
        public List<Product> Products { get; set; } = [];

    }
}