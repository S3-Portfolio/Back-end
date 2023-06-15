using DiveSpot.Controllers;
using DiveSpot.Entities;
using DiveSpot.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DiveSpot.Tests
{
    public class FishControllerTests
    {
        [Fact]
        public void Get_ReturnsFish()
        {
            // Arrange
            Fish fish = new Fish { Id = 1, Name = "Barber", Depth=30,Img= "https://upload.wikimedia.org/wikipedia/commons/7/75/Anthias_anthias_01.jpg",SName= "Anthias anthias" } ;
            var mockContext = new Mock<DBcontext>();
            var mockRepository = new Mock<FishRepository>();
            mockRepository.Setup(repo => repo.GetFish(fish.Id)).Returns(fish);
            var controller = new FishController();

            // Act
            var result = controller.Get(1);

            // Assert
            var actionResult = Assert.IsType<Fish>(result);
            var returnValue = Assert.IsType<Fish>(actionResult);
            Assert.Equal(fish.Id, returnValue.Id);
            Assert.Equal(fish.Name, returnValue.Name);
            Assert.Equal(fish.Depth, returnValue.Depth);
            Assert.Equal(fish.Img, returnValue.Img);
            Assert.Equal(fish.SName, returnValue.SName);
            //of uitschrijven per value, of IEquatable interfase gebruiken
        }
    }
}



