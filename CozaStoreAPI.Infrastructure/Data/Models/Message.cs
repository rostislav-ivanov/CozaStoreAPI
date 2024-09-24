using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants.Message;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("Table of messages from users")]
    public class Message
    {
        [Key]
        [Comment("Primary key")]
        public int Id { get; set; }

        [Comment("Email of the user")]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Comment("First name of the user")]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last name of the user")]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Comment("Subject of the message")]
        [MaxLength(SubjectMaxLength)]
        public string Subject { get; set; } = string.Empty;

        [Comment("Content of the message")]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
    }
}
