using Bytes2you.Validation;
using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Infrastucture.Contracts;
using LibrarySystem.Web.Models.BookModels;
using LibrarySytem.Data.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;
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
        private readonly IMappingService mappingService;

        public BookController()
        {
        }

        public BookController(IBookServices bookServices, IMappingService mappingService)
        {
            Guard.WhenArgument(bookServices, "bookServices").IsNull().Throw();
            Guard.WhenArgument(mappingService, "mappingService").IsNull().Throw();

            this.bookServices = bookServices;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(BookCreateViewModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                AuthorId = model.Author.Id,
                Description = model.Description,
                //UserId = this.User.Identity.GetUserId()
            };

            try
            {
                book.Title = Sanitizer.GetSafeHtmlFragment(model.Title);
                book.Description = Sanitizer.GetSafeHtmlFragment(model.Description);
                this.bookServices.CreateBook(book);
            }
            catch (Exception e)
            {
                this.TempData["Notification"] = "Exception.";
                return View(model);
            }

            this.TempData["Notification"] = "Succesfully created a book!";

            return Redirect("/");
        }
    }
}