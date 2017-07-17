﻿using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AllBooks", "Book");
            }

            return View();
        }
    }
}