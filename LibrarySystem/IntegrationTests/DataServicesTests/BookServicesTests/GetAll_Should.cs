using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Linq;
using System.Transactions;

namespace DataServicesTests.BookServicesTests
{
    [TestFixture]
    public class GetAll_Should
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
        
        [Test]
        public void GetAll_Should_Return_Proper_Collection()
        {
            // Arrange
            IBookServices bookServices = new BookServices(repository, saveChanges);

            // Act
            IQueryable<Book> result = bookServices.GetAllBooks();

            // Assert
            Assert.AreEqual(result, dbContext.Books);
        }
    }
}
