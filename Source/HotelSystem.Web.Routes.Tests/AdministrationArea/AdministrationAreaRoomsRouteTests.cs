using HotelSystem.Web.Areas.Administration;
using HotelSystem.Web.Areas.Administration.Controllers;
using MvcRouteTester;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelSystem.Web.Routes.Tests.AdministrationArea
{
    [TestFixture]
    public class AdministrationAreaRoomsRouteTests
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
        public void DefaultInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms";
            this.routeCollection
                .ShouldMap(url)
                .To<RoomsController>(c => c.Index());
        }

        [Test]
        public void CreateInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<RoomsController>(c => c.Create());
        }

        [Test]
        public void CreateWithInputModelInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<RoomsController>(c => c.Create(null));
        }

        [Test]
        public void EditInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms/Edit/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<RoomsController>(c => c.Edit(id));
        }

        [Test]
        public void EditWithEditModelInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms/Edit";
            this.routeCollection
                .ShouldMap(url)
                .To<RoomsController>(c => c.Edit(null));
        }

        [Test]
        public void DeleteInRoomsControllerRoute()
        {
            var url = "/Administration/Rooms/Delete/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<RoomsController>(c => c.Delete(id));
        }
    }
}
