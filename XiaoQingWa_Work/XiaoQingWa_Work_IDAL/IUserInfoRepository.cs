using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoQingWa_Work_Model.Entity;

namespace XiaoQingWa_Work_IDAL
{
    public interface IUserInfoRepository : IDependency
    {
        UserInfoEntity GetUserInfo(string userName);
        UserInfoEntity GetUserInfo(int userid);
        bool AddUserInfo(UserInfoEntity model);
        bool DelUserInfo(int id);
        bool UpdateUserStatu(int id, int statu);
        List<UserInfoEntity> GetUserInfoListByQueryModel(UserQuery userQuery);
        bool UpdateUserInfo(UserInfoEntity model);
    }
}
