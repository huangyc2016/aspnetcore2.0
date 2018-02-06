using Dapper;
using HYC.Common;
using HYC.IRepository;
using HYC.Model.Users;
using Microsoft.Extensions.Options;
using System;
using System.Data;

namespace HYC.Repository
{
    public class UserRepository : Construct, IUserRepository
    {
        public UserRepository(IOptions<SqlHelper> optionsAccessor) : base(optionsAccessor)
        {

        }


        public int Insert(UserInfo entity)
        {
            return 1;
            using (IDbConnection dbCon = base._optionsAccessor.Value.BasicDB)
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

        public UserInfo GetByID(int ID)
        {
            using (IDbConnection dbCon = base._optionsAccessor.Value.BasicDB)
            {
                string sql = @"SELECT [UserName],[Password],[EMail] FROM [dbo].[tb_Users] WHERE ID=@ID";
                var sqlParams = new DynamicParameters();
                sqlParams.Add("@ID", ID, DbType.Int32);
              
                return dbCon.QueryFirstOrDefault<UserInfo>(sql, sqlParams);
            }
        }
    }
}
