namespace HotelSystem.Web.Areas.Profile.Controllers
{
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Profile.ViewModels.Info;
    using HotelSystem.Web.Infrastructure.Mapping;

    using Microsoft.AspNet.Identity;

    public class InfoController : AuthorizeController
    {
        private IUsersService users;
        private IBookingsService bookings;

        public InfoController(IUsersService usersService, IBookingsService bookingsService)
        {
            this.users = usersService;
            this.bookings = bookingsService;
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            var mappedUser = this.Mapper.Map<UserViewModel>(user);
            var bookingsFormUser = this.bookings
                .BookingByEmail(user.Email)
                .To<BookingViewModel>();
            var viewModel = new InfoViewModel()
            {
                User = mappedUser,
                Bookings = bookingsFormUser
            };

            return this.View(viewModel);
        }
    }
}
