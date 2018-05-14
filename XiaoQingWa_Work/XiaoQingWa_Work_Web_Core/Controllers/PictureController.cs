using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XiaoQingWa_Work_DAL;
using XiaoQingWa_Work_IDAL;

namespace XiaoQingWa_Work_Web_Core.Controllers
{
    public class PictureController : Controller
    {
        //PictureInfoRepository cadal;
        //public PictureController(PictureInfoRepository cadal) { this.cadal = cadal; }

       
        public async Task<IActionResult> Index()
        {
            //var pictureList =await cadal.GetListAsync();
            return View();
        }
    }
}