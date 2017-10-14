using Microsoft.AspNet.Identity;
using ROM.Services.Data.Contracts;
using ROM.Web.Infrastructure;
using ROM.Web.ViewModels.Restaurant;
using System.Linq;
using System.Web.Mvc;

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
        [ValidateAntiForgeryToken]
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
            
            var tables = restaurant.Tables.AsQueryable().MapTo<TableViewModel>()
                .OrderBy(t => t.Number)
                .ToList();
           
            var restaurantViewModel = new RestaurantViewModel()
            {
                Name = restaurant.Name,
                Tables = tables
            };

            return View(restaurantViewModel);
        }
    }
}