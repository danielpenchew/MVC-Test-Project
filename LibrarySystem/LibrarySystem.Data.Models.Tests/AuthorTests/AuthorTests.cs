using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public void Constructor_ShouldSetCorrectId()
        {
            // Arrange & Act
            var id = Guid.NewGuid();
            Author author = new Author() { Id = id };

            // Assert
            Assert.AreEqual(id, author.Id);
        }

        [Test]
        public void Books_ShouldGetAndSetDataCorrectly()
        {
            // Arrange & Act
            var bookId = Guid.NewGuid();
            var book = new Book() { Id = bookId };
            var set = new HashSet<Book>() { book };
            var author = new Author() { Books = set };

            // Assert
            Assert.AreEqual(author.Books.First().Id, bookId);
        }

        [Test]
        public void PropertyFirstName_ShouldHaveRequiredAttribute()
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
            var nameProperty = typeof(Author).GetProperty("FirstName");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(2));
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Author).GetProperty("FirstName");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(20));
        }

        [TestCase("Daniel")]
        [TestCase("Hamilton")]
        public void FirstNameSetsCorrectValue(string firstName)
        {
            // Arrange & Act
            Author author = new Author() { FirstName = firstName };

            // Assert
            Assert.AreEqual(firstName, author.FirstName);
        }

        [TestCase("Daniel")]
        [TestCase("Hamilton")]
        public void LastNameSetsCorrectValue(string lastName)
        {
            // Arrange & Act
            Author author = new Author() { LastName = lastName };

            // Assert
            Assert.AreEqual(lastName, author.LastName);
        }
    }
}
