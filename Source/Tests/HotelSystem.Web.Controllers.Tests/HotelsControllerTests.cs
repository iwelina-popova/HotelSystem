using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Web.Controllers.Tests
{
    [TestFixture]
    public class HotelsControllerTests
    {
        [Test]
        public void ShouldWorkWithCorrectId()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(DetailsController).Assembly);

            var hotelServiceMock = new Mock<IHotelsService>();
            hotelServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(HotelForTest);

            var hotelRoomsServiceMock = new Mock<IHotelRoomsService>();

            var controller = new DetailsController(hotelServiceMock.Object, hotelRoomsServiceMock.Object);
            controller.WithCallTo(x => x.HotelDetails(1))
                .ShouldRenderView("HotelDetails")
                .WithModel<DetailsViewModel>(
                viewModel =>
                {
                    Assert.AreEqual(HotelForTest, viewModel.Hotel);
                }).AndModelError("");
        }
    }
}
