using DogHouseApi;
using DogHouseApi.Controllers;
using DogHouseApi.Database;
using DogHouseApi.Mappers;
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

            IDogEntityManager dogEntityManager = new DogEntityManager(dbContext);
            IDogMapper dogMapper = new DogMapper();
            Controller = new DogsController(dogEntityManager, dogMapper);
        }

        [Fact]
        public void PostDogShouldReturnCreated()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            var result = Controller.PostDog(dogDto, apiVersion);

            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void PostDogWithInvalidImageShouldReturnBadRequest()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "invalid-base64-image",
            };

            var result = Controller.PostDog(dogDto, apiVersion);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PutDogShouldReturnCreated()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.PostDog(dogDto, apiVersion);
            var result = Controller.PutDog(1, dogDto, apiVersion);

            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void GetAllDogsShouldReturnOk()
        {
            var result = Controller.GetDogs(apiVersion);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetExistingDogShouldReturnOk()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.PostDog(dogDto, apiVersion);

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
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            var result = Controller.PutDog(1, dogDto, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteExistingDogShouldReturnNoContent()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            _ = Controller.PostDog(dogDto, apiVersion);

            var result = Controller.DeleteDog(1, apiVersion);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteNonExistingDogShouldReturnNotFound()
        {
            var result = Controller.DeleteDog(1, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteAllDogsShouldRemoveDog()
        {
            var dogDto = new DogDto
            {
                Breed = DogBreed.German_Shepherd,
                Name = "Major",
                Image = "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==",
            };

            for (int i = 0; i < 100; ++i)
            {
                _ = Controller.PostDog(dogDto, apiVersion);
            }

            var result = Controller.DeleteAllDogs(apiVersion);

            Assert.IsType<NoContentResult>(result);

            result = Controller.GetDog(1, apiVersion);

            Assert.IsType<NotFoundResult>(result);
        }

    }
}
