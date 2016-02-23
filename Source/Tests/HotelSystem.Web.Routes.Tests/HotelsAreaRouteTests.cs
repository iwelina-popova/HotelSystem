using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Routing;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystem.Web.Areas.Hotels;
using System.Web.Mvc;
using MvcRouteTester;
using HotelSystem.Web.Areas.Hotels.Controllers;

namespace HotelSystem.Web.Routes.Tests
{
    [TestFixture]
    public class HotelsAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var registerArea = new HotelsAreaRegistration();
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
        public void DefaultHotelsAreaRoute()
        {
            var url = "/Hotels";
            this.routeCollection
                .ShouldMap(url)
                .To<AllController>(c => c.Index());
        }

        //[Test]
        //public void HotelsAreaHotelDetailsRouteWithoutId()
        //{
        //    var url = "/Hotels/Details/HotelDetails";
        //    var id = 1;
        //    this.routeCollection
        //        .ShouldMap(url)
        //        .To<DetailsController>(c => c.HotelDetails());
        //}

        [Test]
        public void HotelsAreaHotelDetailsRouteWithId()
        {
            var url = "/Hotels/Details/HotelDetails/{0}";
            var id = 2;
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<DetailsController>(c => c.HotelDetails(id));
        }
    }
}
