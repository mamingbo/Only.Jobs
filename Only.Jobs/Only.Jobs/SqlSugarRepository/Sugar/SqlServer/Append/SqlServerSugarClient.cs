using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;

namespace SqlSugarRepository
{
    internal partial class SqlServerSugarClient : ISqlSugarClient, IDisposable
    {
        SqlSugarClient _db = null;
        public SqlServerSugarClient(string connectionString)
        {
            _db = new SqlSugarClient(connectionString);
        }
        public object GetDb()
        {
            return _db;
        }

        public IClassGenerating ClassGenerating
        {
            get
            {
                return new SqlServerClassGenerating();
            }
        }

        public string ConnectionString
        {
            get
            {
                return _db.ConnectionString;
            }
        }

        public Guid ConnectionUniqueKey
        {
            get;set;
        }

        public string[] DisableInsertColumns
        {
            get
            {
                return _db.DisableInsertColumns;
            }

            set
            {
                _db.DisableInsertColumns = value;
            }
        }

        public string[] DisableUpdateColumns
        {
            get
            {
                return _db.DisableUpdateColumns;
            }

            set
            {
                _db.DisableUpdateColumns = value;
            }
        }

        public Action<string, string> LogEventStarting
        {
            get
            {
                return _db.LogEventStarting;
            }

            set
            {
                _db.LogEventStarting = value;
            }
        }

        public Action<string, string> LogEventCompleted
        {
            get
            {
                return _db.LogEventCompleted;
            }

            set
            {
                _db.LogEventCompleted = value;
            }
        }

        public bool IsEnableLogEvent
        {
            get
            {
                return _db.IsEnableLogEvent;
            }

            set
            {
                _db.IsEnableLogEvent = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return _db.CommandType;
            }

            set
            {
                _db.CommandType = value;
            }
        }

        public bool IsClearParameters
        {
            get
            {
                return _db.IsClearParameters;
            }

            set
            {
                _db.IsClearParameters = value;
            }
        }

        public bool IsGetPageParas
        {
            get
            {
                return _db.IsGetPageParas;
            }

            set
            {
                _db.IsGetPageParas = value;
            }
        }

        public int CommandTimeOut
        {
            get
            {
                return _db.CommandTimeOut;
            }

            set
            {
                _db.CommandTimeOut = value;
            }
        }

        public bool IsEnableAttributeMapping
        {
            get
            {
                return _db.IsEnableAttributeMapping;
            }

            set
            {
                _db.IsEnableAttributeMapping = value;
            }
        }
        public bool IsIgnoreErrorColumns
        {
            get
            {
                return _db.IsIgnoreErrorColumns;
            }

            set
            {
                _db.IsIgnoreErrorColumns = value;
            }
        }

        public string SerializerDateFormat
        {
            get
            {
               return  _db.SerializerDateFormat;
            }

            set
            {
                _db.SerializerDateFormat = value;
            }
        }

        public string CurrentFilterKey
        {
            get
            {
                return _db.CurrentFilterKey;
            }

            set
            {
                _db.CurrentFilterKey = value;
            }
        }

        public void AddDisableInsertColumns(params string[] columns)
        {
            _db.AddDisableInsertColumns(columns);
        }

        public void AddDisableUpdateColumns(params string[] columns)
        {
            _db.AddDisableUpdateColumns(columns);
        }

        public void AddMappingColumn(KeyValue mappingColumn)
        {
            _db.AddMappingColumn(new SqlSugar.KeyValue() { Key = mappingColumn.Key, Value = mappingColumn.Value });
        }

        public void AddMappingTable(KeyValue mappingTable)
        {
            _db.AddMappingTable(new SqlSugar.KeyValue() { Key = mappingTable.Key, Value = mappingTable.Value });
        }

        public void BeginTran()
        {
            _db.BeginTran();
        }

        public void BeginTran(string transactionName)
        {
            _db.BeginTran(transactionName);
        }

        public void CommitTran()
        {
            _db.CommitTran();
        }

        public bool Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _db.Delete(expression);
        }

        public bool Delete<T>(List<T> deleteObjList) where T : class
        {
            return _db.Delete(deleteObjList);
        }

        public bool Delete<T>(T deleteObj) where T : class
        {
            return _db.Delete(deleteObj);
        }

        public bool Delete<T>(string SqlWhereString, object whereObj = null) where T : class
        {
            return _db.Delete<T>(SqlWhereString, whereObj);
        }

