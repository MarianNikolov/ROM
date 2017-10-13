using ROM.Common;
using ROM.Services.Data.Contracts;
using ROM.Web.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ROM.Data.Model;
using ROM.Web.ViewModels.Table;

namespace ROM.Web.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly ITableService tableService;

        public RestaurantController(IRestaurantService restaurantService, ITableService tableService)
        {
            this.restaurantService = restaurantService;
            this.tableService = tableService;
        }

        public ActionResult Index()
        {
            var userID = this.User.Identity.GetUserId();
            var restaurant = restaurantService.GetRestaurantByManagerID(userID);
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
            var countOfTables = restaurantModel.CountOfTables;
            this.restaurantService.CreateRestaurant(userID, restauranName, countOfTables);

            return this.RedirectToAction("ManageRestaurant");
        }

        public ActionResult ManageRestaurant()
        {
            var userID = this.User.Identity.GetUserId();
            var restaurant = this.restaurantService.GetRestaurantByManagerID(userID);

            var tables = this.tableService.GetTablesByRestaurantID(restaurant.Id)
                .OrderBy(t => t.Number)
                .ToList();

            var tablesViewModel = new List<TableViewModel>();

            // AUTO MAPPER
            for (int i = 0; i < tables.Count(); i++)
            {
                // ???
                var imgUrl = tables[i].IsFree ? TableConstants.FreeTableImgUrl : TableConstants.NotFreeTableImgUrl;

                tablesViewModel.Add(new TableViewModel()
                {
                    Id = tables[i].Id,
                    IsFree = tables[i].IsFree,
                    Number = tables[i].Number,
                    Products = new List<ProductViewModel>(),
                    ImgUrl = imgUrl,
                });
            }
            var restaurantViewModel = new RestaurantViewModel()
            {
                Name = restaurant.Name,
                Tables = tablesViewModel
            };

            return View(restaurantViewModel);
        }
    }
}