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
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last Name")]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Comment("Navigation property to the product's Reviews")]
        public List<Review> Reviews { get; set; } = [];

    }
}
