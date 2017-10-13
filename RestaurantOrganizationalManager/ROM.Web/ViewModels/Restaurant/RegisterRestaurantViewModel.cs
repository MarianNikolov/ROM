using ROM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Restaurant
{
    public class RegisterRestaurantViewModel
    {
        [Required(ErrorMessage = RestaurantConstants.NameIsRequired)]
        [MinLength(RestaurantConstants.RestaurantNameMinLength, ErrorMessage = RestaurantConstants.NameErrorMessage)]
        [MaxLength(RestaurantConstants.RestaurantNameMaxLength, ErrorMessage = RestaurantConstants.NameErrorMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = RestaurantConstants.CountOfTablesIsRequired)]
        [Range(RestaurantConstants.RestaurantMinCountOfTables, RestaurantConstants.RestaurantMaxCountOfTables, ErrorMessage = RestaurantConstants.CountOfTablesErrorMessage)]
        [DisplayName(RestaurantConstants.DisplayName)]
        public int CountOfTables { get; set; }
    }
}