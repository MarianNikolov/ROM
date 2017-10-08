using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Services.Data.Contracts;
using System.Linq;

namespace ROM.Services.Data
{
    public class HomeService : IHomeService
    {
        private IEfRepository<Restaurant> restaurantRepository;

        public HomeService(IEfRepository<Restaurant> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public IQueryable<Restaurant> GetAll()
        {
            return this.restaurantRepository.All;
        }

    }
}
