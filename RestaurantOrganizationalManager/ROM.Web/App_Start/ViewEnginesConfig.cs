using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROM.Web.App_Start
{
    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}