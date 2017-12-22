using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoQingWa_Work_Utility;
namespace XiaoQingWa_Work.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SaveUploadFile()
        {
            HttpFileCollectionBase imgUpFile = Request.Files;
            if (imgUpFile == null || imgUpFile.Count == 0)
            {
                return Content("上传文件不能为空", "text/html;charset=UTF-8");
            }
            try
            {
                string filePath = UploadHelper.SaveFileMethod(imgUpFile[0]);
                return Content("success|" + filePath, "text/html;charset=UTF-8");
            }
            catch (Exception ex)
            {
                return Content(ex.Message, "text/html;charset=UTF-8");
            }
        }
    }
}