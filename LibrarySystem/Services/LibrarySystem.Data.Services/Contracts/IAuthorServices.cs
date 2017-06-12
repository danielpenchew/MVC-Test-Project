using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services.Contracts
{
    public interface IAuthorServices
    {
        IQueryable<Author> GetAllAuthors();

        Author GetById(Guid id);
    }
}
