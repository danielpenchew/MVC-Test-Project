using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models.Tests.UserTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            User user = new User();

            // Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectlyBooksCollection()
        {
            // Arrange & Act
            User user = new User();
            var books = user.Books;

            // Assert
            Assert.That(books, Is.Not.Null.And.InstanceOf<HashSet<Book>>());
        }

        [Test]
        public void BookId_ShouldGetDataCorrectly()
        {
            // Arrange & Act
            Guid id = Guid.NewGuid();
            Book book = new Book() { Id = id };
            var set = new HashSet<Book>() { book };
            User user = new User() { Books = set };

            // Assert
            Assert.AreEqual(user.Books.First().Id, book.Id);
        }
    }
}
