using System.Web.Mvc;

namespace ROM.Web.Controllers.Error
{
    public class ErrorController : Controller
    {
        public ActionResult HttpError404(string message)
        {
            return View("HttpError404");
        }

        public ActionResult HttpError500(string message)
        {
            return View("HttpError500");
        }

        public ActionResult General(string message)
        {
            return View("General");
        }
    }
}