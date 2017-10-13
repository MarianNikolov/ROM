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
    public class GetAllRestaurants_Should
    {
        [Test]
        public void Return_RestauransWhenMethodIsInvoced()
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();

            IEnumerable<Restaurant> expectedResultCollection = new List<Restaurant>();

            restaurantRepository.Setup(r => r.All).Returns(() => 
            {
                return expectedResultCollection.AsQueryable();
            });

            IHomeService homeService = new HomeService(restaurantRepository.Object, tableRepository.Object, productRepository.Object);

            // Act
            IEnumerable<Restaurant> restaurantsResult = homeService.GetAllRestaurants();

            // Assert
            Assert.That(restaurantsResult, Is.EqualTo(expectedResultCollection));
        }
    }
}
