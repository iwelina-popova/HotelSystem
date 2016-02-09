﻿using HotelSystem.Data;
using HotelSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new HotelSystemDbContext();
            var usersCount = db.Users.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}