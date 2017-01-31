using ImageSelectionTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageSelectionTool.Controllers
{
    public class WS_UserImagePreferenceController : BaseServiceController
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<UserImagePreferenceViewModel> GetUserPreferences(string preference)
        {
            bool? preferenceBool = null;
            bool preferenceBoolParse;

            if (!string.IsNullOrEmpty(preference))
            {
                bool.TryParse(preference, out preferenceBoolParse); //sanitization of input
                preferenceBool = preferenceBoolParse;
            }

            return CurrentUser.UserImagePreferences.Where(m=>m.Preference== preferenceBool || !preferenceBool.HasValue).Select(m => new UserImagePreferenceViewModel()
            {
                ImageName = Path.Combine(AppSettings.ImageGalleryFileLocation, m.ImageName),
                ImagePreference = m.Preference
            });
        }
    }
}
