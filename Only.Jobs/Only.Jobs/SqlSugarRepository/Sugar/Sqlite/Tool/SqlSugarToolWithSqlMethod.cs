using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SQLiteSugar
{
    /// <summary>
    /// SqlSugarTool局部类存放具有拼接SQL的函数(方便工具移植到其它数据库版本)
    /// </summary>
    public partial class SqlSugarTool
    {
        /// <summary>
        /// 将参数sql转成 '('+sql+')'
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string PackagingSQL(string sql)
        {
            return string.Format("({0})", sql);
        }

        internal static StringBuilder GetQueryableSql<T>(Queryable<T> queryable)
        {
            string joinInfo = string.Join(" ", queryable.JoinTableValue);
            StringBuilder sbSql = new StringBuilder();
            string tableName = queryable.TableName.IsNullOrEmpty() ? queryable.TName : queryable.TableName;
            if (queryable.DB.Language.IsValuable() && queryable.DB.Language.Suffix.IsValuable())
            {
                var viewNameList = LanguageHelper.GetLanguageViewNameList(queryable.DB);
                var isLanView = viewNameList.IsValuable() && viewNameList.Any(it => it == tableName);
                if (!queryable.DB.Language.Suffix.StartsWith(LanguageHelper.PreSuffix))
                {
                    queryable.DB.Language.Suffix = LanguageHelper.PreSuffix + queryable.DB.Language.Suffix;
                }

                //将视图变更为多语言的视图
                if (isLanView)
                    tableName = typeof(T).Name + queryable.DB.Language.Suffix;
            }
            if (queryable.DB.PageModel == PageModel.RowNumber)
            {
                string withNoLock = queryable.DB.IsNoLock ? "WITH(NOLOCK)" : null;
                var order = queryable.OrderByValue.IsValuable() ? ("ORDER BY " + queryable.OrderByValue + " ") : null;
                sbSql.AppendFormat("SELECT " + queryable.SelectValue.GetSelectFiles() + " {1} FROM {0} {5} {2} WHERE 1=1 {3} {4} ", tableName.GetTranslationSqlName(), "", withNoLock, string.Join("", queryable.WhereValue), queryable.GroupByValue.GetGroupBy(),joinInfo);
                sbSql.Append(order);
                if (queryable.Skip > 0 || queryable.Take > 0)
                {
                    if (queryable.Skip > 0 && queryable.Take > 0)
                    {
                        sbSql.AppendFormat("limit {0},{1}", queryable.Skip, queryable.Take);
                    }
                    else if (queryable.Skip > 0)
                    {
                        sbSql.AppendFormat("limit {0}", queryable.Skip);
                    }
                    else if (queryable.Take > 0)
                    {
                        sbSql.AppendFormat("limit 0,{0}", queryable.Take);
                    }
                }
            }
            return sbSql;
        }

        internal static void GetSqlableSql(Sqlable sqlable, string fileds, string orderByFiled, int pageIndex, int pageSize, StringBuilder sbSql)
        {

            sbSql.Insert(0, string.Format("SELECT {0}", fileds));
            sbSql.Append(" WHERE 1=1 ").Append(string.Join(" ", sqlable.Where));
            sbSql.Append(sqlable.GroupBy);
            sbSql.AppendFormat(" ORDER BY {0} ", orderByFiled);
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;
            if (skip > 0 || take > 0)
            {
                if (skip > 0 && take > 0)
                {
                    sbSql.AppendFormat("limit {0},{1}", skip, take);
                }
                else if (skip > 0)
                {
                    sbSql.AppendFormat("limit {0}", skip);
                }
                else if (take > 0)
                {
                    sbSql.AppendFormat("limit 0,{0}", take);
                }
            }
        }

        /// <summary>
        /// 获取 WITH(NOLOCK)
        /// </summary>
        /// <param name="isNoLock"></param>
        /// <returns></returns>
        public static string GetLockString(bool isNoLock)
        {
            return isNoLock ? " " : "";
        }

        /// <summary>
        /// 根据表获取主键
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static string GetPrimaryKeyByTableName(SqlSugarClient db, string tableName)
        {
            var ids = GetIdentitiesKeyByTableName(db, tableName);
            if (ids.IsValuable())
            {
                return ids.Last().Value;
            }
            return null;
        }
        /// <summary>
        /// 根据表获取主键
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static List<string> GetPrimaryKeyByTableNames(SqlSugarClient db, string tableName)
        {
            var ids = GetIdentitiesKeyByTableName(db, tableName);
            if (ids.IsValuable())
            {
                return ids.Select(it=>it.Value).ToList();
            }
            return null;
        }
  

        /// <summary>
        ///根据表名获取自添列 keyTableName Value columnName
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static List<KeyValue> GetIdentitiesKeyByTableName(SqlSugarClient db, string tableName)
        {
            string key = "GetIdentityKeyByTableName" + tableName;
            var cm = CacheManager<List<KeyValue>>.GetInstance();
            List<KeyValue> identityInfo = null;
            string sql = "pragma table_info('" + tableName + "')";
            if (cm.ContainsKey(key))
            {
                identityInfo = cm[key];
                return identityInfo;
            }
            else
            {
                var dt = db.GetDataTable(sql);
                identityInfo = new List<KeyValue>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["pk"].ToString() == "1")
                            identityInfo.Add(new KeyValue() { Key = tableName, Value = dr["name"].ToString() });
                    }
                }
                cm.Add(key, identityInfo, cm.Day);
                return identityInfo;
            }
        }

        /// <summary>
        /// 根据表名获取列名
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static List<string> GetColumnsByTableName(SqlSugarClient db, string tableName)
        {
            string key = "GetColumnNamesByTableName" + tableName;
            var cm = CacheManager<List<string>>.GetInstance();
            if (cm.ContainsKey(key))
            {
                return cm[key];
            }
            else
            {
                var isLog = db.IsEnableLogEvent;
                db.IsEnableLogEvent = false;
                string sql = " PRAGMA table_info('" + tableName+ "')";
                var dt = db.GetDataTable(sql);
                var reval = new List<string>();
                foreach (DataRow item in dt.Rows)
                {
                    reval.Add(item["name"].ObjToString());
                }
                db.IsEnableLogEvent = isLog;
                cm.Add(key, reval, cm.Day);
                return reval;
            }
        }
        /// <summary>
        /// 将SqlType转成C#Type
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static string ChangeDBTypeToCSharpType(string typeName)
        {
            string reval = string.Empty;
            switch (typeName.ToLower())
            {
                case "integer":
                case "boolean":
                case "int":
                case "decimal":
                case "float":
                case "int64":
                case "number":
                    reval = "int";
                    break;
                case "datetime":
                case "date":
                    reval = "dateTime";
                    break;
                case "varchar":
                case "nvarchar":
                case "char":
                case "text":
                    reval = "string";
                    break;
                case "real":
                    reval = "decimal";
                    break;
                case "binary":
                case "image":
                case "blob":
                    reval = "byte[]";
                    break;
                default:
                    reval = "other";
                    break;
            }
            return reval;
        }
        /// <summary>
        ///tableOrView  null=u,v , true=u , false=v
        /// </summary>
        /// <param name="tableOrView"></param>
        /// <returns></returns>
        internal static string GetCreateClassSql(bool? tableOrView)
        {
            string sql = null;
            if (tableOrView == null)
            {
                sql = " select name from sqlite_master where type='table' or type='view'  order by name; ";
            }
            else if (tableOrView == true)
            {
                sql = "select name from sqlite_master where type='table' order by name;";
            }
            else
            {
                sql = " select name from sqlite_master where type='view'  order by name;";
            }
            return sql;
        }

        internal static string GetTtableColumnsInfo(string tableName)
        {
            string sql = @"SELECT
                                    TABLE_NAME, 
                                    column_name AS COLUMN_NAME,
                                    column_default  AS  `COLUMN_DEFAULT`,
                                    column_comment  AS  `COLUMN_DESCRIPTION`,
                                    CASE WHEN COLUMN_KEY = 'PRI'
                                    THEN 1 ELSE 0 END AS `IS_PRIMARYKEY`,
                                    CASE WHEN is_nullable = 'YES'
                                    THEN 1 ELSE 0 END AS `IS_NULLABLE`
                                    FROM
                                    Information_schema.columns where TABLE_NAME='" + tableName+@"' ORDER BY TABLE_NAME
                                      ";
            return sql;
        }

        internal static string GetSelectTopSql()
        {
            return "select  * from {0} limit 0,1";
        }

         

        /// <summary>
        /// par的符号
        /// </summary>
        public const char ParSymbol = '@';

        /// <summary>
        /// 获取转释后的表名和列名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetTranslationSqlName(string name)
        {
            Check.ArgumentNullException(name, "表名或者列名不能为空，检查所在表是否有主键。");
            if (name.Contains("'")) return name;
            if (name.Contains("`")) return name;
            if (name.Contains("@")) return name;
            if (name.Trim().IsInt()) return name;
            var hasScheme = name.Contains(".");
            if (hasScheme)
            {
                var array = name.Split('.');
                if (array.Length == 2)
                {
                    return string.Format("{0}.[{1}]", array.First(), array.Last());
                }
                else
                {
                    return string.Join(".", array.Select(it => "[" + it + "]"));
                }
            }
            else
            {
                return "[" + name + "]";
            }
        }
        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetSqlParameterName(string name)
        {
            return ParSymbol + name;
        }

        /// <summary>
        ///获取没有符号的参数名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetSqlParameterNameNoParSymbol(string name)
        {
            return name.TrimStart(ParSymbol);
        }

        /// <summary>
        /// 获取Schema和表名的集合
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static List<KeyValue> GetSchemaList(SqlSugarClient db)
        {
            var cm = CacheManager<List<KeyValue>>.GetInstance();
            string cacheKey = "SqlSugarTool.GetSchemaList";
            if (cm.ContainsKey(cacheKey)) return cm[cacheKey];
            else
            {
                var reval = db.SqlQuery<KeyValue>(@"select  s.name as [Key],t.name as [Value] from sys.sysobjects t , sys.schemas s where t.xtype in ('U','V') and t.uid = s.schema_id");
                cm.Add(cacheKey, reval, cm.Day);
                return reval;
            }
        }
    }
}
