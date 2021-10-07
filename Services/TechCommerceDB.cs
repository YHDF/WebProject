using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace EFTechCommerce.Services
{
    public class TechCommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; private set; }

        public TechCommerceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath =
                $"{path}{System.IO.Path.DirectorySeparatorChar}DataFixtures{System.IO.Path.DirectorySeparatorChar}TechCommerce.db";
        }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder options
        ) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Favourite>().ToTable("Favourites");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
