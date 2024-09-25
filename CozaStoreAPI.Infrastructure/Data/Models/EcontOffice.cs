using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.Office;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Table of shipping cities")]
    public class EcontOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Shipping office Id")]
        public int Id { get; set; }

        [Comment("Name of office city")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [Comment("Navigation property to city")]
        public EcontCity City { get; set; } = null!;
    }
}
