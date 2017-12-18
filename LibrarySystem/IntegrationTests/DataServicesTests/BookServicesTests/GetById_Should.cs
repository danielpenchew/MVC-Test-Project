using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Migrations;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataServicesTests.BookServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        private static Author author = new Author()
        {
            FirstName = "AuthorFirst",
            LastName = "AuthorLast"
        };

        private static User user = new User()
        {
            UserName = "Pesho Peshov"
        };

        private static Author author2 = new Author()
        {
            FirstName = "AuthorFirst1",
            LastName = "AuthorLast1"
        };

        private static User user2 = new User()
        {
            UserName = "Pesho Peshov1"
        };

        //private static Book dbModel = new Book()
        //{
        //    Title = "IntTestTitle1",
        //    Description = "IntTestDesc1",
        //    Author = author,
        //    AuthorId = author.Id,
        //    User = user,
        //    UserId = user.Id
        //};

        private static ICollection<Book> books = new List<Book>()
        {
            new Book()
            {
                Title = "Title",
                Description = "Description",
                Author = author,
                AuthorId = author.Id,
                User = user,
                UserId = user.Id
            },

            new Book()
            {
                Title = "Title 1",
                Description = "Description 1",
                Author = author2,
                AuthorId = author2.Id,
                User = user2,
                UserId = user2.Id
            }
        };
        
        private static LibrarySystemEfDbContext dbContext = new LibrarySystemEfDbContext();

        [SetUp()]
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemEfDbContext, Configuration>());
            LibrarySystemEfDbContext.Create().Database.CreateIfNotExists();

            //dbContext.Books.Add(dbModel);
            //dbContext.SaveChanges();

            //dbModel = dbContext.Books.Single();

            foreach (var book in books)
            {
                dbContext.Books.Add(book);
            }

            dbContext.SaveChanges();

            books = dbContext.Books.ToList();
        }

        [TearDown]
        public static void Cleanup()
        {
            foreach (var book in books)
            {
                dbContext.Books.Attach(book);
                dbContext.Books.Remove(book);
            }
            foreach (var author in dbContext.Authors)
            {
                dbContext.Authors.Attach(author);
                dbContext.Authors.Remove(author);
            }
            foreach (var user in dbContext.Users)
            {
                dbContext.Users.Attach(user);
                dbContext.Users.Remove(user);
            }

            //dbContext.Books.Attach(dbModel);
            //dbContext.Books.Remove(dbModel);
            //dbContext.Authors.Remove(author);
            //dbContext.Users.Remove(user);

            dbContext.SaveChanges();
        }

        [Test]
        public void Return_Book_With_Proper_Id()
        {
            // Arrange
            ILibrarySystemEfWrapper<Book> repository = new LibrarySystemEfWrapper<Book>(dbContext);
            ILibrarySystemEfDbContextSaveChanges saveChanges = new LibrarySystemEfDbContextSaveChanges(dbContext);

            IBookServices bookServices = new BookServices(repository, saveChanges);

            // Act
            Book result = bookServices.GetById(books.FirstOrDefault().Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, books.FirstOrDefault().Id);
        }
    }
}
