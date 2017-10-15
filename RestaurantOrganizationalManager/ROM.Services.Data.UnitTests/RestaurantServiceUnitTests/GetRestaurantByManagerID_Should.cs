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

namespace ROM.Services.Data.UnitTests.RestaurantServiceUnitTests
{
    [TestFixture]
    public class GetRestaurantByManagerID_Should
    {
        [TestCase("31a21zxc3123acfzc")]
        public void ReturnRestaurant_WhenValidParameterAreProvided(string userID)
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var userRepository = new Mock<IEfRepository<User>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var userRoleService = new Mock<IUserRoleService>();
            var saveContext = new Mock<ISaveContext>();

            var user = new User()
            {
                Id = userID,
                Email = "test@abv.bg",
                PasswordHash = "password"
            };

            var restaurant = new Restaurant()
            {
                Id = Guid.NewGuid(),
                Name = "Test restaurant",
                Users = new List<User>()
            };

            user.Restaurant = restaurant;
            restaurant.Users.Add(user);

            ICollection<User> usersCollection = new List<User>();
            usersCollection.Add(user);

            userRepository.Setup(u => u.All).Returns(() =>
            {
                return usersCollection.AsQueryable();
            });

            IRestaurantService restaurantService = new RestaurantService(
                restaurantRepository.Object,
                userRepository.Object,
                tableRepository.Object,
                userRoleService.Object,
                saveContext.Object);

            //Act
            var restaurantResult = restaurantService.GetRestaurantByManagerID(userID);

            //Assert
            Assert.IsInstanceOf<Restaurant>(restaurantResult);
            Assert.IsNotNull(restaurantResult);
            Assert.AreSame(user.Restaurant, restaurantResult);
            Assert.AreEqual(user.Restaurant.Id, restaurantResult.Id);
            Assert.AreEqual(user.Restaurant.Name, restaurantResult.Name);
        }

        [TestCase("31a21zxc3123acfzc")]
        public void Throw_WhenUserWithProvidedIdNotFound(string userID)
        {
            // Arrange
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var userRepository = new Mock<IEfRepository<User>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var userRoleService = new Mock<IUserRoleService>();
            var saveContext = new Mock<ISaveContext>();

            ICollection<User> usersCollection = new List<User>();

            userRepository.Setup(u => u.All).Returns(() =>
            {
                return usersCollection.AsQueryable();
            });

            IRestaurantService restaurantService = new RestaurantService(
                restaurantRepository.Object,
                userRepository.Object,
                tableRepository.Object,
                userRoleService.Object,
                saveContext.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => restaurantService.GetRestaurantByManagerID(userID));
        }
    }
}
