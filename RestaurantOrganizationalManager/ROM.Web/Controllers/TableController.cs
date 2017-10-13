using ROM.Services.Data.Contracts;
using ROM.Web.ViewModels.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (tableId == null)
            {
                throw new NullReferenceException();
            }

            var products = this.productService.GetAll().ToList();
            var table = this.tableService.GetTablesByID(tableId).FirstOrDefault();

            if (table.Products.Count == 0 && table.IsFree)
            {
                this.tableService.ChangeTableStatus(table);
            }

            /// AUTOMAPPER
            var productsViewModel = new List<ProductViewModel>();
            var addedProductsViewModel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModel.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ProductType = product.ProductType,
                    Quantity = product.Quantity,
                    QuantityType = product.QuantityType
                });
            }
            foreach (var product in table.Products)
            {
                addedProductsViewModel.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ProductType = product.ProductType,
                    Quantity = product.Quantity,
                    QuantityType = product.QuantityType
                });
            }
            var tablesDetailsViewModel = new TableDetailsViewModel()
            {
                Id = table.Id,
                Number = table.Number,
                RestaurantName = restaurantName,
                AddedProducts = addedProductsViewModel,
                Products = productsViewModel
            };

            return this.View(tablesDetailsViewModel);
        }


        public ActionResult AddProductToTable(Guid? productId, Guid? tableId)
        {
            if (!this.Request.IsAjaxRequest())
            {
                throw new Exception();
            }

            if (productId == null || tableId == null)
            {
                throw new NullReferenceException();
            }

            var product = this.productService.GetAll().Where(p => p.Id == productId).FirstOrDefault();
            var table = this.tableService.GetTablesByID(tableId).FirstOrDefault();

            if (product == null || table == null)
            {
                throw new NullReferenceException();
            }

            this.tableService.AddProductToTable(product, table);

            // AUTOMMAPER
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductType = product.ProductType,
                Quantity = product.Quantity,
                QuantityType = product.QuantityType
            };

            return this.PartialView("_AddProductToTable", productViewModel);
        }

        public ActionResult Checkout(Guid? tableId)
        {
            if (tableId == null)
            {
                throw new NullReferenceException();
            }

            var table = this.tableService.GetTablesByID(tableId).FirstOrDefault();

            if (table == null)
            {
                throw new NullReferenceException();
            }

            var bill = this.tableService.GetBill(table);

            // AUTOMAPPER 
            var productsViewModel = new List<ProductViewModel>();
            foreach (var product in table.Products)
            {
                productsViewModel.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ProductType = product.ProductType,
                    Quantity = product.Quantity,
                    QuantityType = product.QuantityType
                });
            }
            var checkoutViewModel = new CheckoutViewModel()
            {
                Bill = bill,
                Products = productsViewModel
            };

            this.tableService.ChangeTableStatus(table);
            this.tableService.RemoveProductFromTable(table);

            return this.View(checkoutViewModel);
        }
    }
}