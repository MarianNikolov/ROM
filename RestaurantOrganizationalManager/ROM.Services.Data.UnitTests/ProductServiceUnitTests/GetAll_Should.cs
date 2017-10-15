using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ROM.Services.Data.UnitTests.ProductServiceUnitTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Return_AllProductsWhenMethodIsInvoced()
        {
            // Arrange
            var productRepository = new Mock<IEfRepository<Product>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var saveContext = new Mock<ISaveContext>();

            IEnumerable<Product> expectedResultCollection = new List<Product>();

            productRepository.Setup(p => p.All).Returns(() =>
            {
                return expectedResultCollection.AsQueryable();
            });

            IProductService productService = new ProductService(
                productRepository.Object,
                tableRepository.Object,
                saveContext.Object);

            // Act
            IEnumerable<Product> restaurantsResult = productService.GetAll();

            // Assert
            Assert.That(restaurantsResult, Is.EqualTo(expectedResultCollection));
        }
    }
}
