using LibrarySystem.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySytem.Data.Models.Models;
using LibrarySystem.Data.Contracts;

namespace LibrarySystem.Data.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly ILibrarySystemEfDataProvider<Author> authorDataProvider;

        public AuthorServices(ILibrarySystemEfDataProvider<Author> authorDataProvider)
        {
            Guard
        }

        public IQueryable<Author> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Author GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
