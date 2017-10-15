using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Collections.Generic;

namespace ROM.Services.Data.UnitTests.TableServiceUnitTests
{
    [TestFixture]
    public class ChangeTableStatus_Should
    {
        [Test]
        public void SuccessfullyChangeTableStatus_WhenValidTableAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var initialTableStatus = false;

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                IsFree = initialTableStatus,
                Products = new List<Product>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.ChangeTableStatus(table);

            // Assert
            Assert.IsTrue(table.IsFree);
            Assert.AreEqual(table.IsFree, !initialTableStatus);
        }

        [Test]
        public void VerifyTableRepositoryUpdateMethodIsInvoced_WhenValidParametersAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var initialTableStatus = false;

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                IsFree = initialTableStatus,
                Products = new List<Product>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.ChangeTableStatus(table);

            // Assert
            tableRepository.Verify(x => x.Update(table), Times.Once());
        }

        [Test]
        public void VerifySaveContextIsInvoced_WhenValidParametersAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var initialTableStatus = false;

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                IsFree = initialTableStatus,
                Products = new List<Product>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.ChangeTableStatus(table);

            // Assert
            saveContext.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void Throw_WhenInvalidParameterAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                tableService.ChangeTableStatus(null));
        }
    }
}
