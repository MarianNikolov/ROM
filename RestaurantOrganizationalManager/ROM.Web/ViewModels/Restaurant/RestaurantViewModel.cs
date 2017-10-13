using ROM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Restaurant
{
    public class RestaurantViewModel
    {
        public ICollection<TableViewModel> Tables { get; set; }

        [Required]
        [MinLength(RestaurantConstants.RestaurantNameMinLength)]
        [MaxLength(RestaurantConstants.RestaurantNameMaxLength)]
        public string Name { get; set; }
    }
}