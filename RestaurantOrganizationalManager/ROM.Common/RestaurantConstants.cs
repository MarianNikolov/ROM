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
        public const string NameErrorMessage = "Name must be between 2 and 50 characters!";
        public const string NameIsRequired = "Name is Required!";
        public const int RestaurantMinCountOfTables = 4;
        public const int RestaurantMaxCountOfTables = 20;
        public const string CountOfTablesErrorMessage = "Count of tables must be between 4 and 20!";
        public const string CountOfTablesIsRequired = "Count of tables is Required!";
        public const string DisplayName = "Count of tables";
    }
}
