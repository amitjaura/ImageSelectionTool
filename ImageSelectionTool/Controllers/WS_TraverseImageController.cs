using ImageSelectionTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Web;

namespace ImageSelectionTool.Controllers
{
    public class WS_TraverseImageController : BaseServiceController
    {
        /// <summary>
        /// Method to return path of random Image, one of the key business logic for the task
        /// *** make sure to exclude images which are already added to user's collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ImageViewModel GetRandomImage()
        {
            //get files which are already marked by current user
            IEnumerable<string> filesAlreadyMarked = CurrentUser.UserImagePreferences.Select(m => m.ImageName);


            string fullPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, AppSettings.ImageGalleryFileLocation);
            string[] imageFileExtensions = new string[] { ".jpg", ".jpeg", ".png" }; //we can add other extensions later. but a good soultion is to have an enum
            DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
            IEnumerable<FileInfo> galleryFiles = directoryInfo.GetFiles().Where(m => !filesAlreadyMarked.Contains(m.Name) && imageFileExtensions.Contains(m.Extension.ToLower()));

            FileInfo randomImage = galleryFiles.ElementAt(new Random().Next(galleryFiles.Count()));
            return new ImageViewModel(randomImage.Name, Path.Combine(AppSettings.ImageGalleryFileLocation, randomImage.Name));
        }

        [HttpPost]
        [Authorize]
        public HttpResponseMessage SavePreference(UserImagePreferenceViewModel preference)
        {
            try
            {
                //please update if we already have preferene for selected image
                if (CurrentUser.UserImagePreferences.Any(m => m.ImageName.ToLower() == preference.ImageName.ToLower()))
                {
                    UserImagePreference preferenceEntity = CurrentUser.UserImagePreferences.First(m => m.ImageName.ToLower() == preference.ImageName.ToLower());
                    preferenceEntity.Preference = preference.ImagePreference;
                }
                else //otherwise enter a new record
                {
                    CurrentUser.UserImagePreferences.Add(new UserImagePreference(preference.ImageName, preference.ImagePreference));
                }

                UserManager.Update(CurrentUser);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
