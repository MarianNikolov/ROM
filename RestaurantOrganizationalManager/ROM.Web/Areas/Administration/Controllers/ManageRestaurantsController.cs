using ROM.Common;
using ROM.Services.Data.Contracts;
using ROM.Web.Areas.Administration.ViewModels;
using ROM.Web.Infrastructure;
using System.Linq;
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
            var restaurantsViewModel = this.restaurantService
                .GetAll()
                .OrderBy(r => r.CreatedOn)
                .MapTo<ManageRestaurantsViewModel>()
                .ToList();

            return this.View(restaurantsViewModel);
        }
    }
}

