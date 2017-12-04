using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace XiaoQingWa_Work_DAL
{
    public class BaseEntity
    {
        /// <summary>
        ///  测试方法，获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnstr
        {
            get { return WebConfigurationManager.AppSettings["ConnectionString"].ToString(); }

        }
    }

}
