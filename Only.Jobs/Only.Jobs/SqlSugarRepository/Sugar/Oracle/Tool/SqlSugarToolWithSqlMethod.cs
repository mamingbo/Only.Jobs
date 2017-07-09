using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace OracleSugar
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
                #region  rowNumber
                string withNoLock = queryable.DB.IsNoLock ? "" : null;
                var order = queryable.OrderByValue.IsValuable() ? (", ROW_NUMBER() OVER(ORDER BY " + queryable.OrderByValue + " ) row_index") : null;
                sbSql.AppendFormat("SELECT t.* from( SELECT " + queryable.SelectValue.GetSelectFiles(tableName) + " {1} FROM {0} {5} {2} WHERE 1=1 {3} {4}  )", tableName, order, withNoLock, string.Join("", queryable.WhereValue), queryable.GroupByValue.GetGroupBy(), joinInfo);
                if (queryable.Skip == null && queryable.Take != null)
                {

                    sbSql.Insert(0, "SELECT * FROM ( ");
                    sbSql.Append("t)  WHERE row_index<=" + queryable.Take);
                }
                else if (queryable.Skip != null && queryable.Take == null)
                {

                    sbSql.Insert(0, "SELECT * FROM ( ");
                    sbSql.Append("t) WHERE row_index>" + (queryable.Skip));
                }
                else if (queryable.Skip != null && queryable.Take != null)
                {

                    sbSql.Insert(0, "SELECT * FROM ( ");
                    sbSql.Append("t)  WHERE row_index BETWEEN " + (queryable.Skip + 1) + " AND " + (queryable.Skip + queryable.Take));
                }
                else {
                    string sql = sbSql.ToString();
                    sbSql = new StringBuilder();
                    sql=Regex.Match(sql,@"^SELECT t.* from\((.+)\)").Groups[1].Value;
                    sbSql.Append(sql);
                }
                #endregion
            }
            else
            {
            }
            return sbSql;
        }

        internal static void GetSqlableSql(Sqlable sqlable, string fileds, string orderByFiled, int pageIndex, int pageSize, StringBuilder sbSql)
        {
            if (sqlable.DB.PageModel == PageModel.RowNumber)
            {
                sbSql.Insert(0, string.Format("SELECT {0},ROWNUM row_index", fileds, orderByFiled));
                sbSql.Append(" WHERE 1=1 ").Append(string.Join(" ", sqlable.Where));
                sbSql.Append(sqlable.OrderBy);
                sbSql.Append(sqlable.GroupBy);
                int skip = (pageIndex - 1) * pageSize + 1;
                int take = pageSize;
                sbSql.Insert(0, "SELECT * FROM ( ");
                sbSql.AppendFormat(") t WHERE  t.row_index BETWEEN {0}  AND {1}   ", skip, skip + take - 1);
            }
        }

        /// <summary>
        /// 获取 WITH(NOLOCK)
        /// </summary>
        /// <param name="isNoLock"></param>
        /// <returns></returns>
        public static string GetLockString(bool isNoLock)
        {
            return isNoLock ? "" : "";
        }

        /// <summary>
        /// 根据表获取主键
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static string GetPrimaryKeyByTableName(SqlSugarClient db, string tableName)
        {
            var reval = GetPrimaryKeyByTableNames(db, tableName);
            if (reval.IsValuable()) return reval.First();
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
            string key = "GetPrimaryKeyByTableName" + tableName;
            var cm = CacheManager<List<KeyValue>>.GetInstance();
            List<KeyValue> primaryInfo = null;

            //获取主键信息
            if (cm.ContainsKey(key))
                primaryInfo = cm[key];
            else
            {
                string sql = @"  				select cu.TABLE_NAME  ,cu.COLUMN_name KEYNAME  from user_cons_columns cu, user_constraints au 
   where cu.constraint_name = au.constraint_name
    and au.constraint_type = 'P' and au.table_name = '" + tableName.GetTranslationSqlName() + @"'";
                var isLog = db.IsEnableLogEvent;
                db.IsEnableLogEvent = false;
                var dt = db.GetDataTable(sql);
                db.IsEnableLogEvent = isLog;
                primaryInfo = new List<KeyValue>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        primaryInfo.Add(new KeyValue() { Key = dr["TABLE_NAME"].ToString(), Value = dr["KEYNAME"].ToString() });
                    }
                }
                cm.Add(key, primaryInfo, cm.Day);
            }

            //反回主键
            if (!primaryInfo.Any(it => it.Key.ToLower() == tableName.ToLower()))
            {
                return null;
            }
            return primaryInfo.Where(it => it.Key.ToLower() == tableName.ToLower()).Select(it=>it.Value).ToList();

        }

        /// <summary>
        ///根据表名获取自添列 keyTableName Value columnName
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal static List<KeyValue> GetIdentitiesKeyByTableName(SqlSugarClient db, string tableName)
        {
            if (OracleConfig.SequenceMapping.IsValuable())
            {
                return OracleConfig.SequenceMapping.Where(it => it.TableName.ToLower() == tableName.ToLower()).Select(it => new KeyValue() { Key = it.TableName, Value = it.ColumnName }).ToList();
            }
            else
            {
                return new List<KeyValue>();
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
                string sql = @" select  COLUMN_name 
                            from user_tab_columns c  
                            where c.Table_Name='" + tableName.ToUpper() + @"' 
                            order by c.column_name";
                var isLog = db.IsEnableLogEvent;
                db.IsEnableLogEvent = false;
                var reval = db.SqlQuery<string>(sql);
                cm.Add(key, reval, cm.Day);
                db.IsEnableLogEvent = isLog;
                return reval;
            }
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
                sql = @"
                select  table_name name from user_tables where
                         table_name!='HELP' 
                        AND table_name NOT LIKE '%$%'
                        AND table_name NOT LIKE 'LOGMNRC_%'
                        AND table_name!='LOGMNRP_CTAS_PART_MAP'
                        AND table_name!='LOGMNR_LOGMNR_BUILDLOG'
                        AND table_name!='SQLPLUS_PRODUCT_PROFILE'  
                        UNION all
                        select view_name name  from user_views 
                                                WHERE VIEW_name NOT LIKE '%$%'
                                                AND VIEW_NAME !='PRODUCT_PRIVS'
                        AND VIEW_NAME NOT LIKE 'MVIEW_%'  ";
            }
            else if (tableOrView == true)
            {
                sql = @"select  table_name name from user_tables where
                         table_name!='HELP' 
                        AND table_name NOT LIKE '%$%'
                        AND table_name NOT LIKE 'LOGMNRC_%'
                        AND table_name!='LOGMNRP_CTAS_PART_MAP'
                        AND table_name!='LOGMNR_LOGMNR_BUILDLOG'
                        AND table_name!='SQLPLUS_PRODUCT_PROFILE' ";
            }
            else
            {
                sql = @"select view_name name  from user_views 
                        WHERE VIEW_name NOT LIKE '%$%'
                        AND VIEW_NAME !='PRODUCT_PRIVS'
                        AND VIEW_NAME NOT LIKE 'MVIEW_%' ";
            }
            return sql;
        }

        internal static string GetTtableColumnsInfo(string tableName)
        {
            string sql = @" select 
                              c.TABLE_NAME,
                              com.COMMENTS COLUMN_DESCRIPTION ,
                              c.COLUMN_NAME,
                              UC.NULLABLE   IS_NULLABLE,
                              c.DATA_PRECISION,
                              c.DATA_SCALE,
                              c.DATA_TYPE
                            from user_tab_columns c  
                            left  JOIN user_col_comments com on c.Table_Name=com.Table_Name and c.COLUMN_NAME=com.COLUMN_NAME
                            left   JOIN USER_TAB_COLS  uc on uc.COLUMN_ID=C.COLUMN_ID AND  uc.Table_Name=c.Table_Name
                            where c.Table_Name='" + tableName + @"' 
                            order by c.column_name";
            return sql;
        }

        internal static string GetSelectTopSql()
        {
            return "select  * from {0} where rownum<=1";
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
                case "long":
                    throw new Exception("不支持Oracle的Long类型，建议使用C_LOB代替。");
                case "int16":
                case "int32":
                case "int":
                    reval = "int";
                    break;
                case "text":
                    reval = "string";
                    break;
                case "int64":
                    reval = "long";
                    break;
                case "binary":
                    reval = "object";
                    break;
                case "bit":
                    reval = "bool";
                    break;
                case "char":
                    reval = "string";
                    break;
                case "datetime":
                case "date":
                    reval = "dateTime";
                    break;
                case "decimal":
                    reval = "decimal";
                    break;
                case "float":
                case "binarydouble":
                case "double":
                    reval = "double";
                    break;
                case "image":
                    reval = "byte[]";
                    break;
                case "money":
                    reval = "decimal";
                    break;
                case "nchar":
                    reval = "string";
                    break;
                case "ntext":
                    reval = "string";
                    break;
                case "numeric":
                    reval = "decimal";
                    break;
                case "nvarchar":
                    reval = "string";
                    break;
                case "real":
                    reval = "float";
                    break;
                case "smalldatetime":
                    reval = "dateTime";
                    break;
                case "smallint":
                    reval = "short";
                    break;
                case "smallmoney":
                    reval = "decimal";
                    break;
                case "timestamp":
                    reval = "dateTime";
                    break;
                case "tinyint":
                    reval = "byte";
                    break;
                case "uniqueidentifier":
                    reval = "guid";
                    break;
                case "varbinary":
                case "blob":
                case "long raw":
                case "raw":
                case "bfile":
                    reval = "byte[]";
                    break;
                case "varchar":
                    reval = "string";
                    break;
                case "Variant":
                    reval = "object";
                    break;
                default:
                    reval = "string";
                    break;
            }
            return reval;
        }

        /// <summary>
        /// par的符号
        /// </summary>
        public const char ParSymbol = ':';

        /// <summary>
        /// 获取转释后的表名和列名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetTranslationSqlName(string name)
        {
            Check.ArgumentNullException(name, "表名或者列名不能为空，检查所在表是否有主键。");
            return name.ToUpper();
        }
        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetOracleParameterName(string name)
        {
            return ParSymbol + name;
        }

        /// <summary>
        ///获取没有符号的参数名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string GetOracleParameterNameNoParSymbol(string name)
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
            return new List<KeyValue>();
        }
    }
}
