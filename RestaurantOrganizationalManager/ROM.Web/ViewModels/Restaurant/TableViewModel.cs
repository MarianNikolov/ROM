using ROM.Common;
using ROM.Web.Infrastructure;
using ROM.Web.ViewModels.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ROM.Web.ViewModels.Restaurant
{
    public class TableViewModel : IMapFrom<ROM.Data.Model.Table>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = TableConstants.NumberIsRequired)]
        public int Number { get; set; }

        public bool IsFree { get; set; }

        public string ImgUrl { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ROM.Data.Model.Table, TableViewModel>()
                .ForMember(t => t.Id, c => c.MapFrom(tb => tb.Id))
                .ForMember(t => t.Number, c => c.MapFrom(tb => tb.Number))
                .ForMember(t => t.IsFree, c => c.MapFrom(tb => tb.IsFree))
                .ForMember(t => t.Products, c => c.MapFrom(tb => tb.Products))
                .ForMember(t => t.ImgUrl, c => c.MapFrom(tb => tb.IsFree ? TableConstants.FreeTableImgUrl : TableConstants.NotFreeTableImgUrl));
        }
    }
}