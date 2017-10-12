using ROM.Common;
using ROM.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Table
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ProductConstants.NameIsRequired)]
        [MinLength(ProductConstants.ProductNameMinLength)]
        [MaxLength(ProductConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = ProductConstants.QuantityIsRequired)]
        public int Quantity { get; set; }

        public QuantityType QuantityType { get; set; }

        public ProductType ProductType { get; set; }

        [Required(ErrorMessage = ProductConstants.PriceIsRequired)]
        public decimal Price { get; set; }
    }
}