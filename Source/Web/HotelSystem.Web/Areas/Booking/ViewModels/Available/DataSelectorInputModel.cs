namespace HotelSystem.Web.Areas.Booking.ViewModels.Available
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;

    public class DataSelectorInputModel
    {
        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure { get; set; }

        [Required]
        [Display(Name = "Hotel name")]
        public string HotelName { get; set; }

        [Range(ModelConstraints.RoomMinCapacity, ModelConstraints.RoomMaxCapacity)]
        public int Capacity { get; set; }
    }
}
