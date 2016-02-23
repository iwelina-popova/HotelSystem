namespace HotelSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IHotelRoomsService
    {
        IQueryable<HotelRoom> GetAllRoomsInHotel(int hotelId);

        IQueryable<HotelRoom> GetUniqueRoomTypesInHotel(int hotelId);

        IQueryable<HotelRoom> GetAllFreeRoomsInHotelForPeriod(int hotelId, int capacity, DateTime from, DateTime to);

        IQueryable<HotelRoom> GetAllFreeRoomsInHotel(int hotelId, int roomId);

        HotelRoom FreeHotelRoom(string hotelName, RoomType type);

        HotelRoom FreeHotelRoom(int hotelId, int roomId);

        void Update();
    }
}
