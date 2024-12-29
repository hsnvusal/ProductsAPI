using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models    
{
    public class ProductsContexts : IdentityDbContext<AppUser,AppRole,int>
    {
        public DbSet<Product> Products { get; set; }
        public ProductsContexts(DbContextOptions<ProductsContexts> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product()  { ProductId = 1, ProductName = "Iphone 12",Price = 40000 , IsActive  = true}) ;
            modelBuilder.Entity<Product>().HasData(new Product()  { ProductId = 2, ProductName = "Iphone 13",Price = 50000 , IsActive  = true}) ;
            modelBuilder.Entity<Product>().HasData(new Product()  { ProductId = 3, ProductName = "Iphone 14",Price = 60000 , IsActive  = false}) ;
            modelBuilder.Entity<Product>().HasData(new Product()  { ProductId = 4, ProductName = "Iphone 15",Price = 70000 , IsActive  = true}) ;
            modelBuilder.Entity<Product>().HasData(new Product()  { ProductId = 5, ProductName = "Iphone 16",Price = 80000 , IsActive  = true}) ;

                
        
        }
    }
}