        public bool Delete<T, FiledType>(params FiledType[] whereIn) where T : class
        {
            return _db.Delete<T,FiledType>(whereIn);
        }

        public bool Delete<T, FiledType>(Expression<Func<T, object>> expression, List<FiledType> whereIn) where T : class
        {
            return _db.Delete(expression, whereIn);
        }

        public bool Delete<T, FiledType>(Expression<Func<T, object>> expression, params FiledType[] whereIn) where T : class
        {
            return _db.Delete(expression, whereIn);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public int ExecuteCommand(string sql, object pars)
        {
            return _db.ExecuteCommand(sql, pars);
        }

        public int ExecuteCommand(string sql, params SqlParameter[] pars)
        {
            return _db.ExecuteCommand(sql, pars);
        }

        public bool FalseDelete<T>(string field, Expression<Func<T, bool>> expression) where T : class
        {
            return _db.FalseDelete(field, expression);
        }

        public bool FalseDelete<T, FiledType>(string field, params FiledType[] whereIn) where T : class
        {
            return _db.FalseDelete<T, FiledType>(field, whereIn);
        }

        public SqlConnection GetConnection()
        {
            return _db.GetConnection();
        }

        public DataSet GetDataSetAll(string sql, object pars)
        {
            return _db.GetDataSetAll(sql, pars);
        }

        public DataSet GetDataSetAll(string sql, params SqlParameter[] pars)
        {
            return _db.GetDataSetAll(sql, pars);
        }

        public DataTable GetDataTable(string sql, object pars)
        {
            return _db.GetDataTable(sql, pars);
        }

        public DataTable GetDataTable(string sql, params SqlParameter[] pars)
        {
            return _db.GetDataTable(sql, pars);
        }

        public DateTime GetDateTime(string sql, params SqlParameter[] pars)
        {
            return _db.GetDateTime(sql, pars);
        }

        public decimal GetDecimal(string sql, params SqlParameter[] pars)
        {
            return _db.GetDecimal(sql, pars);
        }

        public double GetDouble(string sql, params SqlParameter[] pars)
        {
            return _db.GetDouble(sql, pars);
        }

        public int GetInt(string sql, object pars)
        {
            return _db.GetInt(sql, pars);
        }

        public int GetInt(string sql, params SqlParameter[] pars)
        {
            return _db.GetInt(sql, pars);
        }

        public List<T> GetList<T>(string sql, object pars)
        {
            return _db.GetList<T>(sql, pars);
        }

        public List<T> GetList<T>(string sql, params SqlParameter[] pars)
        {
            return _db.GetList<T>(sql, pars);
        }

        public SqlDataReader GetReader(string sql, object pars)
        {
            return _db.GetReader(sql, pars);
        }

        public SqlDataReader GetReader(string sql, params SqlParameter[] pars)
        {
            return _db.GetReader(sql, pars);
        }

        public object GetScalar(string sql, object pars)
        {
            return _db.GetScalar(sql, pars);
        }

        public object GetScalar(string sql, params SqlParameter[] pars)
        {
            return _db.GetScalar(sql, pars);
        }

        public T GetSingle<T>(string sql, object pars)
        {
            return _db.GetSingle<T>(sql, pars);
        }

        public T GetSingle<T>(string sql, params SqlParameter[] pars)
        {
            return _db.GetSingle<T>(sql, pars);
        }

        public string GetString(string sql, object pars)
        {
            return _db.GetString(sql, pars);
        }

        public string GetString(string sql, params SqlParameter[] pars)
        {
            return _db.GetString(sql, pars);
        }

        public object Insert<T>(T entity, bool isIdentity = true) where T : class
        {
            return _db.Insert(entity, isIdentity);
        }

        public List<object> InsertRange<T>(List<T> entities, bool isIdentity = true) where T : class
        {
            return _db.InsertRange(entities, isIdentity);
        }

        public object InsertOrUpdate<T>(T operationObj) where T : class
        {
            return _db.InsertOrUpdate(operationObj);
        }

        public ISugarQueryable<T> Queryable<T>() where T : class, new()
        {
            ISugarQueryable<T> queryable = new SqlServerQueryable<T>();
            queryable.QueryableCore = _db.Queryable<T>();
            return queryable;
        }

        public ISugarQueryable<T> Queryable<T>(string tableName) where T : class, new()
        {
            ISugarQueryable<T> queryable = new SqlServerQueryable<T>();
            queryable.QueryableCore= _db.Queryable<T>(tableName);
            return queryable;
        }

        public void RemoveAllCache<T>()
        {
            _db.RemoveAllCache<T>();
        }

        public void RollbackTran()
        {
            _db.RollbackTran();
        }

        public void SetFilterItems(Dictionary<string, Func<KeyValueObj>> filterRows)
        {
            Dictionary<string, Func<SqlSugar.KeyValueObj>> values = new Dictionary<string, Func<SqlSugar.KeyValueObj>>();
            foreach (var item in filterRows)
            {
                values.Add(item.Key, () =>
                {
                    var value = item.Value();
                    return new SqlSugar.KeyValueObj()
                    {
                        Key = value.Key,
                        Value = value.Value
                    };
                });
            }
            _db.SetFilterItems(values);
        }

        public void SetFilterItems(Dictionary<string, List<string>> filterColumns)
        {
            _db.SetFilterItems(filterColumns);
        }

        public void SetMappingColumns(List<KeyValue> mappingColumns)
        {
            _db.SetMappingColumns(mappingColumns.Select(it => new SqlSugar.KeyValue() { Key = it.Key, Value = it.Value }).ToList());
        }

        public void SetMappingTables(List<KeyValue> mappingTables)
        {
            _db.SetMappingTables(mappingTables.Select(it => new SqlSugar.KeyValue() { Key = it.Key, Value = it.Value }).ToList());
        }

        public void SetSerialNumber(List<SerialNumber> serNum)
        {
            var values = new List<SqlSugar.PubModel.SerialNumber>();
            foreach (var item in serNum)
            {
                var value = new SqlSugar.PubModel.SerialNumber()
                {
                    FieldName = item.FieldName,
                    TableName = item.TableName,
                    GetNumFunc = item.GetNumFunc,
                };
                if (value.GetNumFuncWithDb != null) {
                    value.GetNumFunc = ()=> {
                        return item.GetNumFuncWithDb(this);
                    };
                }
            }
            _db.SetSerialNumber(values);
        }

        //public Sqlable Sqlable()
        //{
        //    return _db.Sqlable();
        //}

        public bool SqlBulkCopy<T>(List<T> entities) where T : class
        {
            return _db.SqlBulkCopy(entities);
        }

        public bool SqlBulkReplace<T>(List<T> entities) where T : class
        {
            return _db.SqlBulkReplace(entities);
        }

        public List<T> SqlQuery<T>(string sql, object whereObj = null)
        {
            return _db.SqlQuery<T>(sql, whereObj);
        }

        public List<T> SqlQuery<T>(string sql, List<SqlParameter> pars)
        {
            return _db.SqlQuery<T>(sql, pars);
        }

        public List<T> SqlQuery<T>(string sql, SqlParameter[] pars)
        {
            return _db.SqlQuery<T>(sql, pars);
        }

        public dynamic SqlQueryDynamic(string sql, object whereObj = null)
        {
            return _db.SqlQueryDynamic(sql, whereObj);
        }

        public string SqlQueryJson(string sql, object whereObj = null)
        {
            return _db.SqlQueryJson(sql, whereObj);
        }

        public bool Update<T>(T rowObj) where T : class
        {
            return _db.Update(rowObj);
        }

        public bool Update<T>(object rowObj, Expression<Func<T, bool>> expression) where T : class
        {
            return _db.Update(rowObj, expression);
        }

        public bool Update<T>(string setValues, Expression<Func<T, bool>> expression, object whereObj = null) where T : class
        {
            return _db.Update(setValues, expression, whereObj);
        }

        public bool Update<T, FiledType>(object rowObj, params FiledType[] whereIn) where T : class
        {
            return _db.Update<T, FiledType>(rowObj, whereIn);
        }

        public List<bool> UpdateRange<T>(List<T> rowObjList) where T : class
        {
            return _db.UpdateRange(rowObjList);
        }

        public void SetDB<T>(ISugarQueryable<T> queryable) where T : class, new()
        {
            ((Queryable<T>)(queryable.QueryableCore)).DB = _db.Queryable<T>().DB;
        }

        public ISqlable Sqlable()
        {
            SqlServerSqlable reval = new SqlServerSqlable();
            reval.SqlableCore = _db.Sqlable();
            return reval;
        }
    }
}
