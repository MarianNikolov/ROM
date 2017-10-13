using ROM.Common;
using ROM.Services.Data.Contracts;
using ROM.Web.Areas.Administration.ViewModels;
using ROM.Web.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROM.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    public class ManageRestaurantsController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public ManageRestaurantsController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        public ActionResult Index()
        {
            var restaurants = this.restaurantService
                .GetAll()
                .OrderBy(r => r.CreatedOn)
                .ToList();
            
            //AUTOMAPPER
            var restaurantsViewModel = new List<ManageRestaurantsViewModel>();

            foreach (var restaurant in restaurants)
            {
                var managersNames = new List<string>();
                foreach (var user in restaurant.Users)
                {
                    managersNames.Add(user.UserName);
                }

                restaurantsViewModel.Add(new ManageRestaurantsViewModel()
                {
                    RestaurantID = restaurant.Id,
                    Name = restaurant.Name,
                    CountOfRestaurants = restaurant.Tables.Count(),
                    ManagerName = managersNames[0],
                });
            }

            return this.View(restaurantsViewModel);
        }

    }
}

