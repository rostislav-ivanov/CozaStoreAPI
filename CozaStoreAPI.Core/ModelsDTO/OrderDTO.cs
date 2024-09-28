using CozaStoreAPI.Common.ModelBinders;
using CozaStoreAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants.ErrorMessageConstants;

namespace CozaStoreAPI.Core.ModelsDTO
{
    public class OrderDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(DataConstants.City.NameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Shipping City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(DataConstants.Office.NameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Shipping Office")]
        public string Office { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(DataConstants.AppUser.FirstNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(DataConstants.AppUser.LastNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [RegularExpression(DataConstants.PhonePattern, ErrorMessage = InvalidPhoneNumber)]
        [MaxLength(DataConstants.Order.PhoneNumberMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [MinLength(1, ErrorMessage = EmptyList)]
        [Display(Name = "Products in Bag")]
        public List<ProductBagDTO> Products { get; set; } = new List<ProductBagDTO>();

        [Required(ErrorMessage = RequiredField)]
        [Range(0.00, double.MaxValue, ErrorMessage = NegativeDecimalVolue)]
        [Display(Name = "Shipping Price")]
        [ModelBinder(BinderType = typeof(DecimalModelBinder))]
        public decimal ShippingPrice { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(0.00, double.MaxValue, ErrorMessage = NegativeDecimalVolue)]
        [Display(Name = "Total Price")]
        [ModelBinder(BinderType = typeof(DecimalModelBinder))]
        public decimal Total { get; set; }
    }
}
