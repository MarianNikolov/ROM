using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Linq;

namespace ROM.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IEfRepository<Product> productRepository;
        private readonly IEfRepository<Table> tableRepository;
        private readonly ISaveContext saveContext;

        public ProductService(
            IEfRepository<Product> productRepository, 
            IEfRepository<Table> tableRepository,
            ISaveContext saveContext)
        {
            this.productRepository = productRepository;
            this.tableRepository = tableRepository;
            this.saveContext = saveContext;
        }

        public IQueryable<Product> GetAll()
        {
            return this.productRepository.All;
        }

        public IQueryable<Product> GetProductByID(Guid? productId)
        {
            if (productId == null)
            {
                throw new NullReferenceException();
            }

            return this.productRepository.All.Where(t => t.Id == productId);
        }
    }
}
