namespace HotelSystem.Services.Data
{
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Services.Web;

    public class HotelsService : IHotelsService
    {
        private readonly IDbRepository<Hotel> hotels;
        private readonly IIdentifierProvider identifierProvider;

        public HotelsService(IDbRepository<Hotel> hotels, IIdentifierProvider identifierProvider)
        {
            this.hotels = hotels;
            this.identifierProvider = identifierProvider;
        }

        public void CreateHotel(Hotel hotel)
        {
            this.hotels.Add(hotel);
            this.hotels.SaveChanges();
        }

        public IQueryable<Hotel> GetAll()
        {
            return this.hotels.All();
        }

        public IQueryable<Hotel> GetAllWithDeleted()
        {
            return this.hotels.AllWithDeleted();
        }

        public Hotel GetById(int id)
        {
            return this.hotels.GetById(id);
        }

        public void Update()
        {
            this.hotels.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = this.hotels.GetById(id);
            this.hotels.Delete(hotel);
            this.hotels.SaveChanges();
        }
    }
}
