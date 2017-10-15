using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ROM.Services.Data.UnitTests.RestaurantServiceUnitTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Return_AllRestaurantsWhenMethodIsInvoced()
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var userRepository = new Mock<IEfRepository<User>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var userRoleService = new Mock<IUserRoleService>();
            var saveContext = new Mock<ISaveContext>();

            IEnumerable<Restaurant> expectedResultCollection = new List<Restaurant>();

            restaurantRepository.Setup(r => r.All).Returns(() =>
            {
                return expectedResultCollection.AsQueryable();
            });

            IRestaurantService restaurantService = new RestaurantService(
                restaurantRepository.Object, 
                userRepository.Object,
                tableRepository.Object,
                userRoleService.Object,
                saveContext.Object);

            // Act
            IEnumerable<Restaurant> restaurantsResult = restaurantService.GetAll();

            // Assert
            Assert.That(restaurantsResult, Is.EqualTo(expectedResultCollection));
        }
    }
}
