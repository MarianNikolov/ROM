using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROM.Common
{
    public class RestaurantConstants
    {
        public const int RestaurantNameMinLength = 2;
        public const int RestaurantNameMaxLength = 50;
        public const string ErrorMessage = "Name must be between 2 and 50 characters!";
        public const string NameIsRequired = "Name is Required!";
    }
}
