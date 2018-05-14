using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XiaoQingWa_Work_Web_Core.Models;

namespace XiaoQingWa_Work_Web_Core.Controllers
{
    
    //[Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost,Route("Home/Test")]
        public IActionResult Test(int type, int userid = 0, int page = 1)
        {
            ViewData["Message"] = "Your contact page.";

            return Ok("ss");
        }
    }
}
