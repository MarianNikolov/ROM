using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;

namespace ROM.Services.Data.UnitTests.RestaurantServiceUnitTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var userRepository = new Mock<IEfRepository<User>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var userRoleService = new Mock<IUserRoleService>();
            var saveContext = new Mock<ISaveContext>();

            IRestaurantService restaurantService = new RestaurantService(
                restaurantRepository.Object,
                userRepository.Object,
                tableRepository.Object,
                userRoleService.Object,
                saveContext.Object);

            Assert.IsNotNull(restaurantService);
        }
    }
}
