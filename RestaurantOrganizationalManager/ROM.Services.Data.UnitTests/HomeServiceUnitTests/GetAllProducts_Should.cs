using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ROM.Services.Data.UnitTests.HomeServiceUnitTests
{
    [TestFixture]
    class GetAllProducts_Should
    {
        [Test]
        public void Return_ProductsWhenMethodIsInvoced()
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();

            IEnumerable<Product> expectedResultCollection = new List<Product>();

            productRepository.Setup(p => p.All).Returns(() =>
            {
                return expectedResultCollection.AsQueryable();
            });

            IHomeService homeService = new HomeService(restaurantRepository.Object, tableRepository.Object, productRepository.Object);

            // Act
            IEnumerable<Product> productsResult = homeService.GetAllProducts();

            // Assert
            Assert.That(productsResult, Is.EqualTo(expectedResultCollection));
        }
    }
}
