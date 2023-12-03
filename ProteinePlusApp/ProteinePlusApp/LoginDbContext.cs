using System;
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
        //getting users in database
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //finding folder for database
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databaseFolderPath = Path.Combine(folderPath, "Database");

            // Ensure the "Database" folder exists
            if (!Directory.Exists(databaseFolderPath))
            {
                Directory.CreateDirectory(databaseFolderPath);
            }

            //getting variable for database path
            var dbPath = Path.Combine(databaseFolderPath, "app.db");

            //getting datasource
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

}
