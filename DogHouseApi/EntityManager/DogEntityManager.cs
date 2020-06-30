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

        public DogEntity AddDog(DogEntity dog)
        {
            dog.ImageData = AddImage(dog.ImageData);
            _dbContext.Dogs.Add(dog);
            return dog;
        }

        public DogEntity GetDog(int id) =>
            _dbContext
            .Dogs
            .Where(dog => dog.Id == id)
            .Include(dog => dog.ImageData)
            .FirstOrDefault();

        public DogEntity UpdateDog(int id, DogEntity dog)
        {
            dog.Id = id;
            dog.ImageData = AddImage(dog.ImageData);
            _dbContext.Dogs.Update(dog);
            return dog;
        }

        public void DeleteDog(int id)
        {
            DogEntity dog = GetDog(id);
            _dbContext.Dogs.Remove(dog);
        }

        public int GetDogCount() => _dbContext.Dogs.Count();

        public IQueryable<DogEntity> GetAllDogs() =>
            _dbContext
            .Dogs
            // TODO don't include the image data
            .Include(dog => dog.ImageData )
            .AsQueryable<DogEntity>();

        public void DeleteAllDogs()
        {
            _dbContext.RemoveRange(_dbContext.Dogs);
            _dbContext.RemoveRange(_dbContext.Images);
        }

        public ImageEntity AddImage(ImageEntity image)
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
