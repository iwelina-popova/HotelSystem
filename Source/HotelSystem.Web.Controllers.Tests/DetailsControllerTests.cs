using HotelSystem.Services.Data.Contracts;
using HotelSystem.Web.Areas.Hotels.Controllers;
using HotelSystem.Web.Infrastructure.Mapping;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using HotelSystem.Data.Models;
using TestStack.FluentMVCTesting;
using HotelSystem.Web.Areas.Hotels.ViewModels.Details;
//using TestStack.FluentMVCTesting;

namespace HotelSystem.Web.Controllers.Tests
{
    [TestFixture]
    public class DetailsControllerTests
    {   
        [Test]
        public void ShouldWorkWithCorrectId()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(DetailsController).Assembly);

            var hotelServiceMock = new Mock<IHotelsService>();
            Hotel hotelForTest = new Hotel()
            {
                Name = "Some name",
                Description = "Some description",
                Location = new Location() { Country = "Bulgaria", City = "Sofia", Address = "5th Street" },
                Email = "some@some.com",
                Stars = 4
            };
            hotelServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(hotelForTest);

            var hotelRoomsServiceMock = new Mock<IHotelRoomsService>();
            IList<HotelRoom> rooms = new List<HotelRoom>();
            rooms.Add(new HotelRoom()
            {
                HotelId = hotelForTest.Id,
                RoomId = 1,
                RoomNumber = "101"
            });

            hotelRoomsServiceMock.Setup(x => x.GetUniqueRoomTypesInHotel(It.IsAny<int>()))
                .Returns(rooms.AsQueryable);

            var controller = new DetailsController(hotelServiceMock.Object, hotelRoomsServiceMock.Object);
            var id = 1;
            controller.WithCallTo(x => x.HotelDetails(id))
                .ShouldRenderView("HotelDetails")
                .WithModel<DetailsViewModel>(
                viewModel =>
                {
                    Assert.AreEqual(hotelForTest, viewModel.Hotel);
                }).AndModelError("");
        }
    }
}
