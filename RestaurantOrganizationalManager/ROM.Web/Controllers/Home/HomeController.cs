﻿using ROM.Common;
using ROM.Services.Data.Contracts;
using ROM.Web.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace ROM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = WebConstants.HomePageCacheDuration)]
        public ActionResult Statistic()
        {
            var countOfAllRestaurants = this.homeService.GetAllRestaurants().Count();
            var countOfAllTables = this.homeService.GetAllTables().Count();
            var countOfAllProducts = this.homeService.GetAllProducts().Count();

            StatisticViewModel model = new StatisticViewModel()
            {
                CountRestaurants =  countOfAllRestaurants,
                CountTables = countOfAllTables,
                CountProducts = countOfAllProducts,
                TextRestaurants = HomePageConstants.RegisteredRestaurants,
                TextTables = HomePageConstants.RegisteredTables,
                TextProducts = HomePageConstants.DefaultProducts,
            };

            return this.PartialView("_Statistic", model);
        }
    }
}