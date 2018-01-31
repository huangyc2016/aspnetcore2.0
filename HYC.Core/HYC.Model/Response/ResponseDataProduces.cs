using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Response
{
    /// <summary>
    /// 返回数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDataProduces<T>
    {
        /// <summary>
        ///  错误码[0-表示操作成功，大于0表示操作失败]
        ///  10000-系统发生错误,10001-IP未授权,10002-系统维护中,10003-用户登录失效,10004-参数解密失败,10005-参数错误,10006-无效的厂商编码<br />
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public T body { get; set; }
    }
}
