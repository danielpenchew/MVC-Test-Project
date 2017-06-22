using System;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.Book
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }

        public Guid AuthorId { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<BookImageViewModel> FilesForUpload { get; set; }
    }
}