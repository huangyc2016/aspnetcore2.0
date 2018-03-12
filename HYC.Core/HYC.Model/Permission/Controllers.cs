using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Permission
{
    /// <summary>
    /// 控制器类
    /// </summary>
    public class Controllers
    {
        /// <summary>
        /// 控制器Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 控制器描述
        /// </summary>
        public string Description { get; set; }

        #region ===扩展属性===
        /// <summary>
        /// 所属功能项数目
        /// </summary>
        public int ActionNum { get; set; }

        #endregion
    }
}
