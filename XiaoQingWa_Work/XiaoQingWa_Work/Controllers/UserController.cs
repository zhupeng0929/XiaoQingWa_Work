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
            var result = false;
            if (userInfoEntity != null)
            {
                userInfoEntity.PassWord = CommonHelper.Md5(userInfoEntity.PassWord);
                userInfoEntity.CreateDate = DateTime.Now;
                userInfoEntity.UserState = 1;
                result = userInfoRepository.AddUserInfo(userInfoEntity);
            }
            ReturnJsonMessage msg = new ReturnJsonMessage();

            msg.Text = result ? "保存成功" : "保存失败";
            msg.Value = result ? "success" : "error";

            return Json(msg);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var result = false;
            result = userInfoRepository.DelUserInfo(id);

            ReturnJsonMessage msg = new ReturnJsonMessage();

            msg.Text = result ? "删除成功" : "删除失败";
            msg.Value = result ? "success" : "error";

            return Json(msg);
        }
        public ActionResult UpdateUserStatu(int id,int statu)
        {
            var result = false;
            result = userInfoRepository.UpdateUserStatu(id, statu);

            ReturnJsonMessage msg = new ReturnJsonMessage();

            msg.Text = result ? "操作成功" : "操作失败";
            msg.Value = result ? "success" : "error";

            return Json(msg);
        }
        
    }
}