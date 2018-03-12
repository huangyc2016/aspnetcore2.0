using Dapper;
using HYC.Common;
using HYC.IRepository;
using HYC.Model.Users;
using Microsoft.Extensions.Options;
using System;
using System.Data;

namespace HYC.Repository
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 构造函数中使用依赖注入
        /// </summary>
        public readonly IOptions<SqlHelper> _optionsAccessor;
        public UserRepository(IOptions<SqlHelper> optionsAccessor)
        {
            this._optionsAccessor = optionsAccessor;
        }


        public int Insert(UserData entity)
        {
            using (IDbConnection dbCon = this._optionsAccessor.Value.BasicDB)
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

        public UserData GetByID(int ID)
        {
            using (IDbConnection dbCon = this._optionsAccessor.Value.BasicDB)
            {
                string sql = @"SELECT [UserName],[Password],[EMail] FROM [dbo].[tb_Users] WHERE ID=@ID";
                var sqlParams = new DynamicParameters();
                sqlParams.Add("@ID", ID, DbType.Int32);
              
                return dbCon.QueryFirstOrDefault<UserData>(sql, sqlParams);
            }
        }

        public UserData Login(string userName, string password)
        {
            using (IDbConnection dbCon = this._optionsAccessor.Value.BasicDB)
            {
                string sql = @"SELECT [ID],[UserName],[Password],[EMail],[LastChanged] FROM [dbo].[tb_Users] WHERE UserName=@UserName AND Password=@Password";
                var sqlParams = new DynamicParameters();
                sqlParams.Add("@UserName", userName, DbType.AnsiString,size:50);
                sqlParams.Add("@Password", password, DbType.AnsiString, size: 50);

                return dbCon.QueryFirstOrDefault<UserData>(sql, sqlParams);
            }
        }

        /// <summary>
        /// 验证是否修改过用户信息(修改过返回True)
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="lastChanged"></param>
        /// <returns>true:修改过,false:未修改过</returns>
        public bool ValidateLastChanged(string userName,string lastChanged)
        {
            using (IDbConnection dbCon = this._optionsAccessor.Value.BasicDB)
            {
                string sql = @"SELECT COUNT(*)AS counts FROM [dbo].[tb_Users] WHERE UserName=@UserName AND LastChanged>@LastChanged";
                var sqlParams = new DynamicParameters();
                sqlParams.Add("@UserName", userName, DbType.AnsiString, size: 50);
                sqlParams.Add("@LastChanged", lastChanged, DbType.AnsiString,size:50);

                var counts = dbCon.ExecuteScalar<int>(sql, sqlParams);
                return counts > 0;

            }
        }
    }
}
