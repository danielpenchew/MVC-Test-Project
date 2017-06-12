using LibrarySytem.Data.Models.Models;
using System;

namespace LibrarySystem.Data.Services.Contracts
{
    public interface IBookServices
    {
        void AddBook(Book book);

        void DeleteBook(Book book);

        void DeleteBookById(Guid id);

        Book GetById(Guid id);

        void CreateBook(Book book);

        void UpdateBook(Book book);
    }
}