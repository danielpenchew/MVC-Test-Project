using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Tests.LibrarySystemEfDbContextSaveChangesTests
{
    [TestFixture]
    public class LibrarySystemEfDbContextSaveChangesTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            ILibrarySystemEfDbContext context = null;

            // Act & Assert
            Assert.That(
                () => new LibrarySystemEfDbContextSaveChanges(context),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("context"));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenContextIsNotNull()
        {
            // Arrange
            var contextMock = new Mock<ILibrarySystemEfDbContext>();
            var librarySytemEfDbContextSaveChanges = new LibrarySystemEfDbContextSaveChanges(contextMock.Object);

            // Act & Assert
            Assert.That(librarySytemEfDbContextSaveChanges, Is.Not.Null);
        }

        [Test]
        public void SaveChanges_ShouldBeCalledOnce()
        {
            // Arrange
            var contextMock = new Mock<ILibrarySystemEfDbContext>();
            var contextSaveChanges = new LibrarySystemEfDbContextSaveChanges(contextMock.Object);

            // Act
            contextSaveChanges.SaveChanges();

            // Assert
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
