using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckApp.Infra.DTO.Truck;
using TruckApp.Infra.Transactions;
using TruckApp.Service.Interfaces;
using TruckApp.Web.Controllers;
using Xunit;

namespace TruckApp.Test
{
    public class Tests
    {

        [Fact]
        public async Task Index_ListTrucks()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            mockServices.Setup(x => x.ListAllTrucks()).ReturnsAsync(ListTrucks());

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<List<TruckDTO>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task Save_CreateTruck()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var truck = new SaveTruckDTO
            {
                ModelId = new Guid("2c63c0ee-8290-4726-b505-b8ca6d9017dd"),
                ModelYear = 2020,
                YearManufacture = 2020,
                Name = "test"
            };

            var returns = new TruckDTO { Id = Guid.NewGuid() };

            mockServices.Setup(x => x.CreateTruck(truck)).ReturnsAsync(returns);

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Save(truck);
            
            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.IsAssignableFrom<RedirectToActionResult>(viewResult);

            Assert.NotNull(returns);
        }



        [Fact]
        public async Task Returns_Required_Name()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var truck = new SaveTruckDTO
            {
                ModelId = new Guid("2c63c0ee-8290-4726-b505-b8ca6d9017dd"),
                ModelYear = 2021,
                YearManufacture = 2020,
                Name = "test"
            };

            var returns = new TruckDTO { Id = Guid.NewGuid() };

            mockServices.Setup(x => x.CreateTruck(truck)).ReturnsAsync(returns);

            Assert.True(!string.IsNullOrEmpty(truck.Name));

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Save(truck);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Returns_Required_YearManufacture()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var truck = new SaveTruckDTO
            {
                ModelId = new Guid("2c63c0ee-8290-4726-b505-b8ca6d9017dd"),                
                ModelYear = 2021,
                YearManufacture = 2020,
                Name = "test"
            };

            var returns = new TruckDTO { Id = Guid.NewGuid() };

            mockServices.Setup(x => x.CreateTruck(truck)).ReturnsAsync(returns);

            Assert.Equal(DateTime.Now.Year, truck.YearManufacture);

            Assert.True(truck.YearManufacture >= DateTime.Now.Year);

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Save(truck);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Returns_Required_ModelYear()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var truck = new SaveTruckDTO
            {
                ModelId = new Guid("2c63c0ee-8290-4726-b505-b8ca6d9017dd"),
                YearManufacture = 2020,
                ModelYear = 2020,
                Name = "test"
            };

            var returns = new TruckDTO { Id = Guid.NewGuid() };

            mockServices.Setup(x => x.CreateTruck(truck)).ReturnsAsync(returns);

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            Assert.False(truck.ModelYear == 0);

            Assert.True(truck.ModelYear >= DateTime.Now.Day);

            var result = await controller.Save(truck);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.IsAssignableFrom<RedirectToActionResult>(viewResult);

            Assert.True(truck.Id != Guid.Empty && truck != null);
        }

        [Fact]
        public async Task Save_EditTruck()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var truck = new SaveTruckDTO
            {
                Id = Guid.NewGuid(),
                ModelId = new Guid("2c63c0ee-8290-4726-b505-b8ca6d9017dd"),
                ModelYear = 2020,
                YearManufacture = 2020,
                Name = "test"
            };
            mockServices.Setup(x => x.CreateTruck(truck)).ReturnsAsync(new TruckDTO { Id = Guid.NewGuid() });

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Save(truck);
            
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsAssignableFrom<ViewResult>(viewResult);

            Assert.True(truck.Id != Guid.Empty && truck != null);
        }

        [Fact]
        public async Task DeleteTruck()
        {
            var mockServices = new Mock<ITruckService>();
            var modelServices = new Mock<IModelService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Guid idTruck = Guid.NewGuid();

            mockServices.Setup(x => x.DeleteTruck(idTruck)).Returns(Task.CompletedTask);

            var controller = new TruckController(unitOfWork.Object, mockServices.Object, modelServices.Object);

            var result = await controller.Delete(idTruck);

            var viewResult = Assert.IsType<PartialViewResult>(result);

            Assert.IsAssignableFrom<PartialViewResult>(viewResult);

        }

        private List<TruckDTO> ListTrucks()
        {
            var trucks = new List<TruckDTO>();

            trucks.Add(new TruckDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Test One",
                Model = "FH",
                ModelYear = 2020,
                YearManufacture = 2020
            });
            trucks.Add(new TruckDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Test two",
                Model = "FM",
                ModelYear = 2020,
                YearManufacture = 2020
            });

            return trucks;
        }
    }
}
