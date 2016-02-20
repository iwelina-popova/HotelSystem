namespace HotelSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;

    using HotelSystem.Services.Web;
    using HotelSystem.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
