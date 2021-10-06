using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductDTOModel;
using UserDTOModel;
using FavouriteDTOModel;

namespace EFTechCommerce
{
    public class TechCommerceContext : DbContext
    {
        public DbSet<ProductDTO> Products { get; set; }

        public DbSet<FavouriteDTO> Favourites { get; set; }

        public DbSet<UserDTO> Users { get; set; }

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
            modelBuilder.Entity<ProductDTO>().ToTable("Products");
            modelBuilder.Entity<FavouriteDTO>().ToTable("Favourites");
            modelBuilder.Entity<UserDTO>().ToTable("Users");
        }
    }
}
