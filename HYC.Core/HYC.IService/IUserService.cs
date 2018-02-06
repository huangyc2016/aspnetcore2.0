using HYC.Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(UserInfo entity);

        UserInfo GetByID(int ID);
    }
}
