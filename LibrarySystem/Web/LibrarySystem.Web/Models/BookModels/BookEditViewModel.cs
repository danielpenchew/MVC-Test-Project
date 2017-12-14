using LibrarySytem.Data.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookEditViewModel
    {
        public BookEditViewModel()
        {
        }

        public BookEditViewModel(Book book)
        {
            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.Description = book.Description;
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }
    }
}