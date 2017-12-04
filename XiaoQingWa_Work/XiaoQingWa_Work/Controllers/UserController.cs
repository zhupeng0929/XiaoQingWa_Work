using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoQingWa_Work_Model.Entity;
using XiaoQingWa_Work_Utility;
namespace XiaoQingWa_Work.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult UserList()
        {
            var userList = userInfoRepository.GetUserInfoList();
            return View(userList);
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserInfoEntity userInfoEntity)
        {
            if (userInfoEntity != null)
            {
                userInfoEntity.PassWord = CommonHelper.Md5(userInfoEntity.PassWord);
                userInfoEntity.CreateDate = DateTime.Now;
                userInfoEntity.UserState = 1;
                var result = userInfoRepository.AddUserInfo(userInfoEntity);
            }


            return View();
        }
    }
}