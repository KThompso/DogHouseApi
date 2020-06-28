using DogHouseApi;
using DogHouseApi.Controllers;
using DogHouseApi.Database;
using DogHouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DogHouseApiTests.Controllers
{
    public class DogsControllerTest
    {
        private readonly DogsController Controller;
        private readonly ApiVersion apiVersion;

        public DogsControllerTest()
        {
            apiVersion = new ApiVersion(1, 0);

            var options = new DbContextOptionsBuilder<DogDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDogDatabase")
                .Options;

            var dbContext = new DogDbContext(options);

            dbContext.Database.EnsureDeleted();

            var httpContext = new DefaultHttpContext();

            var dogEntityManager = new DogEntityManager(dbContext);
            Controller = new DogsController(dogEntityManager);
        }

        [Fact]
        public void PostDogShouldReturnCreated()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            var result = Controller.Post(dogDto, apiVersion);

            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void PutDogShouldReturnCreated()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.Post(dogDto, apiVersion);
            var result = Controller.Put(1, dogDto, apiVersion);

            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void GetAllDogsShouldReturnOk()
        {
            var result = Controller.Get(apiVersion);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetExistingDogShouldReturnOk()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.Post(dogDto, apiVersion);

            var result = Controller.GetDog(1, apiVersion);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetNonExistingDogShouldReturnNotFound()
        {
            var result = Controller.GetDog(1, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PutNonExistingDogShouldReturnNotFound()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            var result = Controller.Put(1, dogDto, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteExistingDogShouldReturnNoContent()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.Post(dogDto, apiVersion);

            var result = Controller.Delete(1, apiVersion);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteNonExistingDogShouldReturnNotFound()
        {
            var result = Controller.Delete(1, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteAllDogsShouldRemoveDog()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Picture = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            for (int i = 0; i < 100; ++i)
            {
                _ = Controller.Post(dogDto, apiVersion);
            }

            var result = Controller.Delete(apiVersion);

            Assert.IsType<NoContentResult>(result);

            result = Controller.GetDog(1, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

    }
}
