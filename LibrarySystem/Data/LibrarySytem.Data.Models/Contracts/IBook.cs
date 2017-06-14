using LibrarySytem.Data.Models.Models;
using System;
using System.Collections.Generic;

namespace LibrarySytem.Data.Models.Contracts
{
    public interface IBook
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid AuthorId { get; set; }

        Author Author { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        ICollection<Image> Images { get; set; }
    }
}
