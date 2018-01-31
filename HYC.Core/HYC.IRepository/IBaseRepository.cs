using System;
using System.Collections.Generic;

namespace HYC.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);
    }
}
