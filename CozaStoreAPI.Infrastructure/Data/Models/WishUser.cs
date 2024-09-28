﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozaStoreAPI.Infrastructure.Data.Models
{
    [Comment("This table contains the products that the user has added to his wish list")]
    [PrimaryKey("AppUserId", "ProductId")]
    public class WishUser
    {
        [Comment("The user id")]
        [Required]
        public required Guid AppUserId { get; set; }

        [Comment("Navigation property to the user that has added the product to his wish list")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;

        [Comment("The product id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product that the user has added to his wish list")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
