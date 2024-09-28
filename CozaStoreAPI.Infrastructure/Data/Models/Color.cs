using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("The color of the product")]
    public class Color
    {
        [Comment("The color's primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("The color's name")]
        [MaxLength(DataConstants.Color.NameMaxLength)]
        public required string Name { get; set; }

        [Comment("Navigation Property to product's color")]
        public List<ProductColor> ProductsColors { get; set; } = [];
    }
}