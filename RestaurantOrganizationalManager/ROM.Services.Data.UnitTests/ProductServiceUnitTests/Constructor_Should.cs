using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;

namespace ROM.Services.Data.UnitTests.ProductServiceUnitTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var productRepository = new Mock<IEfRepository<Product>>();
            var tableRepository = new Mock<IEfRepository<Table>>();
            var saveContext = new Mock<ISaveContext>();

            // Act
            IProductService productService = new ProductService(
                productRepository.Object,
                tableRepository.Object,
                saveContext.Object);

            // Assert
            Assert.IsNotNull(productService);
        }
    }
}
