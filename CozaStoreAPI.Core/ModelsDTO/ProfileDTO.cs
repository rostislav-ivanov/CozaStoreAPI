using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants;
using static CozaStoreAPI.Infrastructure.DataConstants.AppUser;
using static CozaStoreAPI.Infrastructure.DataConstants.ErrorMessageConstants;

namespace CozaStoreAPI.Core.ModelsDTO
{
    public class ProfileDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(EmailMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(EmailPattern, ErrorMessage = InvalidEmailAddress)]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(FirstNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(LastNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [RegularExpression(PhonePattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(ShippingCityMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Shipping City")]
        public string ShippingCity { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(ShippingOfficeMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "Shipping Office")]
        public string ShippingOffice { get; set; } = string.Empty;
    }
}
