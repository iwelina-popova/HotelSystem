namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Parking : BaseModel<int>
    {
        public bool Free { get; set; }

        public decimal? Price { get; set; }
    }
}
