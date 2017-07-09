using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SqlSugarRepository
{
    /// <summary>
    /// 数据库服务
    /// </summary>
    public class DbRepository : IDisposable
    {
        private List<ISqlSugarClient> _dbs = null;
        private ISqlSugarClient _currentClient = null;
        private SqlBuilder _SqlBuilder = null;
        internal ConnectionConfig _currentConfig = null;

        /// <summary>
        /// Sql拼接器
        /// </summary>
        public SqlBuilder SqlBuilder()
        {
            _SqlBuilder = new SqlBuilder(this);
            return _SqlBuilder;
        }

        /// <summary>
        /// 获取数据库连接实例
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns></returns>
        public static ISqlSugarClient GetInstance(DbType type, string connectionString)
        {
            ISqlSugarClient db = GetConnectionClient(type, connectionString);
            return db;
        }

        /// <summary>
        /// 根据类型获取连接对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ISqlSugarClient GetConnectionClient(DbType type, string connectionString)
        {
            ISqlSugarClient db = null;
            switch (type)
            {
                case DbType.SqlServer:
                    db = new SqlServerSugarClient(connectionString);
                    break;
                case DbType.Sqlite:
                    db = new SqliteSugarClient(connectionString);
                    break;
                case DbType.MySql:
                    db = new MySqlSugarClient(connectionString);
                    break;
                case DbType.Oracle:
                    db = new PlSqlSugarClient(connectionString);
                    break;
            }

            return db;
        }

        /// <summary>
        /// 获取ISugarQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ISugarQueryable<T> GetISugarQueryableByType<T>(DbType type) where T:class,new()
        {

            switch (type)
            {
                case DbType.SqlServer:
                    var queryableSql= new SqlServerQueryable<T>();
                    queryableSql.QueryableCore = new SqlSugar.Queryable<T>();
                    return queryableSql;
                case DbType.Sqlite:
                    var queryableLite = new SqliteQueryable<T>();
                    queryableLite.QueryableCore = new SQLiteSugar.Queryable<T>();
                    return queryableLite;
                case DbType.MySql:
                    var queryableMySql = new MySqlQueryable<T>();
                    queryableMySql.QueryableCore = new MySqlSugar.Queryable<T>();
                    return queryableMySql;
                case DbType.Oracle:
                    var queryableOracle = new OracleQueryable<T>();
                    queryableOracle.QueryableCore = new OracleSugar.Queryable<T>();
                    return queryableOracle;
                default:
                    return null;
            }
        }


        /// <summary>
        /// 获取数据库连接实例
        /// </summary>
        public ISqlSugarClient Database
        {
            get
            {
                var isInit = _dbs == null;
                if (isInit)
                {
                    var fileds = this.GetType().GetFields();
                    Check.Exception(fileds == null || fileds.Count() == 0, InternalConst.ConnectionMessageNoConfig);
                    List<ConnectionConfig> configList = new List<ConnectionConfig>();
                    foreach (var item in fileds)
                    {
                        var itemValue = item.GetValue(this);
                        if (itemValue is ConnectionConfig)
                        {
                            var conObj = (ConnectionConfig)itemValue;
                            ISqlSugarClient db = GetConnectionClient(conObj.DbType, conObj.ConnectionString);
                            db.ConnectionUniqueKey = conObj.UniqueKey;
                            if (_currentClient == null)
                            {
                                _currentClient = db;
                                _currentConfig = conObj;
                            }
                            if (_dbs == null)
                            {
                                _dbs = new List<ISqlSugarClient>();
                            }
                            _dbs.Add(db);
                        }
                    }
                }
                return _currentClient;
            }
        }

 
        /// <summary>
        /// 设置当前连接池
        /// </summary>
        /// <param name="config"></param>
        public void SetCurrent(ConnectionConfig config)
        {
            var currentDb = _dbs.SingleOrDefault(it => it.ConnectionUniqueKey == config.UniqueKey);
            if (currentDb != null)
            {
                _currentClient = currentDb;
                _currentConfig = config;
            }
            else
            {
                Check.Exception(true, InternalConst.ConnectionMessageNoConfig);
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_dbs != null && _dbs.Count > 0)
            {
                foreach (var item in _dbs)
                {
                    item.Dispose();
                }
            }
        }
    }
}
