//---------------------------------------------------------------------------------
// <copyright company="XiaoQingWa" file="PictureInfoRespository.cs" >
//      Author: Peng.Zhu
//      Create Time: 2017/12/20 21:13:26
//      Description: 
// </copyright>
//---------------------------------------------------------------------------------

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using XiaoQingWa_Work_IDAL;
using XiaoQingWa_Work_Model.Entity;

namespace XiaoQingWa_Work_DAL
{
    /// <summary>
    /// PictureInfoDAL数据访问类
    /// </summary>
    public partial class PictureInfoRepository : BaseEntity, IPictureInfoRepository
    {
        /// <summary>
        /// 图片是否存在
        /// </summary>
        /// <returns></returns>
        public bool ExistPincture(string pictureMD5)
        {
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                string strSql = "select * from PictureInfo where FileMD5=@FileMD5";
                var param = new { FileMD5 = pictureMD5 };
                var result = conn.Execute(strSql, param);
                if (result > 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        public int AddPictureInfo(PictureInfoEntity model)
        {
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                var result = conn.Insert<int>(model);
                return result;
            }
        }
        /// <summary>
        /// 新增实体--事物
        /// </summary>
        public int AddPictureInfo(PictureInfoEntity model, IDbConnection conn, IDbTransaction trans)
        {
            var result = conn.Insert<int>(model, trans);
            return result;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        public bool DelPictureInfo(int id)
        {
            if (id > 0)
            {
                using (IDbConnection conn = new SqlConnection(GetConnstr))
                {
                    string strSql = "delete from PictureInfo where Id=@Id";
                    var param = new { Id = id };
                    var result = conn.Execute(strSql, param);
                    if (result > 0)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelPictureInfoBatch(int[] ids)
        {
            if (ids.Length > 0)
            {
                using (IDbConnection conn = new SqlConnection(GetConnstr))
                {
                    string strSql = "delete from  PictureInfo where Id in @Id ";

                    DynamicParameters param = new DynamicParameters();
                    param.Add("Id", ids);
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
        public PictureInfoEntity GetPictureInfo(int id)
        {
            var mResult = new PictureInfoEntity();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                mResult = conn.Get<PictureInfoEntity>(id);
            }
            return mResult;
        }

        public PictureInfoEntity GetPictureInfoByFileMD5(string fileMD5)
        {
            var mResult = new PictureInfoEntity();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                string strSql = "select * from PictureInfo where FileMD5=@FileMD5";
                var param = new { FileMD5 = fileMD5 };
                mResult = conn.Query<PictureInfoEntity>(strSql, param).FirstOrDefault();
            }
            return mResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PictureInfoEntity> GetPictureInfoList()
        {
            var mResult = new List<PictureInfoEntity>();
            using (IDbConnection conn = new SqlConnection(GetConnstr))
            {
                mResult = conn.GetList<PictureInfoEntity>().ToList();
            }
            return mResult;
        }
        /// <summary>
        /// 更新实体列表
        /// </summary>
        /// <returns></returns>
        public bool UpdatePictureInfo(PictureInfoEntity entity)
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
        public bool UpdatePictureInfo(PictureInfoEntity entity, IDbConnection conn, IDbTransaction trans)
        {
            int row;
            row = conn.Update(entity, trans);
            return row > 0;
        }
    }
}