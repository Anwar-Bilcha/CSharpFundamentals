using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OOPinCSharps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) // Sets the base path for appsettings.json
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            // Retrieve the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
