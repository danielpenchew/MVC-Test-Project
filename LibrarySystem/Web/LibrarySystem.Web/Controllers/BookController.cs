using LibrarySystem.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices bookServices;

        public ActionResult Create()
        {
            return View();
        }
    }
}