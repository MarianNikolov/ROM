﻿using ROM.Common;
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
        private readonly IUserRoleService userRoleService;
        private readonly ISaveContext saveContext;

        public RestaurantService(
            IEfRepository<Restaurant> restaurantRepository,
            IEfRepository<User> userRepository,
            IUserRoleService userRoleService,
            ISaveContext saveContext)
        {
            this.restaurantRepository = restaurantRepository;
            this.userRepository = userRepository;
            this.userRoleService = userRoleService;
            this.saveContext = saveContext;
        }

        public void CreateRestaurant(string userID, string restaurantName)
        {
            var user = this.userRepository.All
                .Where(u => u.Id == userID)
                .FirstOrDefault();

            if (user != null)
            {
                this.userRoleService.AddRole(user, RoleConstants.Manager);

                var restaurant = new Restaurant() { Name = restaurantName };
                user.Restaurant = restaurant;
                restaurant.Users.Add(user);

                this.saveContext.Commit();
            }
        }

        public Restaurant GetRestaurantManagerByID(string userID)
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