﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROM.Web.ViewModels.Table
{
    public class CheckoutViewModel
    {
        public decimal Bill { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}