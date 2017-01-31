using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGallery.Models
{
    public class UserImagePreferenceViewModel
    {
        public string ImageName { get; set; }
        public bool ImagePreference { get; set; }
    }

    public class ImageViewModel {
        public ImageViewModel(string imageName, string imagePath)
        {
            SetImageName(imageName);
            SetImagePath(imagePath);
        }
        public string ImageName { get; private set; }
        public void SetImageName(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                throw new ArgumentNullException("Image Name can't be null/empty");
            }
            ImageName = imageName;
        }
        public string ImagePath { get; private set; }
        public void SetImagePath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentNullException("Image Path can't be null/empty");
            }

            ImagePath = imagePath;
        }
    }
}