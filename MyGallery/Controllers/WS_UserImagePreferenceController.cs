using MyGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyGallery.Controllers
{
    public class WS_UserImagePreferenceController : BaseServiceController
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<UserImagePreferenceViewModel> GetUserPreferences(string preference)
        {
            bool? preferenceBool = null;
            if (!string.IsNullOrEmpty(preference))
            {
                preferenceBool = Convert.ToBoolean(preference);
            }
            return CurrentUser.UserImagePreferences.Where(m=>m.Preference== preferenceBool || !preferenceBool.HasValue).Select(m => new UserImagePreferenceViewModel()
            {
                ImageName = Path.Combine(AppSettings.ImageGalleryFileLocation, m.ImageName),
                ImagePreference = m.Preference
            });
        }
    }
}
