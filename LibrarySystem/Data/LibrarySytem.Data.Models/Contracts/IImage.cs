using LibrarySytem.Data.Models.Models;
using System;

namespace LibrarySytem.Data.Models.Contracts
{
    public interface IImage
    {
        Guid Id { get; set; }

        string Title { get; set; }

        byte[] ImageData { get; set; }

        Guid? BookId { get; set; }

        Book Book { get; set; }
    }
}
