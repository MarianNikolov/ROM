using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROM.Services.Data.UnitTests.TableServiceUnitTests
{
    [TestFixture]
    public class GetTableByID_Should
    {
        [Test]
        public void ReturnTable_WhenValidParameterAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var tableId = Guid.NewGuid();

            var table = new Table()
            {
                Id = tableId,
                Number = 1
            };

            ICollection<Table> tableCollection = new List<Table>();
            tableCollection.Add(table);

            tableRepository.Setup(u => u.All).Returns(() =>
            {
                return tableCollection.AsQueryable();
            });

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            var tableResult = tableService.GetTableByID(tableId);

            // Assert
            Assert.IsInstanceOf<Table>(tableResult);
            Assert.IsNotNull(tableResult);
            Assert.AreEqual(tableResult.Id, table.Id);
            Assert.AreEqual(tableResult.Number, table.Number);
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
                tableService.GetTableByID(null));
        }

        [Test]
        public void Throw_WhenNoTableWithProdidedId()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var tableId = Guid.NewGuid();
            var parameterTableId = Guid.NewGuid();

            var table = new Table()
            {
                Id = tableId,
                Number = 1
            };

            ICollection<Table> tableCollection = new List<Table>();
            tableCollection.Add(table);

            tableRepository.Setup(u => u.All).Returns(() =>
            {
                return tableCollection.AsQueryable();
            });

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                tableService.GetTableByID(parameterTableId));
        }
    }
}
