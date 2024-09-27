using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants;
using static CozaStoreAPI.Infrastructure.DataConstants.ErrorMessageConstants;
using static CozaStoreAPI.Infrastructure.DataConstants.Message;

namespace CozaStoreAPI.Core.ModelsDTO
{
    public class MessageDTO
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
        [MaxLength(SubjectMaxLength, ErrorMessage = StringLengthMax)]
        public string Subject { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredField)]
        [MaxLength(ContentMaxLength, ErrorMessage = StringLengthMax)]
        public string Content { get; set; } = string.Empty;
    }
}


