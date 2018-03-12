using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Permission
{
    /// <summary>
    /// 功能类
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// 功能Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 功能组Id
        /// </summary>
        public int ActionGroupId { get; set; }

        /// <summary>
        /// 控制器Id
        /// </summary>
        public int ControllerId { get; set; }

        /// <summary>
        /// 功能描述
        /// </summary>
        public string Description { get; set; }
    }
}
