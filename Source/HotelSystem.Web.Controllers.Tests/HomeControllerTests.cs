using HotelSystem.Services.Data.Contracts;
using HotelSystem.Web.Infrastructure.Mapping;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HotelSystem.Web.Controllers.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexShouldReturnCorrectView()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(HomeController).Assembly);

            var homeServiceMock = new Mock<IHomeService>();
            HomeController home = new HomeController(homeServiceMock.Object);
            ViewResult result = home.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
