using SqlSugar;
using System;

namespace Only.Jobs.Core.Business.Manager
{
    public class BaseManager
    {
        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
        }

        private static string DbType
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("DbType");
            }
        }

        public static SqlSugarClient db
        {
            get
            {
                SqlSugarClient _db = null;

                if (DbType.ToLower() == "mysql")
                {
                    _db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString, DbType = SqlSugar.DbType.MySql, IsAutoCloseConnection = true });
                }
                else if (DbType.ToLower() == "sqlserver")
                {
                    _db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = ConnectionString, DbType = SqlSugar.DbType.SqlServer, IsAutoCloseConnection = true });
                }
                else
                {
                    throw new Exception("DbType:" + DbType + " 未知");
                }

                _db.Ado.IsEnableLogEvent = false;
                //_db.Ado.LogEventStarting = (sql, pars) =>
                //{
                //    Console.WriteLine(sql + "\r\n" + db.RewritableMethods.SerializeObject(pars));
                //    Console.WriteLine();
                //};
                return _db;
            }
        }
    }
}
