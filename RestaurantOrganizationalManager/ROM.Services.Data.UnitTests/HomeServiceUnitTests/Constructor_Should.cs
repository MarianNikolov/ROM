using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Services.Data.Contracts;

namespace ROM.Services.Data.UnitTests.HomeServiceUnitTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            var restaurantRepository = new Mock<IEfRepository<Restaurant>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();

            IHomeService homeService = new HomeService(restaurantRepository.Object, tableRepository.Object, productRepository.Object);

            Assert.IsNotNull(homeService);
        }
    }
}
