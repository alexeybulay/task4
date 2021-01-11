using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App7.Model;
using Microsoft.EntityFrameworkCore;

namespace App7.DataAccess
{
    public class StandartProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StandartProductDbContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "StandartProduct.db");
            optionsBuilder.UseSqlite($@"Filename={path}");
        }
    }
}
