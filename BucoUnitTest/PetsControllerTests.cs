using Buco.Controllers;
using Buco.Services;
using Buco.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Buco.Models;
using Buco.InfoModels;
using Microsoft.Extensions.Options;

namespace BucoUnitTest
{
    public class PetsControllerTests
    {

        [Fact]
        public async Task Index()
        {
            // Arrange
            var userId = "1";

            var expectedPet = new Pet
            {
                ActivityEntries = null,
                ActivityLevel = 3,
                TargetActivity = 60,
                DOB = DateTime.Now,
                BodyCondtionScore = 4,
                Gender = "Male",
                Spayed = false,
                TargetCalories = 400,
                TargetWeight = 6.4f,
                UserId = "1",
                WeightEntries = null,
                MealEntries = null,
                PetId = 1142,
                PetName = "Filip",
                PetTypeId = 1,
                Photo = null
            };

            var expectedPetViewModel = new PetViewModel(expectedPet);

            var expectedPets = new List<Pet>
            {
                expectedPet
            };

            var expectedPetsViewModel = new List<PetViewModel>
            {
                expectedPetViewModel
            };

            var expectedViewModel = new PetsViewModel
            {
                Pets = expectedPetsViewModel,
                CrudInfo = new CRUDInfo
                {
                    Added = false,
                    Deleted = false,
                    Error = false,
                    Updated = false
                },
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = 10,
                    TotalItems = 1
                }
            };

            var mockService = new Mock<IPetService>();
            mockService.Setup(s => s.GetPetsAsync(userId))
                .ReturnsAsync(expectedPets);

            var mockMapper = new Mock<IPetMapper>();
            mockMapper.Setup(s => s.MapPets(expectedPets))
                .Returns(expectedPetsViewModel);

            var mockOptions = new Mock<IOptionsSnapshot<AppSettings>>();

            var controller = new PetsController(mockService.Object, mockMapper.Object, mockOptions.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PetsViewModel>(
                viewResult.ViewData.Model);
            var petList = (ICollection<PetViewModel>)model.Pets;
            Assert.Equal(1, petList.Count);
        }

    }
}
