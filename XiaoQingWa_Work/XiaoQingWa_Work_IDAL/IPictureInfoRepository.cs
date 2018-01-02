using System.Collections.Generic;
using System.Data;
using XiaoQingWa_Work_Model.Entity;
namespace XiaoQingWa_Work_IDAL
{
    public interface IPictureInfoRepository : IDependency
    {
        bool ExistPincture(string pictureMD5);
        int AddPictureInfo(PictureInfoEntity model);
        int AddPictureInfo(PictureInfoEntity model, IDbConnection conn, IDbTransaction trans);
        bool DelPictureInfo(int id);
        bool DelPictureInfoBatch(int[] ids);
        PictureInfoEntity GetPictureInfo(int id);
        /// <summary>
        /// 根据Md5查找图片信息
        /// </summary>
        /// <param name="fileMD5"></param>
        /// <returns></returns>
        PictureInfoEntity GetPictureInfoByFileMD5(string fileMD5);
        List<PictureInfoEntity> GetPictureInfoList();
        bool UpdatePictureInfo(PictureInfoEntity entity);
        bool UpdatePictureInfo(PictureInfoEntity entity, IDbConnection conn, IDbTransaction trans);
    }
}