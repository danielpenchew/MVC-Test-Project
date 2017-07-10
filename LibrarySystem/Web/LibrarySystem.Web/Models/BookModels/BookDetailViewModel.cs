using LibrarySytem.Data.Models.Models;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookDetailViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public IEnumerable<BookImageViewModel> BookImages { get; set; }
    }
}