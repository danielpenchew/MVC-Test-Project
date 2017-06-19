using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models.Tests.AuthorTests
{
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            Author author = new Author();

            // Assert
            Assert.IsInstanceOf<Author>(author);
        }

        [Test]
        public void Id_ShouldSetDataCorrectly()
        {
            // Arrange & Act
            Guid id = Guid.NewGuid();
            Author author = new Author() { Id = id };

            // Assert
            Assert.AreEqual(author.Id, id);
        }

        [TestCase("Vettel")]
        [TestCase("Hamilton")]
        public void FirstName_ShouldSetDataCorrectly(string firstName)
        {
            // Arrange & Act
            Author author = new Author() { FirstName = firstName };

            // Assert
            Assert.AreEqual(author.FirstName, firstName);
        }

        [TestCase("Vettel")]
        [TestCase("Hamilton")]
        public void LastName_ShouldSetDataCorrectly(string lastName)
        {
            // Arrange & Act
            Author author = new Author() { LastName = lastName };

            // Assert
            Assert.AreEqual(author.LastName, lastName);
        }

        [Test]
        public void Books_ShouldSetDataCorrectly()
        {
            // Arrange & Act
            Book book = new Book();
            HashSet<Book> booksSet = new HashSet<Book>() { book };
            Author author = new Author() { Books = booksSet };

            // Assert
            Assert.AreEqual(author.Books, booksSet);
        }
    }
}
