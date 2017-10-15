using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROM.Services.Data.UnitTests.TableServiceUnitTests
{
    [TestFixture]
    public class GetBill_Should
    {
        [Test]
        public void ReturnCorrectBill_WhenValidTableAreProvided()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            decimal firstProductPrice = 5;
            decimal secondProductPrice = (decimal)2.5;
            decimal thirdProductPrice = 1;

            var firstProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = firstProductPrice,
                Name = "Cola",
                ProductType = ProductType.Drink,
                Quantity = 500,
                QuantityType = QuantityType.Grams
            };

            var secondProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = secondProductPrice,
                Name = "Hot dog",
                ProductType = ProductType.Food,
                Quantity = 450,
                QuantityType = QuantityType.Grams
            };

            var thirdProduct = new Product
            {
                Id = Guid.NewGuid(),
                Price = thirdProductPrice,
                Name = "Dread",
                ProductType = ProductType.Food,
                Quantity = 100,
                QuantityType = QuantityType.Grams
            };

            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Products = new List<Product>()
                {
                    firstProduct,
                    secondProduct,
                    thirdProduct
                }
            };

            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            var expectedResult = firstProductPrice + secondProductPrice + thirdProductPrice;

            // Act
            var billResult = tableService.GetBill(table);

            // Assert
            Assert.AreEqual(expectedResult, billResult);
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
                tableService.GetBill(null));
        }
    }
}
