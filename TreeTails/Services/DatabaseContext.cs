using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TreeTails.Model;

namespace TreeTails.Services
{
    class DatabaseContext: DbContext
    {
        public DbSet<TreeModel> Puno { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TreeList.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
