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
    public class AddShould
    {
        [Test]
        public void Throw_NullReferenceException_WhenPassedArgumentIsNull()
        {
            // Arrange
            var contextMock = new Mock<ILibrarySystemEfDbContext>();
            var setMock = new Mock<DbSet<IBook>>();

            // Act
            contextMock.Setup(set => set.Set<IBook>()).Returns(setMock.Object);
            var dbSetMock = new LibrarySystemEfWrapper<IBook>(contextMock.Object);
            IBook entity = null;

            // Assert
            Assert.That(() => dbSetMock.Add(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
