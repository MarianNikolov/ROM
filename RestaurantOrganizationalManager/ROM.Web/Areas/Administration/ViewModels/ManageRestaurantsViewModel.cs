using AutoMapper;
using GridMvc.DataAnnotations;
using ROM.Data.Model;
using ROM.Web.Infrastructure;
using System;
using System.Linq;

namespace ROM.Web.Areas.Administration.ViewModels
{
    [GridTable(PagingEnabled = true, PageSize = 4)]
    public class ManageRestaurantsViewModel : IMapFrom<Restaurant>, IHaveCustomMappings
    {
        [GridHiddenColumn]
        public Guid RestaurantID { get; set; }

        [GridColumn(Title = "Name of restaurant", SortEnabled = true, FilterEnabled = true)]
        public string Name { get; set; }

        [GridColumn(Title = "Count of tables", SortEnabled = true, FilterEnabled = true)]
        public int CountOfTables { get; set; }

        [GridColumn(Title = "Manager", SortEnabled = true, FilterEnabled = true)]
        public string ManagerName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ROM.Data.Model.Restaurant, ManageRestaurantsViewModel>()
                .ForMember(t => t.RestaurantID, c => c.MapFrom(tb => tb.Id))
                .ForMember(t => t.Name, c => c.MapFrom(tb => tb.Name))
                .ForMember(t => t.CountOfTables, c => c.MapFrom(tb => tb.Tables.Count))
                .ForMember(t => t.ManagerName, c => c.MapFrom(tb => tb.Users.Select(u => u.UserName).FirstOrDefault()));
        }
    }
}