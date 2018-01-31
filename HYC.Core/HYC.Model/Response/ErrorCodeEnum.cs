using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Response
{
    /// <summary>
    /// 错误一般性返回编号
    /// </summary>
    public enum ErrorCodeEnum : int
    {
        /// <summary>
        /// 系统发生错误10000
        /// </summary>
        系统发生错误 = 10000,

        /// <summary>
        /// IP未授权10001,
        /// </summary>
        IP未授权 = 10001,

        /// <summary>
        /// 系统维护中10002,
        /// </summary>
        系统维护中 = 10002,

        /// <summary>
        /// 用户登录失效10003,
        /// </summary>
        用户登录失效 = 10003,

        /// <summary>
        /// DES解密失败10004,
        /// </summary>
        DES解密失败 = 10004,

        /// <summary>
        /// 参数错误10005,
        /// </summary>
        参数错误 = 10005,

        /// <summary>
        /// 无效的厂商编码10006
        /// </summary>
        无效的厂商编码 = 10006,
        /// <summary>
        /// 无权限访问10007
        /// </summary>
        无权限访问 = 10007
    }
}
