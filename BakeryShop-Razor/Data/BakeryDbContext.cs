using BakeryShop_Razor.Data.BakeryDatabase;
using BakeryShop_Razor.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop_Razor.Data
{
    public class BakeryDbContext : IdentityDbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=BakeryShop.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//I know Data annotations is easier but i want to learn this fluent API
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cart>().HasKey(c => c.Id);
            modelBuilder.Entity<Cart>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<Cart>().HasOne(u => u.CustomUser).WithOne(c=>c.Cart).HasForeignKey<CustomUser>(u=>u.CartId);
            modelBuilder.Entity<Product>().Property(p=>p.ImageName).HasColumnName("image");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("ProductName");
            modelBuilder.Seed();
        } 
    }
}