using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(HotelSystem.Web.Startup))]

namespace HotelSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
