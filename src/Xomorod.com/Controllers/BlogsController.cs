﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Xomorod.Com.Controllers
{
    public class BlogsController : BaseController
    {
        // GET: Blogs
        public ActionResult Index()
        {
            ViewBag.Message = "Your blog page.";

            return View();
        }
    }
}