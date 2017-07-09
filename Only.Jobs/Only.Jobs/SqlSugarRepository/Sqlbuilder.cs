using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlSugarRepository
{
    /// <summary>
    /// Sql连接对象
    /// </summary>
    public class SqlBuilder
    {
        private StringBuilder sqlSb = new StringBuilder();
        private DbType? _type = null;
        /// <summary>
        /// 添加字符串
        /// </summary>
        /// <param name="sql"></param>
        public void Append(string sql)
        {
            sqlSb.Append(sql);
        }
        /// <summary>
        /// 添加字符串
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        public void AppendFormat(string sql, params object[] args)
        {
            sqlSb.AppendFormat(sql, args);
        }
        /// <summary>
        /// 转成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var reval = sqlSb.ToString();
            var regStr = @"\[[A-Z]{1,10}DB\]\:[^\[]+";
            if (Regex.IsMatch(reval, regStr))
            {
                var sqls = Regex.Matches(reval, regStr).Cast<Match>().Select(it => it.Value).ToArray();
                switch (_type)
                {
                    case DbType.SqlServer:
                        reval = GetSqlByKey("[MSSQLDB]:", reval, sqls);
                        break;
                    case DbType.Sqlite:
                        reval = GetSqlByKey("[SQLITEDB]:", reval, sqls);
                        break;
                    case DbType.MySql:
                        reval = GetSqlByKey("[MYSQLDB]:", reval, sqls);
                        break;
                    case DbType.Oracle:
                        reval = GetSqlByKey("[ORACLEDB]:", reval, sqls);
                        break;
                }
            }
            return reval;
        }

        private static string GetSqlByKey(string key, string reval, string[] sqls)
        {
            var sql = sqls.Where(it => it.Contains(key)).SingleOrDefault();
            if (sql == null)
            {
                sql = sqls.Where(it => it.Contains("[OTHERDB]:")).SingleOrDefault();
                if (sql == null)
                {
                    sql = reval;
                }
            }
            if (sql == null)
            {
                sql = reval;
            }
            else
            {
                var regStr = @"\[[A-Z]{1,10}DB\]:";
                sql = Regex.Replace(sql, regStr, "");
            }
            return sql;
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="db"></param>
        public SqlBuilder(DbRepository db)
        {
            _type = db._currentConfig.DbType;
        }
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="db"></param>
        public SqlBuilder(ISqlSugarClient db)
        {
            if (db is SqlServerSugarClient)
            {
                _type = DbType.SqlServer;
            }
            else if (db is MySqlSugarClient)
            {
                _type = DbType.MySql;
            }
            else if (db is SqliteSugarClient)
            {
                _type = DbType.Sqlite;
            }
            else if (db is PlSqlSugarClient)
            {
                _type = DbType.Oracle;
            }
        }
        private SqlBuilder()
        {

        }
    }
}
