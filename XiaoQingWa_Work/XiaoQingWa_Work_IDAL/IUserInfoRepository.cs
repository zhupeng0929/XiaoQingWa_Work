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
        bool AddUserInfo(UserInfoEntity model);
        bool DelUserInfo(int id);
        List<UserInfoEntity> GetUserInfoList();
    }
}
