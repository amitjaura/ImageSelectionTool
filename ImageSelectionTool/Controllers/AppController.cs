﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSelectionTool.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
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