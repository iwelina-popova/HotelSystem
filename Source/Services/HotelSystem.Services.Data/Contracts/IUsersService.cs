namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IUsersService
    {
        void CreateUser(User user, string password);

        IQueryable<User> GetAll();

        IQueryable<User> GetAllWithDeleted();

        User GetById(string id);

        void Update();

        void Delete(string id);
    }
}
