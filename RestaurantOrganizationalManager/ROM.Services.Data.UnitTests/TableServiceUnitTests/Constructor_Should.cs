using Moq;
using NUnit.Framework;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;

namespace ROM.Services.Data.UnitTests.TableServiceUnitTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParametersAreNotNull()
        {
            // Arrange
            var tableRepository = new Mock<IEfRepository<Table>>();
            var productRepository = new Mock<IEfRepository<Product>>();
            var saveContext = new Mock<ISaveContext>();

            // Act
            ITableService tableService = new TableService(
                tableRepository.Object,
                productRepository.Object,
                saveContext.Object);

            // Assert
            Assert.IsNotNull(tableService);
        }
    }
}
