using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
    }
}