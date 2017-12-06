using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoQingWa_Work_Model.Enum
{
    public enum UserStatu
    {
        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Enable = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Disable = 1
    }
}
