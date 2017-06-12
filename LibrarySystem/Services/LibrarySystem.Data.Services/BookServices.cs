using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using System;

namespace LibrarySystem.Data.Services
{
    public class BookServices : IBookServices
    {
        private readonly ILibrarySystemEfDataProvider<Book> bookDataProvider;
        private readonly ILibrarySystemEfDbContextSaveChanges librarySystemEfDbContextSaveChanges;

        public BookServices(ILibrarySystemEfDataProvider<Book> bookDataProvider, ILibrarySystemEfDbContextSaveChanges librarySystemEfDbContextSaveChanges)
        {
            Guard.WhenArgument(bookDataProvider, "bookDataProvider").IsNull().Throw();
            Guard.WhenArgument(librarySystemEfDbContextSaveChanges, "librarySystemEfDbContextSaveChanges").IsNull().Throw();

            this.bookDataProvider = bookDataProvider;
            this.librarySystemEfDbContextSaveChanges = librarySystemEfDbContextSaveChanges;
        }

        public void AddBook(Book book)
        {
            Guard.WhenArgument(book, "book").IsNull().Throw();

            this.bookDataProvider.Add(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            Guard.WhenArgument(book, "book").IsNull().Throw();

            this.bookDataProvider.Delete(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteBookById(object id)
        {
            Guard.WhenArgument(id, nameof(id)).IsNull().Throw();

            this.bookDataProvider.Delete((Guid)id);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }

        public Book GetById(Guid id)
        {
            return this.bookDataProvider.GetById(id);
        }

        public void UpdateBook(Book book)
        {
            this.bookDataProvider.Update(book);
            this.librarySystemEfDbContextSaveChanges.SaveChanges();
        }
    }
}
