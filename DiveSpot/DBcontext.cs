using DiveSpot.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiveSpot
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        { }

        public DBcontext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DBcontext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Dive> Dive { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Water> Water { get; set; }
    }
}
