using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CozaStoreAPI.Infrastructure.DataConstants.AppUser;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {

        [Comment("First Name")]
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Comment("Last Name")]
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

    }
}
