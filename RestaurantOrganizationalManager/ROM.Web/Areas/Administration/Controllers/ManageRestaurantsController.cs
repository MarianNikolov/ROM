using ROM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROM.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    public class ManageRestaurantsController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

    }
}