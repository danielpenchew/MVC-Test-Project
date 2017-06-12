using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySytem.Data.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace LibrarySystem.Data.Tests.LibrarySystemDataProviderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedContextIsNull()
        {
            // Arrange
            ILibrarySystemEfDbContext context = null;

            // Act & Assert
            Assert.That(() => new LibrarySystemEfDataProvider<IBook>(context),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("context"));
        }

        [Test]
        public void Constructor_Should_WorkCorrectly_IfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<ILibrarySystemEfDbContext>();
            var mockedModel = new Mock<DbSet<IBook>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IBook>()).Returns(mockedModel.Object);
            var mockedDbSet = new LibrarySystemEfDataProvider<IBook>(mockedDbContext.Object);

            // Assert
            Assert.That(mockedDbSet, Is.Not.Null);
        }
    }
}
