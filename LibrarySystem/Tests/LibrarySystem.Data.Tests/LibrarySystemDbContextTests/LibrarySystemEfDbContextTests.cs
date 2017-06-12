using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using NUnit.Framework;
using System.Data.Entity;

namespace LibrarySystem.Data.Tests.LibrarySystemDbContextTests
{
    [TestFixture]
    public class LibrarySystemEfDbContextTests
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new LibrarySystemEfDbContext();

            // Assert
            Assert.IsInstanceOf<LibrarySystemEfDbContext>(context);
        }

        [Test]
        public void Authors_ShouldBeInstanceOfIDbSet()
        {
            // Arrange & Act
            var context = new LibrarySystemEfDbContext();
            var authors = context.Authors;

            // Assert
            Assert.IsInstanceOf<IDbSet<Author>>(authors);
        }

        [Test]
        public void Books_ShouldBeInstanceOfIDbSet()
        {
            // Arrange & Act
            var context = new LibrarySystemEfDbContext();
            var books = context.Books;

            // Assert
            Assert.IsInstanceOf<IDbSet<Book>>(books);
        }

        [Test]
        public void Create_Should_ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = LibrarySystemEfDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<ILibrarySystemEfDbContext>(newContext);
        }
    }
}
