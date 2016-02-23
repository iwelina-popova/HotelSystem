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
    public class AdministrationAreaHotelsRouteTests
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
        public void DefaultInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels";
            this.routeCollection
                .ShouldMap(url)
                .To<HotelsController>(c => c.Index());
        }

        [Test]
        public void CreateInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<HotelsController>(c => c.Create());
        }

        [Test]
        public void CreateWithInputModelInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<HotelsController>(c => c.Create(null));
        }

        [Test]
        public void EditInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels/Edit/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<HotelsController>(c => c.Edit(id));
        }

        [Test]
        public void EditWithEditModelInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels/Edit";
            this.routeCollection
                .ShouldMap(url)
                .To<HotelsController>(c => c.Edit(null));
        }

        [Test]
        public void DeleteInHotelsControllerRoute()
        {
            var url = "/Administration/Hotels/Delete/{0}";
            var id = 1;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<HotelsController>(c => c.Delete(id));
        }
    }
}
