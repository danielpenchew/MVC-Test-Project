using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySytem.Data.Models.Contracts;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace LibrarySystem.Data.Tests.LibrarySystemDataProviderTests
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var dbContextMock = new Mock<ILibrarySystemEfDbContext>();
            var setMock = new Mock<DbSet<IBook>>();

            // Act
            dbContextMock.Setup(x => x.Set<IBook>()).Returns(setMock.Object);
            var dbSetMock = new LibrarySystemEfWrapper<IBook>(dbContextMock.Object);

            // Assert
            Assert.IsNotNull(dbSetMock.All());
            Assert.IsInstanceOf(typeof(DbSet<IBook>), dbSetMock.All());
            Assert.AreSame(dbSetMock.All(), dbSetMock.DbSet);
        }
    }
}
