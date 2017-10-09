using ROM.Common;
using ROM.Services.Data.Contracts;
using ROM.Web.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ROM.Web.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        public ActionResult Index()
        {
            var userID = this.User.Identity.GetUserId();
            var restaurant = restaurantService.GetRestaurantManagerByID(userID);
            var hasUserAuthenticated = this.User.Identity.IsAuthenticated;

            if (hasUserAuthenticated && restaurant != null)
            {
                return this.RedirectToAction("ManageRestaurant");
            }
            else
            {
                return this.RedirectToAction("RegisterRestaurant");
            }
        }

        [HttpGet]
        public ActionResult RegisterRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterRestaurant(RegisterRestaurantViewModel restaurantModel)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurantModel);
            }

            var userID = this.User.Identity.GetUserId();
            var restauranName = restaurantModel.Name;
            this.restaurantService.CreateRestaurant(userID, restauranName);

            return this.RedirectToAction("ManageRestaurant");
        }

        public ActionResult ManageRestaurant()
        {
            return View();
        }
    }
}