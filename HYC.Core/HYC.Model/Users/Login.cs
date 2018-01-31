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
        public Int64 UserID { get; set; }

        /// <summary>
        /// 会员帐号
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
    }
}
