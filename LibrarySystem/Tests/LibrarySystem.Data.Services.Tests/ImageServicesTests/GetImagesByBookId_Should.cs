using LibrarySystem.Data.Contracts;
using LibrarySytem.Data.Models.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Data.Services.Tests.ImageServicesTests
{
    [TestFixture]
    public class GetImagesByBookId_Should
    {
        [Test]
        public void ReturnCorrectImagesCount_WhenCorrectBookIdIsPassed()
        {
            // Arrange
            var dbSetMock = new Mock<ILibrarySystemEfWrapper<Image>>();
            var imageServices = new ImageServices(dbSetMock.Object);
            Guid id = Guid.NewGuid();
            var expectedResult = 2;

            dbSetMock.Setup(r => r.All()).Returns(() => new List<Image>()
            {
                new Image() { Id = Guid.NewGuid(), BookId = id},
                new Image() { Id = Guid.NewGuid(), BookId = id},
                new Image() { Id = Guid.NewGuid(), BookId = Guid.NewGuid() }
            }.AsQueryable());

            // Act
            var result = imageServices.GetImagesByBookId(id);

            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count());
        }
    }
}
