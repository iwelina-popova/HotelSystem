using HotelSystem.Web.Areas.Profile;
using HotelSystem.Web.Areas.Profile.Controllers;
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
    public class ProfileAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area5Reg = new ProfileAreaRegistration();
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
        public void DefaultInfoControllerRoute()
        {
            var url = "/Profile/Info";
            this.routeCollection
                .ShouldMap(url)
                .To<InfoController>(c => c.Index());
        }
    }
}
