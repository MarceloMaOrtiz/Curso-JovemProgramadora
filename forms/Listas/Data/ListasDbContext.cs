using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class ListasDbContext : DbContext
    {
        public DbSet<Lista> Listas { get; set; }

        public DbSet<Exercicio> Exercicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile("appsettings.Development.json", optional: true)
               .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }

}
