using ROM.Common;
using ROM.Data.Model;
using ROM.Data.Repository;
using ROM.Data.SaveContext;
using ROM.Services.Data.Contracts;
using System;
using System.Linq;

namespace ROM.Services.Data
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IEfRepository<Restaurant> restaurantRepository;
        private readonly IEfRepository<User> userRepository;
        private readonly IEfRepository<Table> tableRepository;
        private readonly IUserRoleService userRoleService;
        private readonly ISaveContext saveContext;

        public RestaurantService(
            IEfRepository<Restaurant> restaurantRepository,
            IEfRepository<User> userRepository,
            IEfRepository<Table> tableRepository,
            IUserRoleService userRoleService,
            ISaveContext saveContext)
        {
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.tableRepository = tableRepository;
            this.userRoleService = userRoleService;
            this.saveContext = saveContext;
        }

        public void CreateRestaurant(string userID, string restaurantName)
        {
            var user = this.userRepository.All
                .Where(u => u.Id == userID)
                .FirstOrDefault();

            if (user == null)
            {
                throw new NullReferenceException();
            }

            this.userRoleService.AddRole(user, RoleConstants.Manager);

            var restaurant = new Restaurant() { Name = restaurantName };
            user.Restaurant = restaurant;
            restaurant.Users.Add(user);


            for (int j = 1; j <= 8; j++)
            {
                var table = new Table()
                {
                    Number = j,
                    CreatedOn = DateTime.Now
                };

                this.tableRepository.Add(table);
                restaurant.Tables.Add(table);
            }

            this.saveContext.Commit();
        }

        public Restaurant GetRestaurantByManagerID(string userID)
        {
            var user = this.userRepository.All
                .Where(u => u.Id == userID)
                .FirstOrDefault();

            if (user == null)
            {
                throw new NullReferenceException();
            }

            return user.Restaurant;
        }
    }
}
