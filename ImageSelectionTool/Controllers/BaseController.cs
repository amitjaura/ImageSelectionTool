using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ImageSelectionTool.Models;
using System.Net.Http;
using System.Web.Http;

namespace ImageSelectionTool.Controllers
{
    public class BaseServiceController : ApiController
    {
        private DBContext db = new DBContext();
        //HttpContext httpContext = new HttpContext(new Http

        protected RoleManager<IdentityRole> RoleManager { get; private set; }

        private ApplicationUserManager _userManager;

        public BaseServiceController(){}

        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected User CurrentUser
        {
            get {
                string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
                return UserManager.FindById(userId);
            }
        }
    }
}
