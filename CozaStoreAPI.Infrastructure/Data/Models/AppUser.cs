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

        [Comment("User's shipping city")]
        [MaxLength(ShippingCityMaxLength)]
        public string ShippingCity { get; set; } = string.Empty;

        [Comment("User's shipping office")]
        [MaxLength(ShippingOfficeMaxLength)]
        public string ShippingOffice { get; set; } = string.Empty;

        [Comment("Navigation property to the product's Reviews")]
        public List<Review> Reviews { get; set; } = [];

        [Comment("Navigation property to mapping table WishUser")]
        List<WishUser> WishesUsers { get; set; } = [];

    }
}
