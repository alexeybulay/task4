using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App7.Model;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace App7.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext()
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "Product.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
