using HotelSystem.Data.Models;
using HotelSystem.Services.Data.Contracts;
using HotelSystem.Web.Areas.Administration.ViewModels.Hotels;
using HotelSystem.Web.Areas.Hotels.Controllers;
using HotelSystem.Web.Infrastructure.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace HotelSystem.Web.Controllers.Tests
{
    [TestFixture]
    public class BookingAreaAllControllerTests
    {
        [Test]
        public void BookingAreaAllControllerShouldReturnIndexView()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(AllController).Assembly);

            var hotelServiceMock = new Mock<IHotelsService>();
            hotelServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Hotel>().AsQueryable());

            var controller = new AllController(hotelServiceMock.Object);
            controller.WithCallTo(x => x.Index())
                .ShouldRenderView("Index");
        }
    }
}
