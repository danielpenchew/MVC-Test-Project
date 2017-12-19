using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Transactions;

namespace DataServicesTests.BookServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        private TransactionScope trans = null;
        private static LibrarySystemEfDbContext dbContext = new LibrarySystemEfDbContext();
        ILibrarySystemEfWrapper<Book> repository = new LibrarySystemEfWrapper<Book>(dbContext);
        ILibrarySystemEfDbContextSaveChanges saveChanges = new LibrarySystemEfDbContextSaveChanges(dbContext);

        [SetUp]
        public void SetUp()
        {
            trans = new TransactionScope(TransactionScopeOption.Required);
        }

        [TearDown]
        public void TearDown()
        {
            trans.Dispose();
        }

        // Data setup 
        private static Author author = new Author()
        {
            FirstName = "Yolo",
            LastName = "Yolov"
        };

        private static User user = new User()
        {
            UserName = "User Userov"
        };

        private static Book book = new Book()
        {
            Title = "TransScope",
            Description = "TransDescription",
            Author = author,
            AuthorId = author.Id,
            User = user,
            UserId = user.Id
        };

        [Test]
        public void Return_Book_With_Proper_Id()
        {
            // Arrange
            IBookServices sut = new BookServices(repository, saveChanges);
            sut.AddBook(book);

            // Act
            Book result = sut.GetById(book.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, book.Id);
        }
    }
}
