using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.City;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Table of shipping cities")]
    public class EcontCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Shipping city Id")]
        public int Id { get; set; }

        [Comment("Name of shipping city")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public List<EcontOffice> Offices { get; set; } = [];
    }
}
