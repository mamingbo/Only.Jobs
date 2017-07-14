using SqlSugar;
using System;

namespace Only.Jobs.Core.Business.Manager
{
    public class BaseManager
    {
        private string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
        }

        private string DbType
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("DbType");
            }
        }

        public SqlSugarClient db
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

                if (_db != null)
                {
                    string BackgroundJobMappingDbTable = GetDbTableNameSetting("BackgroundJobMappingDbTable");
                    BackgroundJobMappingDbTable = string.IsNullOrWhiteSpace(BackgroundJobMappingDbTable) ? "BackgroundJob" : BackgroundJobMappingDbTable;
                    _db.MappingTables.Add("BackgroundJobInfo", BackgroundJobMappingDbTable);

                    string BackgroundJobLogMappingDbTable = GetDbTableNameSetting("BackgroundJobLogMappingDbTable");
                    BackgroundJobLogMappingDbTable = string.IsNullOrWhiteSpace(BackgroundJobLogMappingDbTable) ? "BackgroundJobLog" : BackgroundJobLogMappingDbTable;
                    _db.MappingTables.Add("BackgroundJobLogInfo", BackgroundJobLogMappingDbTable);

                }
                return _db;
            }
        }

        private string GetDbTableNameSetting(string dbName)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(dbName);
        }

    }
}
