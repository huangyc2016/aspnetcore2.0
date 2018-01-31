using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Response
{
    public class ResponseData
    {
        /// <summary>
        ///  错误码[0-表示操作成功，大于0表示操作失败]
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public object body { get; set; }
    }

    /// <summary>
    /// 返回数组(不带分页总数)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDataArray<T>
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> Data { get; set; }
    }

    /// <summary>
    /// 返回obj
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDataObj<T>
    {
        /// <summary>
        /// 返回对象
        /// </summary>
        public T Data { get; set; }
    }
}

