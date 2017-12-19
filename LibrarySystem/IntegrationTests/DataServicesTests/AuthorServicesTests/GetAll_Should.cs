using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Linq;
using System.Transactions;

namespace DataServicesTests.AuthorServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        private TransactionScope trans = null;
        private static LibrarySystemEfDbContext dbContext = new LibrarySystemEfDbContext();
        ILibrarySystemEfWrapper<Author> repository = new LibrarySystemEfWrapper<Author>(dbContext);

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
        Author author = new Author()
        {
            FirstName = "Yolo",
            LastName = "Yolov"
        };

        [Test]
        public void Return_Proper_Collection_Type_When_Called()
        {
            // Assert
            IAuthorServices sut = new AuthorServices(repository);

            // Act & Assert
            Assert.IsInstanceOf<IQueryable<Author>>(sut.GetAllAuthors());
        }
    }
}
