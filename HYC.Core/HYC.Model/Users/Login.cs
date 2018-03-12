using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Users
{
    /// <summary>
    /// User登录返回实体
    /// </summary>
    public class Login
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// 会员帐号
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// token
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastChanged { get; set; }
    }
}
