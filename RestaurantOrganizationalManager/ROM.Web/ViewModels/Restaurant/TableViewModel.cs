using ROM.Common;
using ROM.Web.ViewModels.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Restaurant
{
    public class TableViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = TableConstants.NumberIsRequired)]
        public int Number { get; set; }

        public bool IsFree { get; set; }

        public string ImgUrl { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}