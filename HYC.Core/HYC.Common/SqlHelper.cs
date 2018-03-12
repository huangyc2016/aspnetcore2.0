using System;
using System.Data;
using System.Data.SqlClient;

namespace HYC.Common
{
    public class SqlHelper
    {

        public  string sqlConnectionBasic { get; set; }
        public  string sqlConnectionRise { get; set; }

        #region Data库连接
        /// <summary>
        /// BasicDB
        /// </summary>
        public IDbConnection BasicDB
        {
            get
            {
                return GetSqlConnection(this.sqlConnectionBasic);
            }
        }

        /// <summary>
        /// RiseDB
        /// </summary>
        public IDbConnection RiseDB
        {
            get
            {
                return GetSqlConnection(this.sqlConnectionRise);
            }
        }
        #endregion

       

        /// <summary>
        /// 数据统计连接对象(open)
        /// </summary>
        /// <param name="sqlConnectionString"></param>
        /// <returns></returns>
        private IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}
