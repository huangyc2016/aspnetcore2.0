using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Permission
{
    /// <summary>
    /// 功能授权类
    /// </summary>
    public class ActionAuthorizes
    {
        /// <summary>
        /// 功能授权Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 功能Id
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string ActionName { get; set; }
    }
}
