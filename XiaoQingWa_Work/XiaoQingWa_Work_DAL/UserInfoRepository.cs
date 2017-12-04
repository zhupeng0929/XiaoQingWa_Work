using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoQingWa_Work_IDAL;
using XiaoQingWa_Work_Model.Entity;

namespace XiaoQingWa_Work_DAL
{
    /// <summary>
    /// UserInfoDAL数据访问类
    /// </summary>
    public class UserInfoRepository : BaseEntity, IUserInfoRepository
    {
        /// <summary>
        /// 新增实体--事物
        /// </summary>
        public bool AddUserInfo(UserInfoEntity model, IDbConnection conn, IDbTransaction trans)
        {
            var result = conn.Insert<int>(model, trans);
            if (result > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        public bool AddUserInfo(UserInfoEntity model)
        {
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                var result = conn.Insert<int>(model);
                if (result > 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 获取类别实体根据ID
        /// </summary>
        /// <returns></returns>
        public UserInfoEntity GetUserInfo(int id)
        {
            var mResult = new UserInfoEntity();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                mResult = conn.Get<UserInfoEntity>(id);
            }
            return mResult;
        }
        public UserInfoEntity GetUserInfo(string userName)
        {
            var mResult = new UserInfoEntity();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                string strSql = "Select * from UserInfo where username=@username";
                var param = new { username = userName };
                mResult = conn.Query<UserInfoEntity>(strSql, param).FirstOrDefault();
            }
            return mResult;
        }
        public List<UserInfoEntity> GetUserInfoList()
        {
            var mResult = new List<UserInfoEntity>();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                mResult = conn.GetList<UserInfoEntity>().ToList();
            }
            return mResult;
        }
        /// <summary>
        /// 更新实体列表
        /// </summary>
        /// <returns></returns>
        public int UpdateUserInfo(UserInfoEntity entity)
        {
            int row;
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                row = conn.Update(entity);
            }
            return row;
        }
        /// <summary>
        /// 更新实体列表--事物
        /// </summary>
        /// <returns></returns>
        public int UpdateUserInfo(UserInfoEntity entity, IDbConnection conn, IDbTransaction trans)
        {
            int row;
            row = conn.Update(entity, trans);
            return row;
        }
    }
}
