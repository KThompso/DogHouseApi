using System.Linq;
using DogHouseApi.Entities;

namespace DogHouseApi
{
    public interface IDogEntityManager
    {

        public abstract DogEntity AddDog(DogEntity dog);

        public abstract ImageEntity AddImage(ImageEntity image);

        public abstract DogEntity GetDog(int id);

        public abstract int GetDogCount();

        public abstract ImageEntity GetImage(int id);

        public abstract DogEntity UpdateDog(int id, DogEntity dog);

        public abstract void DeleteDog(int id);

        public abstract IQueryable<DogEntity> GetAllDogs();

        public abstract void DeleteAllDogs();

        public abstract void Save();

    }
}
