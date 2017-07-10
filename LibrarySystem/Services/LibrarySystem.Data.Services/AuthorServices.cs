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
        private readonly ILibrarySystemEfWrapper<Author> authorWrapper;

        public AuthorServices(ILibrarySystemEfWrapper<Author> authorWrapper)
        {
            Guard.WhenArgument(authorWrapper, "authorWrapper").IsNull().Throw();

            this.authorWrapper = authorWrapper;
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return this.authorWrapper.All();
        }

        public Author GetById(Guid? id)
        {
            return this.authorWrapper.GetById(id);
        }
    }
}
