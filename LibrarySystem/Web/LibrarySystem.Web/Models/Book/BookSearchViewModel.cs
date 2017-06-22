using System;

namespace LibrarySystem.Web.Models.Book
{
    public class BookSearchViewModel
    {
        public Guid? AuthorId { get; set; }

        public string Title { get; set; }
    }
}