using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services.Contracts
{
    public interface IBookServices
    {
        void AddBook(Book book);

        void DeleteBook(Book book);

        void DeleteBookById(object id);

        Book GetById(Guid id);

        IQueryable<Book> GetAllBooks();

        void UpdateBook(Book book);
    }
}