using Dapper;
using HYC.Common;
using HYC.Model.Users;
using Microsoft.Extensions.Options;
using System;
using System.Data;

namespace HYC.Repository
{
    public class UserRepository: Construct, IUserRepository
    {
        public UserRepository(IOptions<SqlHelper> optionsAccessor):base(optionsAccessor)
        {
            
        }
      
 
        public int Insert(UserInfo entity)
        {
            using (IDbConnection dbCon = base._optionsAccessor.Value.LeoDB)
            {
                string sql = @"INSERT INTO [dbo].[tb_Users]([UserName],[Password],[EMail])
                                      VALUES(@UserName,@Password,@EMail)";
                var sqlParams = new DynamicParameters();
                sqlParams.Add("@UserName", entity.UserName, DbType.AnsiString, size: 50);
                sqlParams.Add("@Password", entity.Password, DbType.AnsiString, size: 50);
                sqlParams.Add("@EMail", entity.EMail, DbType.AnsiString, size: 500);
                return dbCon.Execute(sql, sqlParams);
            }
        }
    }
}
