using DogHouseApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogHouseApi.Database
{
    public class DogDbContext : DbContext
    {

        public DbSet<DogEntity> Dogs { get; set; }

        public DogDbContext(DbContextOptions<DogDbContext> options)
           : base(options)
        {

        }

    }
}
