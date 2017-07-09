using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    /// <summary>
    /// 工具扩展 
    /// </summary>
    public static class SqlbuilderExtensions
    {
        /// <summary>
        /// 创建SQL连接器
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static SqlBuilder Sqlbuilder(this ISqlSugarClient db)
        {
            return new SqlBuilder(db);
        }
        /// <summary>
        /// 添加SqlServer标识
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlBuilder ToSqlServer(this SqlBuilder thisValue, string sql)
        {
            thisValue.Append("[MSSQLDB]:" + sql);
            return thisValue;
        }
        /// <summary>
        /// 添加MySql标识
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlBuilder ToMySql(this SqlBuilder thisValue, string sql)
        {
            thisValue.Append("[MYSQLDB]:" + sql);
            return thisValue;
        }
        /// <summary>
        /// 添加Oracle标识
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlBuilder ToOracle(this SqlBuilder thisValue, string sql)
        {
            thisValue.Append("[ORACLEDB]:" + sql);
            return thisValue;
        }
        /// <summary>
        /// 添加Sqlite标识
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlBuilder ToSqlite(this SqlBuilder thisValue, string sql)
        {
            thisValue.Append("[SQLITEDB]:" + sql);
            return thisValue;
        }
        /// <summary>
        /// 添加默认标识
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlBuilder ToOther(this SqlBuilder thisValue, string sql)
        {
            thisValue.Append("[OTHERDB]:" + sql);
            return thisValue;
        }

    }
}
