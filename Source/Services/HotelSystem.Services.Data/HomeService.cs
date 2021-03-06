﻿namespace HotelSystem.Services.Data
{
    using System;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    public class HomeService : IHomeService
    {
        private IDbRepository<Contact> contacts;

        public HomeService(IDbRepository<Contact> contacts)
        {
            this.contacts = contacts;
        }

        public void AddContact(Contact contact)
        {
            this.contacts.Add(contact);
            this.contacts.SaveChanges();
        }
    }
}
