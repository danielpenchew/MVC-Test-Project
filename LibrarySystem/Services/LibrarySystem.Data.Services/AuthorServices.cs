using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly ILibrarySystemEfDataProvider<Author> authorDataProvider;

        public AuthorServices(ILibrarySystemEfDataProvider<Author> authorDataProvider)
        {
            Guard.WhenArgument(authorDataProvider, "authorDataProvider").IsNull().Throw();

            this.authorDataProvider = authorDataProvider;
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return this.authorDataProvider.All();
        }

        public Author GetById(Guid id)
        {
            return this.authorDataProvider.GetById(id);
        }
    }
}
