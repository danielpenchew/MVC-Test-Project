using Bytes2you.Validation;
using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Models.BookModels;
using LibrarySytem.Data.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices bookServices;
        
        public BookController(IBookServices bookServices)
        {
            Guard.WhenArgument(bookServices, "bookServices").IsNull().Throw();

            this.bookServices = bookServices;
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
                UserId = this.User.Identity.GetUserId()
            };

            try
            {
                book.Title = Sanitizer.GetSafeHtmlFragment(model.Title);
                book.Description = Sanitizer.GetSafeHtmlFragment(model.Description);
                this.bookServices.AddBook(book);
            }
            catch (Exception)
            {
                this.TempData["Notification"] = "Exception.";
                return View(model);
            }

            this.TempData["Notification"] = "Succesfully created a book!";

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            var book = this.bookServices.GetById(id);

            var viewModel = new BookDetailViewModel(book);

            return View(viewModel);
        }
    }
}