using LibrarySytem.Data.Models.Models;
using System;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookDetailViewModel
    {
        public BookDetailViewModel(Book book)
        {
            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.Description = book.Description;
                this.Author = book.Author;
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public string UserId { get; set; }
    }
}