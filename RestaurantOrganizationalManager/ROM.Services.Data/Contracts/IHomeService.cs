using ROM.Data.Model;
using System.Linq;

namespace ROM.Services.Data.Contracts
{
    public interface IHomeService
    {
        IQueryable<Restaurant> GetAllRestaurants();

        IQueryable<Table> GetAllTables();

        IQueryable<Product> GetAllProducts();
    }
}
