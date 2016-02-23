namespace HotelSystem.Web.Areas.Administration.ViewModels.Bookings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using HotelSystem.Web.Infrastructure.Mapping;

    public class BookingViewModel : IMapFrom<HotelSystem.Data.Models.Booking>, IHaveCustomMappings
    {
        [Required]
        public int Id { get; set; }

        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public string HotelName { get; set; }

        public string RoomNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HotelSystem.Data.Models.Booking, BookingViewModel>()
                .ForMember(m => m.HotelName, opt => opt.MapFrom(m => m.HotelRooms.Hotel.Name))
                .ForMember(m => m.RoomNumber, opt => opt.MapFrom(m => m.HotelRooms.RoomNumber));
        }
    }
}
