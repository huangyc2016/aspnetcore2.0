using System;
using System.Data;
using System.Data.SqlClient;

namespace HYC.Common
{
    public class SqlHelper
    {

        public  string sqlConnectionLeo { get; set; }
        public  string sqlConnectionHyc { get; set; }

      

        #region Data库连接
        /// <summary>
        /// Leo库
        /// </summary>
        public IDbConnection LeoDB
        {
            get
            {
                return GetSqlConnection(this.sqlConnectionLeo);
            }
        }

        /// <summary>
        /// Hyc库
        /// </summary>
        public IDbConnection HycDB
        {
            get
            {
                return GetSqlConnection(this.sqlConnectionHyc);
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
