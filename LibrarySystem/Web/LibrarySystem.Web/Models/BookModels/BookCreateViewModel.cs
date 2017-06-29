using LibrarySytem.Data.Models.Models;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }

        public Author Author { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<BookImageViewModel> FilesForUpload { get; set; }
    }
}