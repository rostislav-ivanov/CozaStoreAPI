using CozaStoreAPI.Infrastructure;
using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants.ErrorMessageConstants;

namespace CozaStoreAPI.Core.ModelsDTO
{
    public class ProductBagDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [Range(1, int.MaxValue, ErrorMessage = NegativOrZeroNumber)]
        [Display(Name = "Product Id")]
        public int Id { get; set; }


        [MaxLength(DataConstants.Image.ImagePathMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Product Image Path")]
        public string? Image { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [Range(0, double.MaxValue, ErrorMessage = NegativOrZeroNumber)]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [MaxLength(DataConstants.Size.NameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Product Size")]
        public string? Size { get; set; } = string.Empty;

        [MaxLength(DataConstants.Color.NameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Product Color")]
        public string? Color { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [Range(1, int.MaxValue, ErrorMessage = NegativOrZeroNumber)]
        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }
    }
}

