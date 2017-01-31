using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImageSelectionTool.Controllers
{
    public class WS_AccountController : BaseServiceController
    {
        //Based on the OWIN authentication, finds the current authenticated username.        
        public string GetCurrentUserName()
        {
            return Request.GetOwinContext().Authentication.User.Identity.Name;
        }

        //Based on the OWIN authentication, tells if the user is authenticated.
        public bool GetIsLoggedIn()
        {
            return Request.GetOwinContext().Authentication.User.Identity.IsAuthenticated;
        }

        //Get the userID from the Request context, and pass the ID into the usermanager to get the current user roles.
        async public Task<IEnumerable<string>> GetCurrentUserRoles()
        {
            return await UserManager.GetRolesAsync(Request.GetOwinContext().Authentication.User.Identity.GetUserId());
        }
    }
}
