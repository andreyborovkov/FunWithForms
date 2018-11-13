using FunWithForms.Controllers;
using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace FunWithForms.Tests
{
    public class CarsControllerTests
    {
        private Car car;
        private ICarRepository carsRepo;
        private CarsController underTest;

        public CarsControllerTests()
        {
            car = new Car();
            carsRepo = Substitute.For<ICarRepository>();
            underTest = new CarsController(carsRepo);
        }
        [Fact]
        public void Create_Create_Car()
        {

            underTest.Create(car);

            carsRepo.Received().Create(car);
        }

        [Fact]
        public void Create_Redirects_To_Index_After_Creating()
        {

            var result = underTest.Create(car);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Index_Passes_All_Cars_ToView()
        {
            var expectedCar = new List<Car>();
            carsRepo.GetAll().Returns(expectedCar);

            var result = underTest.Index();
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Details_Passes_Correct_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();
            carsRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Details(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);

        }

        [Fact]
        public void Delete_Passes_Correct_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();
            carsRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Delete(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);

        }

        [Fact]
        public void Delete_Post_Deletes_The_Car()
        {
            var carId = 42;

            underTest.DeletePost(carId);

            carsRepo.Received().Delete(carId);
        }

        [Fact]
        public void Delete_Redirects_To_Index_After_Deleting()
        {

            var result = underTest.DeletePost(42);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName);
        }
    }
}
