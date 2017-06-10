using LibrarySytem.Data.Models.Models;
using System;
using System.Collections.Generic;

namespace LibrarySytem.Data.Models.Contracts
{
    public interface IAuthor
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        ICollection<Book> Books { get; set; }
    }
}
