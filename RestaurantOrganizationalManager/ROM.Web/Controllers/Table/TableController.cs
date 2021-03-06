﻿using ROM.Services.Data.Contracts;
using ROM.Web.Infrastructure;
using ROM.Web.ViewModels.Table;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace ROM.Web.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly ITableService tableService;
        private readonly IProductService productService;

        public TableController(ITableService tableService, IProductService productService)
        {
            this.tableService = tableService;
            this.productService = productService;
        }

        public ActionResult Index(string restaurantName, Guid? tableId)
        {
            var table = this.tableService.GetTableByID(tableId);
            var addedProductsViewModel = table.Products.AsQueryable().MapTo<ProductViewModel>().ToList();
            var allProductsViewModel = this.productService.GetAll().MapTo<ProductViewModel>().ToList();

            if (table.Products.Count == 0 && table.IsFree)
            {
                this.tableService.ChangeTableStatus(table);
            }

            var tablesDetailsViewModel = new TableDetailsViewModel()
            {
                Id = table.Id,
                Number = table.Number,
                RestaurantName = restaurantName,
                AddedProducts = addedProductsViewModel,
                Products = allProductsViewModel
            };

            return this.View(tablesDetailsViewModel);
        }

        public ActionResult AddProductToTable(Guid? productId, Guid? tableId)
        {
            if (!this.Request.IsAjaxRequest())
            {
                throw new HttpRequestException();
            }

            var product = this.productService.GetProductByID(productId);
            var table = this.tableService.GetTableByID(tableId);
            this.tableService.AddProductToTable(product, table);

            var productViewModel = AutoMapperConfig.Configuration.CreateMapper().Map<ProductViewModel>(product);
                
            return this.PartialView("_AddProductToTable", productViewModel);
        }

        public ActionResult Checkout(Guid? tableId)
        {
            var table = this.tableService.GetTableByID(tableId);
            var bill = this.tableService.GetBill(table);

            var productsViewModel = table.Products.AsQueryable().MapTo<ProductViewModel>().ToList();

            var checkoutViewModel = new CheckoutViewModel()
            {
                Bill = bill,
                Products = productsViewModel
            };

            this.tableService.ChangeTableStatus(table);
            this.tableService.RemoveProductsFromTable(table);

            return this.View(checkoutViewModel);
        }
    }
}