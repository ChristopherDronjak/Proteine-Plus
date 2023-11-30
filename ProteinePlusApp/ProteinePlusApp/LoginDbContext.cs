﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using ProteinePlusApp.MVVM.Models;

namespace ProteinePlusApp
{
    public class LoginDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databaseFolderPath = Path.Combine(folderPath, "Database");

            // Ensure the "Database" folder exists
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }

            var dbPath = Path.Combine(databaseFolderPath, "app.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

}
