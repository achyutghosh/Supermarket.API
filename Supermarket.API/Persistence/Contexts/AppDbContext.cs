using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);

            // Define the relationship between "Categories" table and "Products" table
            builder.Entity<Category>()
                   .HasMany(p => p.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId);

            // Static data for Category table
            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Dairy" },
                new Category { Id = 102, Name = "Chocolates" },
                new Category { Id = 103, Name = "Groceries" },
                new Category { Id = 104, Name = "Drinks & ice creams" },
                new Category { Id = 105, Name = "Regular essentials" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            // Static data for Product table
            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );

        }
    }
}