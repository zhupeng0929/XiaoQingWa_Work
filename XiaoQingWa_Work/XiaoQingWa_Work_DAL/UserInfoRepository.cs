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
        /// 删除数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public bool DelUserInfo(int id)
        {
            if (id > 0)
            {
                using (IDbConnection conn = new SqlConnection(GetConnstr))
                {
                    string strSql = "delete from UserInfo where UserId=@UserId";
                    var param = new { UserId = id };
                    var result = conn.Execute(strSql, param);
                    if (result > 0)
                        return true;
                }
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
        public List<UserInfoEntity> GetUserInfoList(UserQuery userQuery)
        {
            var mResult = new List<UserInfoEntity>();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                mResult = conn.GetList<UserInfoEntity>().ToList();
            }
            return mResult;
        }
        public List<UserInfoEntity> GetUserInfoListByQueryModel(UserQuery userQuery)
        {
            var mResult = new List<UserInfoEntity>();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                StringBuilder strSql = new StringBuilder("Select * from UserInfo where 1=1 ");

                if (userQuery.datemin != null && userQuery.datemin != new DateTime(1900, 1, 1))
                {
                    strSql.Append(" and  CreateDate>=@datemin ");
                }
                if (userQuery.datemax != null && userQuery.datemax != new DateTime(1900, 1, 1))
                {
                    strSql.Append(" and  CreateDate<@datemax ");
                }
                if (!string.IsNullOrWhiteSpace(userQuery.keyWords))
                {
                    strSql.Append(" and  (UserName=@keyWords or UserPhone=@keyWords or UserMail=@keyWords ) ");
                }
                var param = new
                {
                    datemin = userQuery.datemin,
                    datemax = userQuery.datemax,
                    keyWords = userQuery.keyWords
                };

                mResult = conn.Query<UserInfoEntity>(strSql.ToString(), param).ToList();
            }
            return mResult;
        }

        /// <summary>
        /// 更新实体列表
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfoEntity entity)
        {
            int row;
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                row = conn.Update(entity);
            }
            return row > 0;
        }
        /// <summary>
        /// 更新实体列表--事物
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfoEntity entity, IDbConnection conn, IDbTransaction trans)
        {
            int row;
            row = conn.Update(entity, trans);
            return row > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateUserStatu(int id, int state)
        {
            if (id > 0)
            {
                using (IDbConnection conn = new SqlConnection(GetConnstr))
                {
                    string strSql = "update  UserInfo set UserState=@UserState where UserId=@UserId";
                    var param = new { UserId = id, UserState = state };
                    var result = conn.Execute(strSql, param);
                    if (result > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
