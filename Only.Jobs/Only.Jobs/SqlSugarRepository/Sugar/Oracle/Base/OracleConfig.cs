using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;

namespace OracleSugar
{
    /// <summary>
    /// 序列
    /// </summary>
    public class SequenceModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 序列的值
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Oracle参数配置
    /// </summary>
    public static class OracleConfig
    {
        //public static string ToOracleTableName(this string value)
        //{
        //    return value;
        //}

        //public static object ToOracleParValue(this object value)
        //{
        //    if (value == null)
        //    {
        //        return DBNull.Value;
        //    }
        //    var type = value.GetType();
        //    if (type == SqlSugarTool.BoolType)
        //    {
        //        return Convert.ToBoolean(value) ? 1 : 0;
        //    }
        //    else if (type == SqlSugarTool.GuidType)
        //    {
        //        return value.ToString();
        //    }
        //    return value;

        //}
        internal static void SetParType(string typeName, bool isBinary, string name, OracleParameter par, SqlSugarClient db)
        {
            var colInfos = db.ClassGenerating.GetTableColumns(db, typeName.ToUpper()).Where(it => it.COLUMN_NAME.ObjToString().ToLower() == name.GetOracleParameterNameNoParSymbol().ToLower()).ToList();
            if (colInfos.IsValuable())
            {
                var colInfo = colInfos.Single();
                if (colInfo.DATA_TYPE.ObjToString() == "BFILE")
                {
                    par.OracleDbType = OracleDbType.BFile;
                }
                else if (colInfo.DATA_TYPE.ObjToString() == "BLOB")
                {
                    par.OracleDbType = OracleDbType.Blob;
                }
                else if (colInfo.DATA_TYPE.ObjToString() == "RAW")
                {
                    par.OracleDbType = OracleDbType.Raw;
                }
                else if (colInfo.DATA_TYPE.ObjToString() == "LONGRAW")
                {
                    par.OracleDbType = OracleDbType.LongRaw;
                }
            }
        }
        internal static void SetParType(string typeName, PropertyInfo prop, OracleParameter par, SqlSugarClient db)
        {
            var isBinary = prop.PropertyType == SqlSugarTool.ByteArrayType;
            if (isBinary)
            {
                var colInfos = db.ClassGenerating.GetTableColumns(db, typeName.ToUpper()).Where(it => it.COLUMN_NAME.ObjToString().ToLower() == prop.Name.ToLower()).ToList();
                if (colInfos.IsValuable())
                {
                    var colInfo = colInfos.Single();
                    if (colInfo.DATA_TYPE.ObjToString() == "BFILE")
                    {
                        par.OracleDbType = OracleDbType.BFile;
                    }
                    else if (colInfo.DATA_TYPE.ObjToString() == "BLOB")
                    {
                        par.OracleDbType = OracleDbType.Blob;
                    }
                    else if (colInfo.DATA_TYPE.ObjToString() == "RAW")
                    {
                        par.OracleDbType = OracleDbType.Raw;
                    }
                    else if (colInfo.DATA_TYPE.ObjToString() == "LONGRAW")
                    {
                        par.OracleDbType = OracleDbType.LongRaw;
                    }
                }
            }
        }

        internal static bool ToColumnTypeNullable(this object value)
        {
            return value.ToString() == "Y" ? true : false;
        }
        /// <summary>
        /// 设置Number与实体的类型映射
        /// 默认:
        ///   {1,"bool"},
        ///   {3,"byte"},
        ///   {4,"short"},
        ///   {9,"int"},
        ///   {18,"long"}
        /// </summary>
        public static Dictionary<int, string> OracleNumberTypeMapping = new Dictionary<int, string>()
        {
            {1,"bool"},
            {3,"byte"},
            {4,"short"},
            {9,"int"},
            {18,"long"}
        };
        /// <summary>
        /// 设置序列
        /// </summary>
        public static List<SequenceModel> SequenceMapping = new List<SequenceModel>();


        internal static string GetOracleSql(string sql)
        {
            if (sql == null) return null;
            if (sql.Contains("@"))
            {
                sql = Regex.Replace(sql, @" \@", " :");
                sql = Regex.Replace(sql, @"\>\@", ">:");
                sql = Regex.Replace(sql, @"\<\@", "<:");
                sql = Regex.Replace(sql, @"\=\@", "=:");
            }
            return sql;
        }

        internal static void SetParsName(params OracleParameter[] pars)
        {
            if (pars != null && pars.Length > 0)
            {
                foreach (var item in pars)
                {
                    if (item.ParameterName.StartsWith("@"))
                    {
                        item.ParameterName = ":" + item.ParameterName.TrimStart('@');
                    }
                }
            }
        }
    }
}
