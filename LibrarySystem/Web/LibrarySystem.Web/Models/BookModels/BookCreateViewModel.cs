using LibrarySytem.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibrarySystem.Web.Models.BookModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }
        
        public Author Author { get; set; }

        [UIHint("MultilineText")]
        [AllowHtml]
        public string Description { get; set; }

        public IEnumerable<BookImageViewModel> FilesForUpload { get; set; }
    }
}