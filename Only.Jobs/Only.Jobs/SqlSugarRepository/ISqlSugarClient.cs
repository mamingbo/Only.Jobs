using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace SqlSugarRepository
{
    /// <summary>
    /// 连接数据库对象
    /// </summary>
    public partial interface ISqlSugarClient : IDisposable
    {
        /// <summary>
        /// 获取db对象
        /// </summary>
        /// <returns></returns>
        object GetDb();

        /// <summary>
        /// 生成实体的对象
        /// </summary>
        IClassGenerating ClassGenerating { get; }

        /// <summary>
        /// 连接唯一KEY
        /// </summary>
        Guid ConnectionUniqueKey { get; set; }

        /// <summary>
        /// 当前过滤器的KEY
        /// </summary>
        string CurrentFilterKey { get; set; }

        /// <summary>
        /// 设置序列化json的日期格式
        /// </summary>
       string SerializerDateFormat { get; set; }

        #region Sugar
        /// <summary>
        /// 是否启动属性映射
        /// </summary>
        bool IsEnableAttributeMapping { get; set; }
        /// <summary>
        /// 是否启用日志事件(默认为:false)
        /// </summary>
        bool IsEnableLogEvent { get; set; }
        /// <summary>
        /// 如何解释命令字符串 默认为Text 
        /// </summary>
        CommandType CommandType { get; set; }
        /// <summary>
        /// 是否清空SqlParameters
        /// </summary>
        bool IsClearParameters { get; set; }
        /// <summary>
        /// 是否排除非数据库字段
        /// </summary>
        bool IsIgnoreErrorColumns { get; set; }
        /// <summary>
        /// 将页面参数自动填充到SqlParameter []，无需在程序中指定参数
        /// 例如：
        ///     var list = db.Queryable&lt;Student&gt;().Where("id=@id").ToList();
        ///     以前写法
        ///     var list = db.Queryable&lt;Student&gt;().Where("id=@id", new { id=Request["id"] }).ToList();
        /// </summary>
        bool IsGetPageParas { get; set; }
        /// <summary>
        /// 设置在终止执行命令的尝试并生成错误之前的等待时间。（单位：秒）
        /// </summary>
        int CommandTimeOut { get; set; }
        /// <summary>
        /// 执行访数据库前的回调函数  (sql,pars)=>{}
        /// </summary>
        Action<string, string> LogEventStarting { get; set; }
        /// <summary>
        /// 执行访数据库后的回调函数  (sql,pars)=>{}
        /// </summary>
        Action<string, string> LogEventCompleted { get; set; }
        /// <summary>
        /// 当前连接字符串
        /// </summary>
        string ConnectionString { get; }
        /// <summary>
        /// 设置禁止插入的列
        /// </summary>
        string[] DisableInsertColumns { get; set; }
        /// <summary>
        /// 设置禁止更新的列
        /// </summary>
        string[] DisableUpdateColumns { get; set; }
        /// <summary>
        /// 添加禁止插入列
        /// </summary>
        /// <param name="columns"></param>
        void AddDisableInsertColumns(params string[] columns);
        /// <summary>
        /// 添加禁止更新列
        /// </summary>
        /// <param name="columns"></param>
        void AddDisableUpdateColumns(params string[] columns);
        /// <summary>
        /// 添加实体字段与数据库字段的映射，Key为实体字段 Value为表字段名称 （注意：不区分表，设置后所有表通用）
        /// </summary>
        /// <param name="mappingColumn"></param>
        void AddMappingColumn(KeyValue mappingColumn);
        /// <summary>
        /// 添加实体类与表名的映射， Key为实体类 Value为表名
        /// </summary>
        /// <param name="mappingTable"></param>
        void AddMappingTable(KeyValue mappingTable);
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        bool Delete<T>(T deleteObj) where T : class;
        /// <summary>
        /// 根据实体集合删除（对性能没有要求可以使用,否则请使用其它重载方法）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteObjList"></param>
        /// <returns>全部删除成功返回true</returns>
        bool Delete<T>(List<T> deleteObjList) where T : class;
        /// <summary>
        /// 根据表达式删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">表达式条件</param>
        /// <returns>删除成功返回true</returns>
        bool Delete<T>(Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 根据Where字符串删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlWhereString">不包含Where的字符串</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns>删除成功返回true</returns>
        bool Delete<T>(string SqlWhereString, object whereObj = null) where T : class;
        /// <summary>
        /// 根据主键集合批量删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="FiledType">主键类型</typeparam>
        /// <param name="whereIn">主键集合</param>
        /// <returns>删除成功返回true</returns>
        bool Delete<T, FiledType>(params FiledType[] whereIn) where T : class;
        /// <summary>
        /// 根据指定列集合批量删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="FiledType">指定列的类型</typeparam>
        /// <param name="expression">表达式条件</param>
        /// <param name="whereIn">批定列值的集合</param>
        /// <returns>删除成功返回true</returns>
        bool Delete<T, FiledType>(Expression<Func<T, object>> expression, params FiledType[] whereIn) where T : class;
        /// <summary>
        /// 根据指定列集合批量删除数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="FiledType">指定列的类型</typeparam>
        /// <param name="expression">表达式条件</param>
        /// <param name="whereIn">批定列值的集合</param>
        bool Delete<T, FiledType>(Expression<Func<T, object>> expression, List<FiledType> whereIn) where T : class;
        /// <summary>
        /// 状态删除
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="field">标识删除的字段</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>将field的值更新为1,则返回true表示状态删除成功</returns>
        bool FalseDelete<T>(string field, Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 状态删除 
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="FiledType">主键类型</typeparam>
        /// <param name="field">标识删除的字段</param>
        /// <param name="whereIn">主键集合</param>
        /// <returns>将field的值更新为1,则返回true表示状态删除成功</returns>
        bool FalseDelete<T, FiledType>(string field, params FiledType[] whereIn) where T : class;
        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="isIdentity">过期参数无需填写</param>
        /// <returns>默认返回Identity，如果没有Identity执行成功将返回true</returns>
        object Insert<T>(T entity, bool isIdentity = true) where T : class;
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">插入对象的集合</param>
        /// <param name="isIdentity">过期参数无需填写</param>
        /// <returns>默认返回Identity的集合，如果没有Identity执行成功将返回bool的集合</returns>
        List<object> InsertRange<T>(List<T> entities, bool isIdentity = true) where T : class;
        /// <summary>
        /// 主键有值则更新，无值则插入，不支持复合主键。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationObj">操作的实体对象</param>
        /// <returns>更新返回bool,插入如果有自增列返回自增列的值否则也返回bool</returns>
        object InsertOrUpdate<T>(T operationObj) where T : class;
        /// <summary>
        /// 创建拉姆达查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ISugarQueryable<T> Queryable<T>() where T : class, new();
        /// <summary>
        /// 创建拉姆达查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">T类型对应的真实表名</param>
        /// <returns></returns>
        ISugarQueryable<T> Queryable<T>(string tableName) where T : class, new();
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void RemoveAllCache<T>();
        /// <summary>
        /// 设置过滤器（用户权限过滤）
        /// </summary>
        /// <param name="filterColumns">参数Dictionary string 为过滤器的名称 , Dictionary List&lt;string&gt;为允许查询的列的集合</param>
        void SetFilterItems(Dictionary<string, List<string>> filterColumns);
        /// <summary>
        /// 设置过滤器（用户权限过滤）
        /// </summary>
        /// <param name="filterRows">参数Dictionary string 为过滤器的名称 , Dictionary Func&lt;KeyValueObj&gt; 为过滤函数 (KeyValueObj 中的 Key为Sql条件,Value为Sql参数)</param>
        void SetFilterItems(Dictionary<string, Func<KeyValueObj>> filterRows);
        /// <summary>
        /// 设置实体字段与数据库字段的映射，Key为实体字段 Value为表字段名称 （注意：不区分表，设置后所有表通用）
        /// </summary>
        /// <param name="mappingColumns"></param>
        void SetMappingColumns(List<KeyValue> mappingColumns);
        /// <summary>
        /// 设置实体类与表名的映射， Key为实体类 Value为表名
        /// </summary>
        /// <param name="mappingTables"></param>
        void SetMappingTables(List<KeyValue> mappingTables);
        /// <summary>
        /// 设置流水号 
        /// </summary>
        /// <param name="serNum">设置流水号所需要的参数集合</param>
        void SetSerialNumber(List<SerialNumber> serNum);

        /// <summary>
        /// 创建复杂查询对象
        /// </summary>
        /// <returns></returns>
        ISqlable Sqlable();

        /// <summary>
        /// 大数据插入
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>全部插入成功返回true</returns>
        bool SqlBulkCopy<T>(List<T> entities) where T : class;
        /// <summary>
        /// 大数据更新 支持IsIgnoreErrorColumns和isDisableUpdateColumns
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>全部更新成功返回true</returns>
        bool SqlBulkReplace<T>(List<T> entities) where T : class;
        /// <summary>
        /// 根据SQL语句将结果集映射到List&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">SqlParameter的集合</param>
        /// <returns>T的集合</returns>
        List<T> SqlQuery<T>(string sql, SqlParameter[] pars);
        /// <summary>
        /// 根据SQL语句将结果集映射到List&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">SqlParameter集合</param>
        /// <returns>T的集合</returns>
        List<T> SqlQuery<T>(string sql, List<SqlParameter> pars);
        /// <summary>
        /// 根据SQL语句将结果集映射到List&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns>T的集合</returns>
        List<T> SqlQuery<T>(string sql, object whereObj = null);

        /// <summary>
        /// 将当前对象赋值给queryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        void SetDB<T>(ISugarQueryable<T> queryable) where T : class, new();

        /// <summary>
        /// 根据SQL语句将结果集映射到dynamic
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns>动态集合</returns>
        dynamic SqlQueryDynamic(string sql, object whereObj = null);
        /// <summary>
        /// 根据SQL语句将结果集映射到json
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns>JSON数据</returns>
        string SqlQueryJson(string sql, object whereObj = null);
        /// <summary>
        /// 将实体对象更新到数据库
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="rowObj">rowObj必需包含主键并且不能为匿名对象</param>
        /// <returns>更新成功返回true</returns>
        bool Update<T>(T rowObj) where T : class;
        /// <summary>
        /// 根据表达式条件将实体对象更新到数据库
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="rowObj">rowObj为匿名对象时只更新指定列( 例如:new{ name='abc'}只更新name )，为T类型将更新整个实体(排除主键、自增列和禁止更新列)</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>更新成功返回true</returns>
        bool Update<T>(object rowObj, Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 根据表达式条件将实体对象更新到数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setValues">set后面的部分字符串 例如( id=@id,num=num+1 )</param>
        /// <param name="expression">表达式条件</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <returns></returns>
        bool Update<T>(string setValues, Expression<Func<T, bool>> expression, object whereObj = null) where T : class;
        /// <summary>
        /// 将实体对象更新到数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="FiledType"></typeparam>
        /// <param name="rowObj">rowObj为匿名对象时只更新指定列( 例如:new{ name='abc'}只更新name )，为T类型将更新整个实体(排除主键、自增列和禁止更新列)</param>
        /// <param name="whereIn">主键集合</param>
        /// <returns>更新成功返回true</returns>
        bool Update<T, FiledType>(object rowObj, params FiledType[] whereIn) where T : class;
        /// <summary>
        /// 批量插入(说明：一次更新超过10条以上建议使用SqlBulkReplace)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowObjList">更新实体的集合，rowObj必需包含主键并且不能为匿名对象</param>
        /// <returns>执行成功将返回bool的集合</returns>
        List<bool> UpdateRange<T>(List<T> rowObjList) where T : class;

        #endregion

        #region SqlHelper
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTran();
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="transactionName"></param>
        void BeginTran(string transactionName);
        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTran();
        /// <summary>
        /// 执行SQL返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        int ExecuteCommand(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 执行SQL返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        int ExecuteCommand(string sql, object pars);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        DataSet GetDataSetAll(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        DataSet GetDataSetAll(string sql, object pars);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        DataTable GetDataTable(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        DataTable GetDataTable(string sql, object pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        DateTime GetDateTime(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        decimal GetDecimal(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        double GetDouble(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        int GetInt(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        int GetInt(string sql, object pars);
        /// <summary>
        /// 根据SQL获取T的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        List<T> GetList<T>(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 根据SQL获取T的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        List<T> GetList<T>(string sql, object pars);
        //SqlDataReader GetReader(string sql, params SqlParameter[] pars);
        //SqlDataReader GetReader(string sql, object pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        object GetScalar(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        object GetScalar(string sql, object pars);
        /// <summary>
        /// 根据SQL获取T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        T GetSingle<T>(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 根据SQL获取T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        T GetSingle<T>(string sql, object pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        string GetString(string sql, params SqlParameter[] pars);
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        string GetString(string sql, object pars);
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTran();
        #endregion
    }
}