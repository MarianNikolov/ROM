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
    public class CreateRestaurant_Should
    {
        [TestCase("31a21zxc3123acfzc", "Test's restaurant1", 4)]
        [TestCase("csa2asxc3123acfzc", "Test's restaurant2", 8)]
        [TestCase("daa2asxc3123acfzc", "Test's restaurant3", 20)]
        public void CreateAndSetRestaurantOnUser_WhenValidParametersAreProvided(string userID, string restaurantName, int countOfTables)
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
            restaurantService.CreateRestaurant(userID, restaurantName, countOfTables);

            //Assert
            Assert.IsNotNull(user.Restaurant);
        }

        [TestCase("31a21zxc3123acfzc", "Test's restaurant1", 4)]
        [TestCase("csa2asxc3123acfzc", "Test's restaurant2", 8)]
        [TestCase("daa2asxc3123acfzc", "Test's restaurant3", 20)]
        public void CreateAndSetTablesInProvidedCount_WhenValidParametersAreProvided(string userID, string restaurantName, int countOfTables)
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
            restaurantService.CreateRestaurant(userID, restaurantName, countOfTables);

            //Assert
            Assert.IsNotNull(user.Restaurant.Tables);
            Assert.AreEqual(user.Restaurant.Tables.Count, countOfTables);
        }


        [TestCase("31a21zxc3123acfzc", "Test's restaurant1", 4)]
        [TestCase("csa2asxc3123acfzc", "Test's restaurant2", 8)]
        [TestCase("daa2asxc3123acfzc", "Test's restaurant3", 20)]
        public void Throw_WhenInvalidParametersAreProvided(string userID, string restaurantName, int countOfTables)
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
            Assert.Throws<NullReferenceException>(() =>
                restaurantService.CreateRestaurant(userID, restaurantName, countOfTables));
        }
    }
}
