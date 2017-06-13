using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System;

namespace LibrarySystem.Data.Services.Tests.BookServicesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateBookService_IfParametersAreValid()
        {
            // Arrange & Act
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();
            var bookServices = new BookServices(dbSetMock.Object, saveChangesMock.Object);

            // Assert
            Assert.That(bookServices, Is.Not.Null.And.InstanceOf<BookServices>());
        }

        [Test]
        public void Throw_ArgumentNullException_IfPassedDbSetIsNull()
        {
            // Arrange
            ILibrarySystemEfWrapper<Book> nullDbSet = null;
            var saveChangesMock = new Mock<ILibrarySystemEfDbContextSaveChanges>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BookServices(nullDbSet, saveChangesMock.Object));
        }

        [Test]
        public void Throw_NullReferenceException_WhenSaveChangesIsNull()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Book>>();
            Mock<ILibrarySystemEfDbContextSaveChanges> saveChangesNull = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new BookServices(dbSetMock.Object, saveChangesNull.Object));
        }
    }
}
