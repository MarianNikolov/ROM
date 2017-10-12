using ROM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROM.Web.ViewModels.Table
{
    public class TableDetailsViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = TableConstants.NumberIsRequired)]
        public int Number { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public List<ProductViewModel> AddedProducts { get; set; }

        public string RestaurantName { get; set; }
    }
}