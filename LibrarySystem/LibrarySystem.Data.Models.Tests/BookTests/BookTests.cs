using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models.Tests.BookTests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            Book book = new Book();

            // Assert
            Assert.IsInstanceOf<Book>(book);
        }

        [TestCase("Dependency Injection")]
        [TestCase("Harry Potter")]
        public void Title_ShouldGetAndSetDataCorrectly(string title)
        {
            // Arrange & Act
            Book book = new Book() { Title = title };

            // Assert
            Assert.AreEqual(title, book.Title);
        }

        [TestCase("Dependency Injection")]
        [TestCase("Harry Potter")]
        public void Description_ShouldGetAndSetDataCorrectly(string description)
        {
            // Arrange & Act
            Book book = new Book() { Description = description };

            // Assert
            Assert.AreEqual(description, book.Description);
        }

        [Test]
        public void AuthorID_ShouldReturnCorrectData()
        {
            // Arrange & Act
            var authorId = Guid.NewGuid();
            Book book = new Book() { AuthorId = authorId };
            Author author = new Author() { Id = authorId };

            // Assert
            Assert.AreEqual(book.AuthorId, author.Id);
        }

        [Test]
        public void UserId_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            var userId = string.Empty;
            Book book = new Book() { UserId = userId };
            User user = new User() { Id = userId };

            // Assert
            Assert.AreEqual(book.UserId, user.Id);
        }

        [Test]
        public void Author_ShouldReturnCorrectData()
        {
            // Arrange & Act
            Author author = new Author();
            Book book = new Book() { Author = author };

            // Assert
            Assert.AreSame(author, book.Author);
        }

        [Test]
        public void User_ShouldReturnCorrectData()
        {
            // Arrange & Act
            User user = new User();
            Book book = new Book() { User = user };

            // Assert
            Assert.AreSame(user, book.User);
        }

        [Test]
        public void Images_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            var id = Guid.NewGuid();
            var image = new Image() { Id = id };
            var set = new HashSet<Image>() { image };
            Book book = new Book() { Images = set };

            // Assert
            Assert.AreEqual(book.Images.First().Id, image.Id);
        }
    }
}
