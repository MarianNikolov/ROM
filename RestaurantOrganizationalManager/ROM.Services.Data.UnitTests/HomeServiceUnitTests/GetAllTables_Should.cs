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
    public class GetAllTables_Should
    {
        [Test]
        public void Return_TablesWhenMethodIsInvoced()
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();

            IEnumerable<Table> expectedResultCollection = new List<Table>();

            tableRepository.Setup(t => t.All).Returns(() =>
            {
                return expectedResultCollection.AsQueryable();
            });

            IHomeService homeService = new HomeService(restaurantRepository.Object, tableRepository.Object, productRepository.Object);

            // Act
            IEnumerable<Table> tablesResult = homeService.GetAllTables();

            // Assert
            Assert.That(tablesResult, Is.EqualTo(expectedResultCollection));
        }
    }
}
