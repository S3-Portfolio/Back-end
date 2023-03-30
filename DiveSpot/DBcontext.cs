using Microsoft.EntityFrameworkCore;
using DiveSpot.Entities;

namespace DiveSpot
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DBcontext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<DiveSpot.Dive> Dive { get; set; }
        public DbSet<DiveSpot.Fish> Fish { get; set; }
        public DbSet<DiveSpot.Water> Water { get; set; }

        
    }
}
