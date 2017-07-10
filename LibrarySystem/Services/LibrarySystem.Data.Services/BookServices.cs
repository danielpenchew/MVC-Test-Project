using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services
{
    public class BookServices : IBookServices
    {
        private readonly ILibrarySystemEfWrapper<Book> bookWrapper;
        private readonly ILibrarySystemEfDbContextSaveChanges librarySystemEfDbContextSaveChanges;

        public BookServices(ILibrarySystemEfWrapper<Book> bookWrapper, ILibrarySystemEfDbContextSaveChanges librarySystemEfDbContextSaveChanges)
        {
            Guard.WhenArgument(bookWrapper, "bookWrapper").IsNull().Throw();
            Guard.WhenArgument(librarySystemEfDbContextSaveChanges, "librarySystemEfDbContextSaveChanges").IsNull().Throw();

            this.bookWrapper = bookWrapper;
            this.librarySystemEfDbContextSaveChanges = librarySystemEfDbContextSaveChanges;
        }

        public void AddBook(Book book)
        {
            Guard.WhenArgument(book, "book").IsNull().Throw();

            this.bookWrapper.Add(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Book> GetAllBooks()
        {
            return this.bookWrapper.All();
        }

        public void DeleteBook(Book book)
        {
            Guard.WhenArgument(book, "book").IsNull().Throw();

            this.bookWrapper.Delete(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteBookById(object id)
        {
            Guard.WhenArgument(id, nameof(id)).IsNull().Throw();

            this.bookWrapper.Delete((Guid)id);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public Book GetById(Guid? id)
        {
            return this.bookWrapper.GetById(id);
        }

        public void UpdateBook(Book book)
        {
            this.bookWrapper.Update(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }
    }
}
