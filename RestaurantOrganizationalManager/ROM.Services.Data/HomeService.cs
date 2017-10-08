using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
