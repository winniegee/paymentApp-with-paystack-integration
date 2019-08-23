using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructuree.Data
{
    public class BakeryContext:DbContext
    {
        public BakeryContext()
        {

        }
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
        {
            Database.SetCommandTimeout(9000);
        }
        public DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("BakeryContext");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
