using CozaStoreAPI.Infrastructure.Data.DataConfiguration;
using CozaStoreAPI.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CozaStoreAPI.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<ImageProduct> ImageProducts { get; set; } = null!;
        public DbSet<ImageReview> ImageReviews { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductSize> ProductsSizes { get; set; } = null!;
        public DbSet<ProductColor> ProductsColors { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;





        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoriesConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new ImageProductsConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());
            builder.ApplyConfiguration(new ProductsSizesConfiguration());
            builder.ApplyConfiguration(new ProductsColorsConfiguration());


            base.OnModelCreating(builder);
        }
    }
}
