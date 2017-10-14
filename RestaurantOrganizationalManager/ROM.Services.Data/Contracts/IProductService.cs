using ROM.Data.Model;
using System;
using System.Linq;

namespace ROM.Services.Data.Contracts
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetProductByID(Guid? tableId);
    }
}
