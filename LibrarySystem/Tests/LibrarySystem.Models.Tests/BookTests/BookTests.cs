using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models.Tests.BookTests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("Daniel")]
        [TestCase("Michael")]
        public void Title_ShouldSetDataCorrectly(string testTitle)
        {
            // Arrange & Act
            Book book = new Book() { Title = testTitle };

            // Assert
            Assert.AreEqual(book.Title, testTitle);
        }

        [TestCase("Daniel")]
        [TestCase("Michael")]
        public void Description_ShouldSetDataCorrectly(string testDescription)
        {
            // Arrange & Act
            Book book = new Book() { Description = testDescription };

            // Assert
            Assert.AreEqual(book.Description, testDescription);
        }

        [Test]
        public void AuthorId_ShouldReturnCorrectValue()
        {
            // Arrange & Act
            Guid id = Guid.NewGuid();
            Author author = new Author() { Id = id };
            Book book = new Book() { AuthorId = author.Id };

            // Assert
            Assert.AreEqual(author.Id, book.AuthorId);
        }

        [Test]
        public void AuthorProperty_ShouldReturnInstanceOfAuthor()
        {
            // Arrange & Act
            Author author = new Author();
            Book book = new Book() { Author = author };

            // Assert
            Assert.IsInstanceOf<Author>(book.Author);
        }

        [Test]
        public void UserProperty_ShouldReturnInstanceOfUser()
        {
            // Arrange & Act
            User user = new User();
            Book book = new Book() { User = user };

            // Assert
            Assert.IsInstanceOf<User>(book.User);
        }
    }
}
