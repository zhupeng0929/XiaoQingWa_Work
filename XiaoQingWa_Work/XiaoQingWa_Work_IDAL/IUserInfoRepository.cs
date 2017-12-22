using System.Collections.Generic;
using XiaoQingWa_Work_Model.Entity;

namespace XiaoQingWa_Work_IDAL
{
    public interface IUserInfoRepository : IDependency
    {
        UserInfoEntity GetUserInfo(string userName);
        UserInfoEntity GetUserInfo(int userid);
        bool AddUserInfo(UserInfoEntity model);
        bool DelUserInfo(int id);
        bool DelUserInfoBatch(int[] ids);
        bool UpdateUserStatu(int id, int statu);
        bool UpdateUserPassWord(int id, string password);
        List<UserInfoEntity> GetUserInfoListByQueryModel(UserQuery userQuery);
        bool UpdateUserInfo(UserInfoEntity model);
    }
}
