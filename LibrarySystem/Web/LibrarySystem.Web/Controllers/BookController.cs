using Bytes2you.Validation;
using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Models.BookModels;
using LibrarySytem.Data.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ActionResult Edit(Guid? id)
        {
            Book book = this.bookServices.GetById(id);
            BookEditViewModel viewModel = new BookEditViewModel(book);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookEditViewModel viewModel, Guid id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            Book book = this.bookServices.GetById(id);
            book.Title = viewModel.Title;
            book.Description = viewModel.Description;

            this.bookServices.UpdateBook(book);

            return Redirect("/");
        }

        public ActionResult Delete(Guid id)
        {
            Book book = this.bookServices.GetById(id);
            this.bookServices.DeleteBook(book);

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Detail(Guid? id)
        {
            Book book = this.bookServices.GetById(id);
            BookDetailViewModel viewModel = new BookDetailViewModel(book);

            return View(viewModel);
        }

        public ActionResult AllBooks()
        {
            string userId = this.User.Identity.GetUserId();
            List<Book> books = this.bookServices.GetAllBooks().Where(b => b.UserId == userId).ToList();
            AllBooksViewModel model = new AllBooksViewModel() { AllBooks = new Collection<BookDetailViewModel>() };

            foreach (var book in books)
            {
                BookDetailViewModel modelBook = new BookDetailViewModel(book)
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author
                };

                model.AllBooks.Add(modelBook);
            }

            return View(model);
        }
    }
}