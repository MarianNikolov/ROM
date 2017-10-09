using ROM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Restaurant
{
    public class RegisterRestaurantViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [MinLength(RestaurantConstants.RestaurantNameMinLength, ErrorMessage = RestaurantConstants.ErrorMessage)]
        [MaxLength(RestaurantConstants.RestaurantNameMaxLength, ErrorMessage = RestaurantConstants.ErrorMessage)]
        public string Name { get; set; }
    }
}