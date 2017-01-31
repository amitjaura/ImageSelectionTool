using System.Web.Mvc;

namespace ImageSelectionTool.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
    /// Alternatively, we can use html templates instead of cshtml file...but this better way as we r making use of MVC
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult TraverseImage()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult UserPreferences()
        {
            return PartialView();
        }
    }
}