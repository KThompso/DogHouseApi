using System.Linq;
using DogHouseApi.Database;
using DogHouseApi.Entities;

namespace DogHouseApi
{
    public class DogEntityManager : IDogEntityManager
    {
        private readonly DogDbContext _dbContext;

        public DogEntityManager(DogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public DogEntity Add(DogEntity dog)
        {
            _dbContext.Dogs.Add(dog);
            return dog;
        }

        public DogEntity GetDog(int id) =>
            _dbContext
            .Dogs
            .Where(dog => dog.Id == id)
            .FirstOrDefault();

        public DogEntity Update(int id, DogEntity dog)
        {
            dog.Id = id;
            _dbContext.Dogs.Update(dog);
            return dog;
        }

        public void DeleteDog(int id)
        {
            DogEntity dog = GetDog(id);
            _dbContext.Dogs.Remove(dog);
        }

        public IQueryable<DogEntity> GetAllDogs() =>
            _dbContext
            .Dogs
            .AsQueryable<DogEntity>();

        public void DeleteAllDogs()
        {
            _dbContext.RemoveRange(_dbContext.Dogs);
        }
    }
}
