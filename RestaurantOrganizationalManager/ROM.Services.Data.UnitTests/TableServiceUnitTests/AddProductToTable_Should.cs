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
    public class AddProductToTable_Should
    {
        [Test]
        public void SuccessfullyAddProductToTable_WhenValidParameterAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.AddProductToTable(product, table);

            // Assert
            Assert.IsTrue(product.Tables.Contains(table));
            Assert.IsTrue(table.Products.Contains(product));
        }

        [Test]
        public void VerifyTableRepositoryUpdateMethodIsInvoced_WhenValidParametersAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.AddProductToTable(product, table);

            // Assert
            tableRepository.Verify(x => x.Update(table), Times.Once());
        }

        [Test]
        public void VerifyProductRepositoryUpdateMethodIsInvoced_WhenValidParametersAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.AddProductToTable(product, table);

            // Assert
            productRepository.Verify(x => x.Update(product), Times.Once());
        }

        [Test]
        public void VerifySaveContextIsInvoced_WhenValidParametersAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.AddProductToTable(product, table);

            // Assert
            saveContext.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void Throw_WhenInvalidTableAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
             tableService.AddProductToTable(product, null));
        }

        [Test]
        public void Throw_WhenInvalidProductAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
             tableService.AddProductToTable(null, table));
        }
    }
}
