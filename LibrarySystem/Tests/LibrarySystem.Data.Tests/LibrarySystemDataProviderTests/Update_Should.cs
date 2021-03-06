﻿using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using LibrarySytem.Data.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace LibrarySystem.Data.Tests.LibrarySystemWrapperTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Throw_NullReferenceException_WhenPassetParameterIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ILibrarySystemEfDbContext>();
            var setMock = new Mock<DbSet<IBook>>();

            // Act
            dbContextMock.Setup(x => x.Set<IBook>()).Returns(setMock.Object);
            var dbSetMock = new LibrarySystemEfWrapper<IBook>(dbContextMock.Object);
            IBook entity = null;

            // Assert
            Assert.That(() => dbSetMock.Update(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
