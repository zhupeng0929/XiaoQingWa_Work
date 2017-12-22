using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XiaoQingWa_Work.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        public ActionResult PictureList()
        {
            return View();
        }
        public ActionResult AddPicture()
        {
            return View();
        }
    }
}