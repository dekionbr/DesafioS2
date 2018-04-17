using AmigoCrud.S2.Domain.Models;
using AmigoCrud.S2.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AmigoCrud.S2.Infra.Data.Context
{
    public class AmigoCrudContext : DbContext
    {
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmigoMap());
            modelBuilder.ApplyConfiguration(new JogoMap());

            modelBuilder.Entity<Amigo>()
                    .ToTable("Amigo");

            modelBuilder.Entity<Jogo>()
                    .ToTable("Jogo");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            // define the database to use
            optionsBuilder.UseSqlite(config.GetConnectionString("SqLite"));            
        }
    }
}
