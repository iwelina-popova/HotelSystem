namespace HotelSystem.Web.Routes.Tests.AdministrationArea
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using HotelSystem.Web.Areas.Administration;
    using HotelSystem.Web.Areas.Administration.Controllers;

    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class AdministrationAreaBookingsRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area5Reg = new AdministrationAreaRegistration();
            var area5Context = new AreaRegistrationContext(area5Reg.AreaName, RouteTable.Routes);
            area5Reg.RegisterArea(area5Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void DefaultInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings";
            this.routeCollection
                .ShouldMap(url)
                .To<BookingsController>(c => c.Index());
        }

        [Test]
        public void CreateInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<BookingsController>(c => c.Create());
        }

        [Test]
        public void CreateWithInputModelInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<BookingsController>(c => c.Create(null));
        }

        [Test]
        public void EditInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings/Edit/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<BookingsController>(c => c.Edit(id));
        }

        [Test]
        public void EditWithEditModelInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings/Edit";
            this.routeCollection
                .ShouldMap(url)
                .To<BookingsController>(c => c.Edit(null));
        }

        [Test]
        public void DeleteInBookingsControllerRoute()
        {
            var url = "/Administration/Bookings/Delete/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<BookingsController>(c => c.Delete(id));
        }
    }
}
