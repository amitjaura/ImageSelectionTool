using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ImageSelectionTool
{
    public static class AppSettings
    {
        private const string KEY_IMAGEGALLERYFILELOCATION = "workingImageDirectory";
        public static string ImageGalleryFileLocation {
            get {
                return ConfigurationManager.AppSettings[KEY_IMAGEGALLERYFILELOCATION];
            }
        }
    }
}