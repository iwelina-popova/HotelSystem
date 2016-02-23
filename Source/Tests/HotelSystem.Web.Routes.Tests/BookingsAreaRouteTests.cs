using HotelSystem.Web.Areas.Booking;
using HotelSystem.Web.Areas.Booking.Controllers;
using HotelSystem.Web.Areas.Booking.ViewModels.Available;
using MvcRouteTester;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelSystem.Web.Routes.Tests
{
    [TestFixture]
    public class BookingsAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var registerArea = new BookingAreaRegistration();
            var contextArea = new AreaRegistrationContext(registerArea.AreaName, RouteTable.Routes);
            registerArea.RegisterArea(contextArea);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void DefaultBookingAreaRoute()
        {
            var url = "/Booking/Available";
            this.routeCollection
                .ShouldMap(url)
                .To<AvailableController>(c => c.Index());
        }
        
        [Test]
        public void ViewPricesWithModelBookingAreaRoute()
        {
            var url = "/Booking/Available/ViewPrices";
            this.routeCollection
                .ShouldMap(url)
                .To<AvailableController>(c => c.ViewPrices(null));
        }
    }
}
