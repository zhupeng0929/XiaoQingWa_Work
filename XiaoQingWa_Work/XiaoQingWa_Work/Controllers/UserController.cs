﻿using System;
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
            return View();
        }
        public ActionResult UserListResult(UserQuery userQuery)
        {
            var userList = userInfoRepository.GetUserInfoListByQueryModel(userQuery);
            return View(userList);
        }

        public ActionResult CreateUser(int? userid)
        {
            var model = new UserInfoEntity();
            if (userid.HasValue)
            {
                model= userInfoRepository.GetUserInfo(userid.Value);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateUser(UserInfoEntity userInfoEntity)
        {
            var result = false;
            if (userInfoEntity != null)
            {
                if (userInfoEntity.UserId == 0)
                {
                    userInfoEntity.PassWord = CommonHelper.Md5(userInfoEntity.PassWord);
                    userInfoEntity.CreateDate = DateTime.Now;
                    userInfoEntity.UserState = 1;
                    result = userInfoRepository.AddUserInfo(userInfoEntity);
                }
                else
                {
                    var uerModel = userInfoRepository.GetUserInfo(userInfoEntity.UserId);
                    uerModel.UserName = userInfoEntity.UserName;
                    uerModel.UserSex = userInfoEntity.UserSex;
                    uerModel.UserPhone = userInfoEntity.UserPhone;
                    uerModel.UserMail = userInfoEntity.UserMail;
                    uerModel.UserAddress = userInfoEntity.UserAddress;
                    //uerModel.PassWord = CommonHelper.Md5(userInfoEntity.PassWord);
                    result = userInfoRepository.UpdateUserInfo(uerModel);
                }
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
        [HttpPost]
        public ActionResult UpdateUserStatu(int id, int statu)
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