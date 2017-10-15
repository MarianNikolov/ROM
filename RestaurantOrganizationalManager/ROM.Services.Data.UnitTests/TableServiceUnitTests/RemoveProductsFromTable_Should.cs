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
    public class RemoveProductsFromTable_Should
    {
        [Test]
        public void SuccessfullyRemoveProductFromTable_WhenValidTableAreProvided()
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

            var firstProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 2,
                Name = "Cola",
                ProductType = ProductType.Drink,
                Quantity = 500,
                QuantityType = QuantityType.Grams
            };

            var secondProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 5,
                Name = "Hot dog",
                ProductType = ProductType.Food,
                Quantity = 450,
                QuantityType = QuantityType.Grams
            };

            var thirdProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 4,
                Name = "Dread",
                ProductType = ProductType.Food,
                Quantity = 100,
                QuantityType = QuantityType.Grams
            };

            table.Products.Add(firstProduct);
            table.Products.Add(secondProduct);
            table.Products.Add(thirdProduct);

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.RemoveProductsFromTable(table);

            // Assert
            Assert.AreEqual(table.Products.Count, 0);
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

            var firstProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 2,
                Name = "Cola",
                ProductType = ProductType.Drink,
                Quantity = 500,
                QuantityType = QuantityType.Grams
            };

            var secondProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 5,
                Name = "Hot dog",
                ProductType = ProductType.Food,
                Quantity = 450,
                QuantityType = QuantityType.Grams
            };

            var thirdProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 4,
                Name = "Dread",
                ProductType = ProductType.Food,
                Quantity = 100,
                QuantityType = QuantityType.Grams
            };

            table.Products.Add(firstProduct);
            table.Products.Add(secondProduct);
            table.Products.Add(thirdProduct);

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.RemoveProductsFromTable(table);

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

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
            };

            var firstProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 2,
                Name = "Cola",
                ProductType = ProductType.Drink,
                Quantity = 500,
                QuantityType = QuantityType.Grams
            };

            var secondProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 5,
                Name = "Hot dog",
                ProductType = ProductType.Food,
                Quantity = 450,
                QuantityType = QuantityType.Grams
            };

            var thirdProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = 4,
                Name = "Dread",
                ProductType = ProductType.Food,
                Quantity = 100,
                QuantityType = QuantityType.Grams
            };

            table.Products.Add(firstProduct);
            table.Products.Add(secondProduct);
            table.Products.Add(thirdProduct);

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act
            tableService.RemoveProductsFromTable(table);

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

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
             tableService.RemoveProductsFromTable(null));
        }
    }
}
