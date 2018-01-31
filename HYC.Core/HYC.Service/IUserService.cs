using HYC.Model.Users;
using System;

namespace HYC.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(UserInfo entity);

    }
}
