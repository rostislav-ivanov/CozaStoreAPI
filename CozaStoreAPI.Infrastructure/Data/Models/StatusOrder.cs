using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Status of the order")]
    public class StatusOrder
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the status")]
        public string Name { get; set; } = string.Empty;

        [Comment("Navigation property to the orders")]
        public List<Order> Orders { get; set; } = [];
    }
}