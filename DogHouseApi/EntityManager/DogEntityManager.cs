using System.Linq;
using DogHouseApi.Database;
using DogHouseApi.Entities;
using Microsoft.EntityFrameworkCore;

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
            dog.Image = Add(dog.Image);
            _dbContext.Dogs.Add(dog);
            return dog;
        }

        public DogEntity GetDog(int id) =>
            _dbContext
            .Dogs
            .Where(dog => dog.Id == id)
            .Include(dog => dog.Image)
            .FirstOrDefault();

        public DogEntity Update(int id, DogEntity dog)
        {
            dog.Id = id;
            dog.Image = Add(dog.Image);
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
            .Include(dog => dog.Image)
            .AsQueryable<DogEntity>();

        public void DeleteAllDogs()
        {
            _dbContext.RemoveRange(_dbContext.Dogs);
            _dbContext.RemoveRange(_dbContext.Images);
        }

        public ImageEntity Add(ImageEntity image)
        {
            if (image == null)
            {
                return null;
            }

            var duplicateImage = GetImageByFingerprint(image.Fingerprint);

            if (duplicateImage != null)
            {
                return duplicateImage;
            }

            _dbContext.Images.Add(image);

            return image;
        }

        public ImageEntity GetImage(int id) =>
            _dbContext
            .Images
            .FirstOrDefault(x => x.Id == id);

        public ImageEntity GetImageByFingerprint(string fingerprint) =>
            _dbContext
            .Images
            .FirstOrDefault(x => x.Fingerprint == fingerprint);


    }
}
