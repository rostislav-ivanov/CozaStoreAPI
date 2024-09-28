using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants;
using static CozaStoreAPI.Infrastructure.DataConstants.ErrorMessageConstants;
using static CozaStoreAPI.Infrastructure.DataConstants.Message;

namespace CozaStoreAPI.Core.ModelsDTO
{
    public class EmailDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(EmailMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(EmailPattern, ErrorMessage = InvalidEmailAddress)]
        public string Email { get; set; } = string.Empty;
    }
}
