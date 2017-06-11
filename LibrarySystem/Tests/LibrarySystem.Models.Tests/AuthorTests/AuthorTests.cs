using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibrarySystem.Models.Tests.AuthorTests
{
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void BooksCollection_Should_GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var book = new Book() { Id = Guid.NewGuid() };
            var set = new HashSet<Book> { book };
            var author = new Author() { Books = set };

            // Assert
            Assert.AreEqual(author.Books.First().Id, book.Id);
        }

        [Test]
        public void Constructor_ShouldSetIdCorrectly()
        {
            // Arrange & Act
            var id = Guid.NewGuid();
            Author author = new Author() { Id = id };

            // Assert
            Assert.AreEqual(author.Id, id);
        }

        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            Author author = new Author();

            // Assert
            Assert.IsInstanceOf<Author>(author);
        }

        [Test]
        public void Constructor_ShouldSetCorrectlyBooksCollection()
        {
            // Arrange & Act
            Author author = new Author();
            ICollection<Book> books = author.Books;

            // Assert
            Assert.That(books, Is.Not.Null.And.InstanceOf<HashSet<Book>>());
        }

        [Test]
        public void FirstNameProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var firstNameProp = typeof(Author).GetProperty("FirstName");

            // Act
            var requiredAttribute = firstNameProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var firstNameProp = typeof(Author).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), true)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute, Is.Not.Null);
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var firstNameProp = typeof(Author).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute, Is.Not.Null);
        }

        [TestCase("Daniel")]
        [TestCase("Michael")]
        public void FirstName_ShouldSetDataCorrectly(string testFirstName)
        {
            // Arrange & Act
            Author author = new Author() { FirstName = testFirstName };

            // Assert
            Assert.AreEqual(author.FirstName, testFirstName);
        }

        [Test]
        public void LastNameProperty_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var lastNameProp = typeof(Author).GetProperty("LastName");

            // Act
            var requiredAttribute = lastNameProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var lastNameProp = typeof(Author).GetProperty("LastName");

            // Act
            var minLengthAttribute = lastNameProp.GetCustomAttributes(typeof(MinLengthAttribute), true)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute, Is.Not.Null);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var lastNameProp = typeof(Author).GetProperty("LastName");

            // Act
            var minLengthAttribute = lastNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute, Is.Not.Null);
        }

        [TestCase("Daniel")]
        [TestCase("Michael")]
        public void LastName_ShouldSetDataCorrectly(string testLastName)
        {
            // Arrange & Act
            Author author = new Author() { LastName = testLastName };

            // Assert
            Assert.AreEqual(author.LastName, testLastName);
        }
    }
}
