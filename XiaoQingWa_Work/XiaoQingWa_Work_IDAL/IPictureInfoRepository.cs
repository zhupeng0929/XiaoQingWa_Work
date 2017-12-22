using System.Collections.Generic;
using System.Data;
using XiaoQingWa_Work_Model.Entity;
namespace XiaoQingWa_Work_IDAL
{
    public interface IPictureInfoRepository : IDependency
    {
        bool AddPictureInfo(PictureInfoEntity model);
        bool AddPictureInfo(PictureInfoEntity model, IDbConnection conn, IDbTransaction trans);
        bool DelPictureInfo(int id);
        bool DelPictureInfoBatch(int[] ids);
        PictureInfoEntity GetPictureInfo(int id);
        List<PictureInfoEntity> GetPictureInfoList();
        bool UpdatePictureInfo(PictureInfoEntity entity);
        bool UpdatePictureInfo(PictureInfoEntity entity, IDbConnection conn, IDbTransaction trans);
    }
}