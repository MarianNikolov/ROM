using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROM.Services.Data.UnitTests.ProductServiceUnitTests
{
    [TestFixture]
    public class GetProductByID_Should
    {
        [Test]
        public void ReturnProduct_WhenValidParameterAreProvided()
        {
            // Arrange
            var productRepository = new Mock<IEfRepository<Product>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var saveContext = new Mock<ISaveContext>();

            var productId = Guid.NewGuid();

            var product = new Product()
            {
                Id = productId,
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ICollection<Product> productsCollection = new List<Product>();
            productsCollection.Add(product);

            productRepository.Setup(u => u.All).Returns(() =>
            {
                return productsCollection.AsQueryable();
            });

            IProductService productService = new ProductService(
                productRepository.Object,
                tableRepository.Object,
                saveContext.Object);

            // Act
            var productResult = productService.GetProductByID(productId);

            // Assert
            Assert.IsInstanceOf<Product>(productResult);
            Assert.IsNotNull(productResult);
            Assert.AreEqual(productResult.Id, product.Id);
            Assert.AreEqual(productResult.Name, product.Name);
            Assert.AreSame(productResult, product);
        }

        [Test]
        public void Throw_WhenInvalidParameterAreProvided()
        {
            // Arrange
            var productRepository = new Mock<IEfRepository<Product>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var saveContext = new Mock<ISaveContext>();

            IProductService productService = new ProductService(
                productRepository.Object,
                tableRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                productService.GetProductByID(null));
        }

        [Test]
        public void Throw_WhenNoProductWithProdidedId()
        {
            // Arrange
            var productRepository = new Mock<IEfRepository<Product>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var saveContext = new Mock<ISaveContext>();

            var productId = Guid.NewGuid();
            var parameterProductId = Guid.NewGuid();

            var product = new Product()
            {
                Id = productId,
                Name = "Coca cola",
                Price = 5,
                Quantity = 500,
                QuantityType = QuantityType.Milliliters,
                Tables = new List<Table>()
            };

            ICollection<Product> productsCollection = new List<Product>();
            productsCollection.Add(product);

            productRepository.Setup(u => u.All).Returns(() =>
            {
                return productsCollection.AsQueryable();
            });

            IProductService productService = new ProductService(
                productRepository.Object,
                tableRepository.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                productService.GetProductByID(parameterProductId));
        }
    }
}
