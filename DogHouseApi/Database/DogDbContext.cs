using DogHouseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogHouseApi.Database
{
    public class DogDbContext : DbContext
    {

        public DbSet<DogEntity> Dogs { get; set; }

        public DbSet<ImageEntity> Images { get; set; }

        public DogDbContext(DbContextOptions<DogDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntity>()
                .HasIndex(image => image.Fingerprint);
        }

    }
}
