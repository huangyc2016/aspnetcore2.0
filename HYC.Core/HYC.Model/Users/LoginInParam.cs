using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Users
{
    public class LoginInParam
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
    }
}
