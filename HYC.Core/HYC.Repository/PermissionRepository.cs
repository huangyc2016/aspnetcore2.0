using System;
using System.Collections.Generic;
using System.Text;
using HYC.IRepository;
using HYC.Model.Permission;
using Dapper;
using System.Data;
using Microsoft.Extensions.Options;
using HYC.Common;
using System.Linq;

namespace HYC.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        /// <summary>
        /// 构造函数中使用依赖注入
        /// </summary>
        public readonly IOptions<SqlHelper> _dbAccessor;

        public readonly IRedisCache _redisAccessor;
        public PermissionRepository(IOptions<SqlHelper> dbAccessor, IRedisCache redisAccessor)
        {
            this._dbAccessor = dbAccessor;
            this._redisAccessor = redisAccessor;
        }

        /// <summary>
        /// 通过UserId获取用户授权的功能项
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ActionAuthorizes> GetActionAuthorizesList(int userId)
        {
            var key = RedisKeys.UserAction;
            List<ActionAuthorizes> list = null;
            list = this._redisAccessor.AutoRedis<List<ActionAuthorizes>>(key, () =>
            {
                 using (IDbConnection dbCon = this._dbAccessor.Value.BasicDB)
                 {
                     string sql = @"SELECT [Id],[UserId],[ActionId],[ActionName] FROM [dbo].[tb_ActionAuthorizes] WHERE UserId=@UserId";
                     var sqlParams = new DynamicParameters();
                     sqlParams.Add("@UserId", userId, DbType.Int32);
                     var data = dbCon.Query<ActionAuthorizes>(sql, sqlParams).ToList();
                     return data;
                 }
            }, new TimeSpan(0, 30, 0));
            return list;
        }
    }
}
