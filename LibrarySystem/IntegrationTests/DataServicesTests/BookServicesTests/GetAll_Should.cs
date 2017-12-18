using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Migrations;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace DataServicesTests.BookServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        private static Author author = new Author()
        {
            FirstName = "AuthorFirst2",
            LastName = "AuthorLast2"
        };

        private static User user = new User()
        {
            UserName = "Pesho Peshov2"
        };

        private static Book dbModel = new Book()
        {
            Title = "Title 2",
            Description = "Description 2",
            Author = author,
            AuthorId = author.Id,
            User = user,
            UserId = user.Id
        };

        private static LibrarySystemEfDbContext dbContext = new LibrarySystemEfDbContext();

        [SetUp()]
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemEfDbContext, Configuration>());
            LibrarySystemEfDbContext.Create().Database.CreateIfNotExists();

            dbContext.Books.Add(dbModel);
            dbContext.SaveChanges();

            dbModel = dbContext.Books.Single();
        }

        [TearDown]
        public static void Cleanup()
        {
            dbContext.Books.Attach(dbModel);
            dbContext.Books.Remove(dbModel);
            dbContext.Authors.Remove(author);
            dbContext.Users.Remove(user);

            dbContext.SaveChanges();
        }

        [Test]
        public void GetAll_Should_Return_Proper_Collection()
        {
            // Arrange
            ILibrarySystemEfWrapper<Book> repository = new LibrarySystemEfWrapper<Book>(dbContext);
            ILibrarySystemEfDbContextSaveChanges saveChanges = new LibrarySystemEfDbContextSaveChanges(dbContext);

            IBookServices bookServices = new BookServices(repository, saveChanges);

            // Act
            IQueryable<Book> result = bookServices.GetAllBooks();

            // Assert
            Assert.AreEqual(result, dbContext.Books);
        }
    }
}
