using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.ProductDbContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region DbSets

        public DbSet<Product> Products { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "1",
                ImageUrl = "",
                CategoryName = "Appetizer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "2",
                ImageUrl = "",
                CategoryName = "Appetizer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "3",
                ImageUrl = "",
                CategoryName = "Dessert"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pay Bhaji",
                Price = 15,
                Description = "4",
                ImageUrl = "",
                CategoryName = "Entree"
            });
        }

        #endregion
    }
}
