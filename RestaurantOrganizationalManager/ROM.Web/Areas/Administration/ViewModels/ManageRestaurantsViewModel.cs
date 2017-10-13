using GridMvc.DataAnnotations;
using ROM.Common;
using ROM.Web.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROM.Web.Areas.Administration.ViewModels
{
    [GridTable(PagingEnabled = true, PageSize = 4)]
    public class ManageRestaurantsViewModel
    {
        [GridHiddenColumn]
        public Guid RestaurantID { get; set; }

        [GridColumn(Title = "Name of restaurant", SortEnabled = true, FilterEnabled = true)]
        public string Name { get; set; }

        [GridColumn(Title = "Count of tables", SortEnabled = true, FilterEnabled = true)]
        public int CountOfRestaurants{ get; set; }

        [GridColumn(Title = "Manager", SortEnabled = true, FilterEnabled = true)]
        public string ManagerName { get; set; }
    }
}