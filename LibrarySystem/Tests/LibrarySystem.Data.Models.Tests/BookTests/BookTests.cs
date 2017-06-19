using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

        [Test]
        public void Id_ShouldSetDataCorrectly()
        {
            // Arrange & Act
            Guid id = Guid.NewGuid();
            Book book = new Book() { Id = id };

            // Assert
            Assert.AreEqual(book.Id, id);
        }

        [TestCase("Dependency Injection")]
        [TestCase("Harry Potter")]
        public void Title_ShouldGetAndSetDataCorrectly(string title)
        {
            // Arrange & Act
            Book book = new Book() { Title = title };

            // Assert
            Assert.AreEqual(book.Title, title);
        }

        [TestCase("Awesome book")]
        [TestCase("Little Juggler")]
        public void Description_ShouldGetAndSetDataCorrectly(string description)
        {
            // Arrange & Act
            Book book = new Book() { Description = description };

            // Assert
            Assert.AreEqual(book.Description, description);
        }

        [Test]
        public void AuthorId_ShouldSetDataCorrectly()
        {
            // Arrange & Act
            Guid authorId = Guid.NewGuid();
            Author author = new Author() { Id = authorId };
            Book book = new Book() { AuthorId = authorId };

            // Assert
            Assert.AreEqual(author.Id, book.AuthorId);
        }

        [Test]
        public void UserId_ShouldSetDataCorrectly()
        {
            // Arrange & Act
            string userId = string.Empty;
            User user = new User() { Id = userId };
            Book book = new Book() { UserId = userId };

            // Assert
            Assert.AreEqual(user.Id, book.UserId);
        }

        [Test]
        public void Author_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            Author author = new Author();
            Book book = new Book() { Author = author };

            // Assert
            Assert.AreSame(author, book.Author);
        }

        [Test]
        public void User_ShouldGetAndSetDataCorrectly()
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
            HashSet<Image> imagesSet = new HashSet<Image>();
            Book book = new Book() { Images = imagesSet };

            // Assert
            Assert.AreSame(book.Images, imagesSet);
        }
    }
}
