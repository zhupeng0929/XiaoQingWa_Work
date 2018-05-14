using Pechkin;
using Pechkin.Synchronized;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XiaoQingWa_Work.Controllers
{
    public class PictureController : BaseController
    {
        // GET: Picture
        public ActionResult PictureList()
        {
            return View();
        }
        public ActionResult PictureList_R()
        {
            var pictureList = pictureInfoRepository.GetList();
            return View(pictureList);
        }

        public ActionResult AddPicture()
        {
            return View();
        }
        public ActionResult PictureShow()
        {
            var pictureList = pictureInfoRepository.GetList();
            return View(pictureList);
        }
        public ActionResult ExportDemo()
        {
            SynchronizedPechkin sc = new SynchronizedPechkin(new GlobalConfig()
                .SetMargins(new Margins() { Left = 0, Right = 0, Top = 0, Bottom = 0 })); //设置边距

            ObjectConfig oc = new ObjectConfig();

            oc.SetPrintBackground(true).SetRunJavascript(true).SetScreenMediaType(true)
                .SetLoadImages(true)
                .SetPageUri("http://drp.xiaoni.com/recommendcase/FindCaseDetail.aspx?findid=657");

            byte[] buf = sc.Convert(oc);

            return File(buf, "application/pdf", "download.pdf");
        }
    }
}