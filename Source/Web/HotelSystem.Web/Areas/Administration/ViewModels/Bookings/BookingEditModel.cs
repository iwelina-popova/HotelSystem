namespace HotelSystem.Web.Areas.Administration.ViewModels.Bookings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Web.Infrastructure.Mapping;

    public class BookingEditModel : IMapFrom<HotelSystem.Data.Models.Booking>
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Booked from")]
        public DateTime BookedFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Booked to")]
        public DateTime BookedTo { get; set; }
    }
}
