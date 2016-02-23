using HotelSystem.Web.Areas.Administration;
using HotelSystem.Web.Areas.Administration.Controllers;
using HotelSystem.Web.Areas.Administration.ViewModels.Users;
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
    public class AdministrationAreaUsersRouteTests
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
        public void DefaultInUsersControllerRoute()
        {
            var url = "/Administration/Users";
            this.routeCollection
                .ShouldMap(url)
                .To<UsersController>(c => c.Index());
        }

        [Test]
        public void CreateInUsersControllerRoute()
        {
            var url = "/Administration/Users/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<UsersController>(c => c.Create());
        }

        [Test]
        public void CreateWithInputModelInUsersControllerRoute()
        {
            var url = "/Administration/Users/Create";
            this.routeCollection
                .ShouldMap(url)
                .To<UsersController>(c => c.Create(null));
        }

        [Test]
        public void EditInUsersControllerRoute()
        {
            var url = "/Administration/Users/Edit/{0}";
            string id = "some";
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<UsersController>(c => c.Edit(id));
        }

        [Test]
        public void EditWithEditModelInUsersControllerRoute()
        {
            var url = "/Administration/Users/Edit";
            this.routeCollection
                .ShouldMap(url)
                .To<UsersController>(c => c.Edit((UserEditModel)null));
        }

        [Test]
        public void DeleteInUsersControllerRoute()
        {
            var url = "/Administration/Users/Delete/{0}";
            string id = "some";
            this.routeCollection
                .ShouldMap(string.Format(url, id))
                .To<UsersController>(c => c.Delete(id));
        }
    }
}
