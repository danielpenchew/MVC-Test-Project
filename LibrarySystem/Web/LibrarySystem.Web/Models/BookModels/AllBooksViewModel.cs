using System.Collections.Generic;

namespace LibrarySystem.Web.Models.BookModels
{
    public class AllBooksViewModel
    {
        public ICollection<BookDetailViewModel> AllBooks { get; set; }
    }
}