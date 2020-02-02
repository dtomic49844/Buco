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

namespace BucoUnitTest
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task GetInfoAsync()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Info();

            //Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task GetIndexAsync()
        {
            //Arrange
            var controller = new HomeController();
            var expected = new HomePageViewModel { GoalText = null, MsgToDisplay = null };

            // Act
            var result = controller.Index(null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var actual = Assert.IsAssignableFrom<HomePageViewModel>(viewResult.ViewData.Model);

            Assert.Equal(expected.MsgToDisplay, actual.MsgToDisplay);
            Assert.Equal(expected.GoalText, actual.GoalText);
        }
    }
}
