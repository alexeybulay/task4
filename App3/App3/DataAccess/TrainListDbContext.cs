using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App3.Model;
using Microsoft.EntityFrameworkCore;

namespace App3.DataAccess
{
    public class TrainListDbContext : DbContext
    {
        public DbSet<TrainList.AllBody> AllBodyDbSet { get; set; }
        public DbSet<TrainList.GrudAndBiceps> GrudAndBicepsesDbSet { get; set; }
        public DbSet<TrainList.Press> PressDbSet { get; set; }
        public DbSet<TrainList.SpinaAndTriceps> SpinaAndTricepsDbSet { get; set; }
        public DbSet<TrainList.NogiAndPlechi> NogiAndPlechiDbSet { get; set; }
        public TrainListDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var allBodyPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "1allBody.db");  
            var grudAndBicepsPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "1grudAndBiceps.db");
            var pressPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "1press.db");
            var spinaAndTricepsPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "1spinaAndTriceps.db");
            var nogiAndPlechiPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "1nogiAndPlechi.db");
            optionsBuilder.UseSqlite($"FileName={allBodyPath}");
            optionsBuilder.UseSqlite($"FileName={grudAndBicepsPath}");
            optionsBuilder.UseSqlite($"FileName={pressPath}");
            optionsBuilder.UseSqlite($"FileName={spinaAndTricepsPath}");
            optionsBuilder.UseSqlite($"FileName={nogiAndPlechiPath}");
        }
    }
}
