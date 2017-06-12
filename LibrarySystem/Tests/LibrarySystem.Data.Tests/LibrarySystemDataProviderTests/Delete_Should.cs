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
    public class Delete_Should
    {
        [Test]
        public void ThrowNullNullReferenceException_WhenNullParameterIsPassed()
        {
            // Arrange
            var dbContextMock = new Mock<ILibrarySystemEfDbContext>();
            var setMock = new Mock<DbSet<IBook>>();

            // Act
            dbContextMock.Setup(x => x.Set<IBook>()).Returns(setMock.Object);
            var dbSetMock = new LibrarySystemEfDataProvider<IBook>(dbContextMock.Object);
            IBook entity = null;

            // Assert
            Assert.That(() => dbSetMock.Delete(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
