using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CozaStoreAPI.Infrastructure.DataConstants.Order;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    public class Order
    {
        [Comment("Order Id")]
        [Key]
        public int Id { get; set; }

        [Comment("App User Id")]
        public Guid AppUserId { get; set; }

        [Comment("Navigation Property to AppUser")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;

        [Comment("Order Number")]
        public string OrderNumber { get; set; } = string.Empty;

        [Comment("Date of Order Creating")]
        public DateTimeOffset CreatedOn { get; set; }

        [Comment("Status of Order")]
        public int StatusOrderId { get; set; }

        [Comment("Navigation Property to StatusOrder")]
        [ForeignKey(nameof(StatusOrderId))]
        public StatusOrder StatusOrder { get; set; } = null!;

        [Comment("Date of Shipping Creating")]
        public DateTimeOffset? DateShipping { get; set; }

        [Comment("Tracking Number of Order")]
        [MaxLength(TrackingNumberMaxLength)]
        public string? TrackingNumber { get; set; }

        [Comment("Is Paid Order")]
        public bool IsPaid { get; set; }

        [Comment("Navigation Property to Products")]
        public List<ProductOrder> ProductsOrders { get; set; } = [];

        [Comment("Shipping Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingPrice { get; set; }

        [Comment("Total Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [MaxLength(FirstNameMaxLength)]
        [Comment("First Name Recipient")]
        public required string FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("Last Name Recipient")]
        public required string LastName { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Phone Number Recipient")]
        public required string PhoneNumber { get; set; }

        [Comment("Shipping Provider")]
        public string? ShippingProvider { get; set; }

        [Comment("City Recipient")]
        [MaxLength(DataConstants.City.NameMaxLength)]
        public string? ShippingCity { get; set; }

        [Comment("Office Recipient")]
        [MaxLength(DataConstants.Office.NameMaxLength)]
        public string? ShippingOffice { get; set; }
    }
}
