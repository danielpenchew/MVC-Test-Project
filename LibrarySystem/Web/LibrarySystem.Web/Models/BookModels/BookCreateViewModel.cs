using LibrarySytem.Data.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookCreateViewModel
    {
        public BookCreateViewModel()
        {
        }

        public BookCreateViewModel(Book book)
        {
            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.Author = book.Author;
                this.Description = book.Description;
                this.User = book.User;
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public Author Author { get; set; }

        [UIHint("MultilineText")]
        [AllowHtml]
        public string Description { get; set; }

        public User User { get; set; }
        
        //public IEnumerable<BookImageViewModel> FilesForUpload { get; set; }
    }
}