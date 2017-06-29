using System;
using System.Collections.Generic;
using LibrarySytem.Data.Models.Models;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<BookImageViewModel> FilesForUpload { get; set; }
    }
}