using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services.Contracts
{
    public interface IImageServices
    {
        IQueryable<Image> GetImagesByBookId(Guid bookId);

        Image GetById(Guid? id);
    }
}
