using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugarRepository;
using SQLiteSugar;
using System.Data;

namespace SqlSugarRepository
{
    internal class SqliteSqlable : ISqlable
    {
        public object SqlableCore
        {
            get; set;
        }
        private Sqlable sqlable
        {
            get
            {
                return (Sqlable)this.SqlableCore;
            }
            set
            {
                SqlableCore = value;
            }
        }


        /// <summary>
        /// Form
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="shortName">表名简写</param>
        /// <returns></returns>
        public ISqlable From(string tableName, string shortName)
        {
            sqlable = sqlable.From(tableName, shortName);
            return this;
        }
        /// <summary>
        /// Form
        /// </summary>
        /// <param name="shortName">表名简写</param>
        /// <returns></returns>
        public ISqlable From<T>(string shortName)
        {
            sqlable = sqlable.From<T>(shortName);
            return this;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="tableName">表名字符串</param>
        /// <param name="shortName">表名简写</param>
        /// <param name="leftFiled">join左边连接字段</param>
        /// <param name="rightFiled">join右边连接字段</param>
        /// <param name="type">join类型</param>
        /// <returns></returns>
        public ISqlable Join(string tableName, string shortName, string leftFiled, string rightFiled, JoinType type)
        {
            sqlable = sqlable.Join(tableName, shortName, leftFiled, rightFiled, (SQLiteSugar.JoinType)(int)type);
            return this;
        }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="shortName">表名简写</param>
        /// <param name="leftFiled">join左边连接字段</param>
        /// <param name="rightFiled">join右边连接字段</param>
        /// <param name="type">join类型</param>
        /// <returns></returns>
        public ISqlable Join<T>(string shortName, string leftFiled, string rightFiled, JoinType type)
        {
            sqlable = sqlable.Join<T>(shortName, leftFiled, rightFiled, (SQLiteSugar.JoinType)(int)type);
            return this;
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="where">查询条件、开头无需写 AND或者WHERE</param>
        /// <returns></returns>
        public ISqlable Where(string where)
        {
            sqlable = sqlable.Where(where);
            return this;
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="orderBy">排序字段，可以多个</param>
        /// <returns></returns>
        public ISqlable OrderBy(string orderBy)
        {
            sqlable = sqlable.OrderBy(orderBy);
            return this;
        }

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="applySql">apply主体内容</param>
        /// <param name="shotName">apply简写</param>
        /// <param name="type">Apply类型</param>
        /// <returns></returns>
        public ISqlable Apply(string applySql, string shotName, ApplyType type)
        {
            sqlable = sqlable.Apply(applySql, shotName, (SQLiteSugar.ApplyType)(int)type);
            return this;
        }

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="groupBy">GroupBy字段，可以多个</param>
        /// <returns></returns>
        public ISqlable GroupBy(string groupBy)
        {
            sqlable = sqlable.GroupBy(groupBy);
            return this;
        }

        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <param name="preSql">在这语句之前可插入自定义SQL</param>
        /// <param name="nextSql">在这语句之后可以插自定义SQL</param>
        /// <returns></returns>
        public List<T> SelectToList<T>(string fileds, object whereObj = null, string preSql = null, string nextSql = null) where T : class
        {
            return sqlable.SelectToList<T>(fileds, whereObj, preSql, nextSql);
        }


        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成DataTable
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public DataTable SelectToDataTable(string fileds, object whereObj = null)
        {
            return sqlable.SelectToDataTable(fileds, whereObj);
        }

        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成json
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public string SelectToJson(string fileds, object whereObj = null)
        {
            return sqlable.SelectToJson(fileds, whereObj);
        }

        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成dynamic
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public dynamic SelectToDynamic(string fileds, object whereObj = null)
        {
            return sqlable.SelectToDynamic(fileds, whereObj);
        }

        /// <summary>
        /// 生成查询结果对应的实体类字符串
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public string ToClass(string fileds, object whereObj = null)
        {
            return sqlable.ToClass(fileds, whereObj);
        }

        /// <summary>
        /// 反回记录数
        /// </summary>
        /// <param name="whereObj">匿名参数 (例如：new{id=1,name="张三"})</param>
        /// <param name="preSql">在这语句之前可插入自定义SQL</param>
        /// <param name="nextSql">在这语句之后可以插自定义SQL</param>
        /// <returns></returns>
        public int Count(object whereObj = null, string preSql = null, string nextSql = null)
        {
            return sqlable.Count(whereObj, preSql, nextSql);
        }

        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public List<T> SelectToPageList<T>(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null) where T : class
        {
            return sqlable.SelectToPageList<T>(fileds, orderByFiled, pageIndex, pageSize, whereObj);
        }




        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成DataTable
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public DataTable SelectToPageTable(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null)
        {
            return sqlable.SelectToPageTable(fileds, orderByFiled, pageIndex, pageSize, whereObj);
        }


        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成json
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public string SelectToPageJson(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null)
        {
            return sqlable.SelectToPageJson(fileds, orderByFiled, pageIndex, pageSize, whereObj);
        }

        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成dynamic
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        public dynamic SelectToPageDynamic(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null)
        {
            return sqlable.SelectToPageDynamic(fileds, orderByFiled, pageIndex, pageSize, whereObj);
        }

    }
}
