namespace HotelSystem.Services.Data
{
    using System;
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    using Microsoft.AspNet.Identity;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public void CreateUser(User user, string password)
        {
            user.PasswordHash = new PasswordHasher().HashPassword(password);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = user.Email;
            this.users.Add(user);
            this.users.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetAllWithDeleted()
        {
            return this.users.AllWithDeleted();
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public void Update()
        {
            this.users.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = this.users.GetById(id);
            if (user == null)
            {
                throw new NullReferenceException("There no user with given id in database!");
            }

            this.users.Delete(user);
            this.users.SaveChanges();
        }
    }
}
