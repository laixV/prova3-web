using System;
using Super_Market.Domain.Helpers;
using Super_Market.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Super_Market.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(
                @"Server=ec2-54-208-96-16.compute-1.amazonaws.com; Port=5432; User Id=ixedkeeqttsdjd; Password=54f7dabc8bf0d3b857e608b8ff17aebb5489ae7245cf519ea1fa3133bc368a96; Database=d7rejkaifghcg; Pooling=true; SSL Mode=Require; TrustServerCertificate=True;");
        }

        public  DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId); 
      

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnityOfMeasurement).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CreatedAt).HasDefaultValueSql("now()");

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
           
        } 
    }
}
