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
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var setMock = new Mock<DbSet<IBook>>();
            var dbContextMock = new Mock<ILibrarySystemEfDbContext>();
            var bookMock = new Mock<IBook>();

            // Act
            dbContextMock.Setup(x => x.Set<IBook>()).Returns(setMock.Object);
            var dbSetMock = new LibrarySystemEfWrapper<IBook>(dbContextMock.Object);
            setMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(bookMock.Object);

            // Assert
            Assert.That(dbSetMock.GetById(id), Is.Not.Null);
            Assert.AreEqual(dbSetMock.GetById(id), bookMock.Object);
        }
    }
}
