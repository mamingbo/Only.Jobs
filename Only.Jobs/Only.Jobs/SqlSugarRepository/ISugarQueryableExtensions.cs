using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SqlSugar;
using OracleSugar;
using SQLiteSugar;
using MySqlSugar;
using System.Data;

namespace SqlSugarRepository
{
    /// <summary>
    /// 拉姆达表达式查询对象的扩展类
    /// </summary>
    public static class ISugarISugarQueryableExtensions
    {
        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T>(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="whereString">Where后面的Sql条件语句 (例如： id=@id )</param>
        /// <param name="whereObj"> 匿名参数 (例如：new{id=1,name="张三"})</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T>(this ISugarQueryable<T> queryable, string whereString, object whereObj = null)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T>(whereString, whereObj);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T>(whereString, whereObj);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T>(whereString, whereObj);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T>(whereString, whereObj);
            }
            return queryable;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="T2">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T, T2>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2>(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="T2">表实体类型</typeparam>
        /// <typeparam name="T3">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T, T2, T3>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3>(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="T2">表实体类型</typeparam>
        /// <typeparam name="T3">表实体类型</typeparam>
        /// <typeparam name="T4">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T, T2, T3, T4>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, T4, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4>(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="T2">表实体类型</typeparam>
        /// <typeparam name="T3">表实体类型</typeparam>
        /// <typeparam name="T4">表实体类型</typeparam>
        /// <typeparam name="T5">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Where<T, T2, T3, T4, T5>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, T4, T5, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4, T5>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4, T5>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4, T5>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Where<T, T2, T3, T4, T5>(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pkValues">主键集合</param>
        /// <returns></returns>
        public static ISugarQueryable<T> In<T>(this ISugarQueryable<T> queryable, params object[] pkValues)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).In<T>(pkValues);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).In<T>(pkValues);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).In<T>(pkValues);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).In<T>(pkValues);
            }
            return queryable;
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pkValue">主键</param>
        /// <returns></returns>
        public static T InSingle<T>(this ISugarQueryable<T> queryable, object pkValue)
        {
            return queryable.In(pkValue).ToList().SingleOrDefault();
        }

        /// <summary>
        /// 条件筛选 ( 例如：InFieldName 为 id, inValues 值为 new string[]{"1" ,"2"} 生成的SQL就是 id in('1','2')  )
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="FieldType">In的字段类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="InFieldName">In的字段名称</param>
        /// <param name="inValues">In的值的数组集合</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> In<T, FieldType>(this ISugarQueryable<T> queryable, string InFieldName, params FieldType[] inValues)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(InFieldName, inValues);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(InFieldName, inValues);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(InFieldName, inValues);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(InFieldName, inValues);
            }
            return queryable;
        }

        /// <summary>
        ///  条件筛选 ( 例如：expression 为 it=>it.id,  inValues值为 new string[]{"1" ,"2"} 生成的SQL就是  id in('1','2') )
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="FieldType">In的字段类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">In的字段（例如：it=>it.id）</param>
        /// <param name="inValues">In的值的数组集合</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> In<T, FieldType>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression, params FieldType[] inValues)
        {

            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            return queryable;
        }

        /// <summary>
        ///  条件筛选 ( 例如：expression 为 it=>it.id,  inValues值为 new string[]{"1" ,"2"} 生成的SQL就是  id in('1','2') )
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="FieldType">In的字段类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">In的字段（例如：it=>it.id）</param>
        /// <param name="inValues">In的值的集合</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> In<T, FieldType>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression, List<FieldType> inValues)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).In<T, FieldType>(expression, inValues);
            }
            return queryable;
        }


        /// <summary>
        /// 条件筛选 ( 例如：InFieldName 为 id,  inValues值为 new string[]{"1" ,"2"} 生成的SQL就是  id in('1','2') )
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="FieldType">In的字段类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="InFieldName">In的字段名称</param>
        /// <param name="inValues">In的值的集合</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> In<T, FieldType>(this ISugarQueryable<T> queryable, string InFieldName, List<FieldType> inValues)
        {
            return In<T, FieldType>(queryable, InFieldName, inValues.ToArray());
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="orderFileds">排序字符串（例如：id asc,name desc) </param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> OrderBy<T>(this ISugarQueryable<T> queryable, string orderFileds)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(orderFileds);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(orderFileds);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).OrderBy(orderFileds);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).OrderBy(orderFileds);
            }
            return queryable;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">排序字段 it=>it.fieldName </param>
        /// <param name="type">排序类型</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> OrderBy<T>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression, OrderByType type = OrderByType.Asc)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (SqlSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (MySqlSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (OracleSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (SQLiteSugar.OrderByType)((int)type));
            }
            return queryable;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <typeparam name="T2">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">例如 (s1,s2)=>s1.id,相当于 order by s1.id</param>
        /// <param name="type">排序类型</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> OrderBy<T, T2>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, object>> expression, OrderByType type = OrderByType.Asc)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (SqlSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (MySqlSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (OracleSugar.OrderByType)((int)type));
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).OrderBy(expression, (SQLiteSugar.OrderByType)((int)type));
            }
            return queryable;
        }


        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">分组字段 (例如：it=>it.fieldName)</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> GroupBy<T>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).GroupBy(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).GroupBy(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).GroupBy(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).GroupBy(expression);
            }
            return queryable;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="groupFileds">分组字段 (例如：id,name) </param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> GroupBy<T>(this ISugarQueryable<T> queryable, string groupFileds)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).GroupBy<T>(groupFileds);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).GroupBy<T>(groupFileds);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).GroupBy<T>(groupFileds);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).GroupBy<T>(groupFileds);
            }
            return queryable;
        }


        /// <summary>
        ///  跳过序列中指定数量的元素，然后返回剩余的元素。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="index">指定数量的索引</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Skip<T>(this ISugarQueryable<T> queryable, int index)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Skip(index);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Skip(index);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Skip(index);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Skip(index);
            }
            return queryable;
        }

        /// <summary>
        /// 从起始点向后取指定条数的数据
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="num">指定条数</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> Take<T>(this ISugarQueryable<T> queryable, int num)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Take(num);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Take(num);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Take(num);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Take(num);
            }
            return queryable;
        }


        /// <summary>
        ///  返回序列的唯一元素；如果该序列并非恰好包含一个元素，则会引发异常。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>T</returns>
        public static T Single<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Single();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Single();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Single();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Single();
            }
            return default(T);
        }

        /// <summary>
        ///  返回序列的唯一元素；如果该序列为空返回Default(T),序列超过1条返则抛出异常。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>T</returns>
        public static T SingleOrDefault<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault();
            }
            return default(T);
        }

        /// <summary>
        ///  返回序列的唯一元素；如果该序列并非恰好包含一个元素，则会引发异常。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>T</returns>
        public static T Single<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Single(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Single(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Single(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Single(expression);
            }
            return default(T);
        }

        /// <summary>
        ///  返回序列的唯一元素；如果该序列并非恰好包含一个元素，否则返回null。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>T</returns>
        public static T SingleOrDefault<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).SingleOrDefault(expression);
            }
            return default(T);
        }

        /// <summary>
        ///  返回序列中的第一个元素。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>T</returns>
        public static T First<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).First();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).First();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).First();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).First();
            }
            return default(T);
        }

        /// <summary>
        ///   返回序列中的第一个元素,如果序列为NULL返回default(T)
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>T</returns>
        public static T FirstOrDefault<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault();
            }
            return default(T);
        }

        /// <summary>
        /// 返回序列中的第一个元素。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>T</returns>
        public static T First<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).First(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).First(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).First(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).First(expression);
            }
            return default(T);
        }

        /// <summary>
        /// 返回序列中的第一个元素,如果序列为NULL返回default(T)
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>T</returns>
        public static T FirstOrDefault<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {

            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).FirstOrDefault(expression);
            }
            return default(T);
        }


        /// <summary>
        ///  确定序列是否包含任何元素。
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">表达式条件</param>
        /// <returns>count>0返回true</returns>
        public static bool Any<T>(this ISugarQueryable<T> queryable, Expression<Func<T, bool>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Any(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Any(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Any(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Any(expression);
            }
            return false;
        }

        /// <summary>
        ///  确定序列是否包含任何元素
        /// </summary>
        /// <typeparam name="T">表实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>count>0返回true</returns>
        public static bool Any<T>(this ISugarQueryable<T> queryable)
        {
            return queryable.Count() > 0;
        }

        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="T">原数据实体类型</typeparam>
        /// <typeparam name="T2">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">给新实体赋值的表达式</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<TResult> Select<T, T2, TResult>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, TResult>> expression)
        {
            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, TResult>(expression);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, TResult>(expression);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="T">原数据实体类型</typeparam>
        /// <typeparam name="T2">原数据实体类型</typeparam>
        /// <typeparam name="T3">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">给新实体赋值的表达式</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<TResult> Select<T, T2, T3, TResult>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, TResult>> expression)
        {
            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, TResult>(expression);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, TResult>(expression);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="T">原数据实体类型</typeparam>
        /// <typeparam name="T2">原数据实体类型</typeparam>
        /// <typeparam name="T3">原数据实体类型</typeparam>
        /// <typeparam name="T4">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">给新实体赋值的表达式</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<TResult> Select<T, T2, T3, T4, TResult>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, T4, TResult>> expression)
        {

            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, TResult>(expression);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, TResult>(expression);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="T">原数据实体类型</typeparam>
        /// <typeparam name="T2">原数据实体类型</typeparam>
        /// <typeparam name="T3">原数据实体类型</typeparam>
        /// <typeparam name="T4">原数据实体类型</typeparam>
        /// <typeparam name="T5">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">给新实体赋值的表达式</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<TResult> Select<T, T2, T3, T4, T5, TResult>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, T4, T5, TResult>> expression)
        {

            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, T5, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, T5, TResult>(expression);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, T5, TResult>(expression);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T, T2, T3, T4, T5, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="TSource">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">给新实体赋值的表达式</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<TResult> Select<TSource, TResult>(this ISugarQueryable<TSource> queryable, Expression<Func<TSource, TResult>> expression)
        {
            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(expression);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(expression);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(expression);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }



        /// <summary>
        /// 将源数据对象转换到新对象中
        /// </summary>
        /// <typeparam name="TSource">原数据实体类型</typeparam>
        /// <typeparam name="TResult">返回值的新实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="select">查询字符串（例如 id,name）</param>
        /// <returns></returns>
        public static ISugarQueryable<TResult> Select<TSource, TResult>(this ISugarQueryable<TSource> queryable, string select)
        {
            ISugarQueryable<TResult> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(select);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(select);
                reval = new MySqlQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(select);
                reval = new OracleQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<TSource>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<TSource>)queryable.QueryableCore).Select<TSource, TResult>(select);
                reval = new SqlServerQueryable<TResult>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 将select的字段映射到T对象
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="select">查询字符串（例如 id,name）</param>
        /// <returns></returns>
        public static ISugarQueryable<T> Select<T>(this ISugarQueryable<T> queryable, string select)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T>(select);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T>(select);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T>(select);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T>(select);
            }
            return queryable;
        }
        /// <summary>
        /// 将select的字段映射到T对象
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <typeparam name="Result">数据实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="select">查询字符串（例如 id,name）</param>
        /// <returns></returns>
        public static ISugarQueryable<Result> Select<T, Result>(this ISugarQueryable<Result> queryable, string select)
        {
            ISugarQueryable<Result> reval = null;
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, Result>(select);
                reval = new SqlServerQueryable<Result>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Select<T, Result>(select);
                reval = new MySqlQueryable<Result>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).Select<T, Result>(select);
                reval = new OracleQueryable<Result>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Select<T, Result>(select);
                reval = new SqlServerQueryable<Result>();
                reval.QueryableCore = queryable.QueryableCore;
            }
            return reval;
        }

        /// <summary>
        /// 获取序列总记录数
        /// </summary>
        /// <param name="queryable">查询对象</param>
        /// <returns>int</returns>
        public static int Count<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Count();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Count();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Count();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Count();
            }
            return 0;
        }


        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <typeparam name="TSource">实体类型</typeparam>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="maxField">列名</param>
        /// <returns>TResult</returns>
        public static TResult Max<TSource, TResult>(this ISugarQueryable<TSource> queryable, string maxField)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<TSource>)
            {
                return ((SqlSugar.Queryable<TSource>)queryable.QueryableCore).Max<TSource, TResult>(maxField);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<TSource>)
            {
                return ((MySqlSugar.Queryable<TSource>)queryable.QueryableCore).Max<TSource, TResult>(maxField);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<TSource>)
            {
                return ((OracleSugar.Queryable<TSource>)queryable.QueryableCore).Max<TSource, TResult>(maxField);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<TSource>)
            {
                return ((SQLiteSugar.Queryable<TSource>)queryable.QueryableCore).Max<TSource, TResult>(maxField);
            }
            return default(TResult);
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">查询字段 (例如：it=>it.fieldName)</param>
        /// <returns>object</returns>
        public static object Max<T>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Max<T>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Max<T>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Max<T>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Max<T>(expression);
            }
            return 0;
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <typeparam name="TSource">实体类型</typeparam>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="minField">列名</param>
        /// <returns>TResult</returns>
        public static TResult Min<TSource, TResult>(this ISugarQueryable<TSource> queryable, string minField)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<TSource>)
            {
                return ((SqlSugar.Queryable<TSource>)queryable.QueryableCore).Min<TSource, TResult>(minField);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<TSource>)
            {
                return ((MySqlSugar.Queryable<TSource>)queryable.QueryableCore).Min<TSource, TResult>(minField);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<TSource>)
            {
                return ((OracleSugar.Queryable<TSource>)queryable.QueryableCore).Min<TSource, TResult>(minField);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<TSource>)
            {
                return ((SQLiteSugar.Queryable<TSource>)queryable.QueryableCore).Min<TSource, TResult>(minField);
            }
            return default(TResult);
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">查询字段 (例如：it=>it.fieldName)</param>
        /// <returns>object</returns>
        public static object Min<T>(this ISugarQueryable<T> queryable, Expression<Func<T, object>> expression)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).Min<T>(expression);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).Min<T>(expression);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).Min<T>(expression);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).Min<T>(expression);
            }
            return 0;
        }


        /// <summary>
        /// 将ISugarQueryable转换T的集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>T的集合</returns>
        public static List<T> ToList<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToList();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToList();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToList();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToList();
            }
            return default(List<T>);
        }

        /// <summary>
        /// 将ISugarQueryable转换为Json
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>json字符串</returns>
        public static string ToJson<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToJson();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToJson();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToJson();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToJson();
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的Json
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns>Json</returns>
        public static string ToJsonPage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize);
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的Json
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageCount">pageCount无需赋值，函数执行完自动赋值</param>
        /// <returns>Json</returns>
        public static string ToJsonPage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize, ref int pageCount)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToJsonPage(pageIndex, pageSize, ref pageCount);
            }
            return null;
        }

        /// <summary>
        /// 返回Sql和参数信息
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns></returns>
        public static KeyValuePair<string, string[]> ToSql<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToSql();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToSql();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToSql();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToSql();
            }
            return default(KeyValuePair<string, string[]>);
        }

        /// <summary>
        /// 将ISugarQueryable转换为Dynamic
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>dynamic</returns>
        public static dynamic ToDynamic<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamic();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamic();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDynamic();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDynamic();
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的Dynamic
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns>Dynamic</returns>
        public static dynamic ToDynamicPage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize);
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的Dynamic
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageCount">pageCount无需赋值，函数执行完自动赋值</param>
        /// <returns>Dynamic</returns>
        public static dynamic ToDynamicPage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize, ref int pageCount)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize, ref  pageCount);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize, ref  pageCount);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize, ref  pageCount);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDynamicPage(pageIndex, pageSize, ref  pageCount);
            }
            return null;
        }

        /// <summary>
        /// 将ISugarQueryable转换为DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTable<T>(this ISugarQueryable<T> queryable)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTable();
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTable();
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDataTable();
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDataTable();
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTablePage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize);
            }
            return null;
        }

        /// <summary>
        /// 将Queryable转换为分页后的DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageCount">pageCount无需赋值，函数执行完自动赋值</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTablePage<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize, ref int pageCount)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize,ref pageCount);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToDataTablePage(pageIndex, pageSize, ref pageCount);
            }
            return null;
        }


        /// <summary>
        /// 将ISugarQueryable转换为分页后的List&lt;T&gt;集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns>T的集合</returns>
        public static List<T> ToPageList<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize);
            }
            return null;
        }
        /// <summary>
        /// 将Queryable转换为分页后的List&lt;T&gt;集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageCount">pageCount无需赋值，函数执行完自动赋值</param>
        /// <returns>T的集合</returns>
        public static List<T> ToPageList<T>(this ISugarQueryable<T> queryable, int pageIndex, int pageSize, ref int pageCount)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                return ((SqlSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize,ref pageCount);
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                return ((MySqlSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                return ((OracleSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize, ref pageCount);
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                return ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).ToPageList(pageIndex, pageSize, ref pageCount);
            }
            return null;
        }

        /// <summary>
        /// 联表查询
        /// </summary>
        /// <typeparam name="T">第一个表的对象</typeparam>
        /// <typeparam name="T2">联接的表对象</typeparam>
        /// <param name="queryable"></param>
        /// <param name="expression">表达式</param>
        /// <param name="type">Join的类型</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> JoinTable<T, T2>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, object>> expression, JoinType type = JoinType.Left)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2>(expression, (SqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2>(expression, (MySqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2>(expression, (OracleSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2>(expression, (SQLiteSugar.JoinType)((int)type));
            }
            return queryable;
        }


        /// <summary>
        /// 联表查询
        /// </summary>
        /// <typeparam name="T">第一个表的对象</typeparam>
        /// <typeparam name="T2">联接表的对象</typeparam>
        /// <typeparam name="T3">联接表的对象</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="expression">条件表达式</param>
        /// <param name="type">Join的类型</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> JoinTable<T, T2, T3>(this ISugarQueryable<T> queryable, Expression<Func<T, T2, T3, object>> expression, JoinType type = JoinType.Left)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2, T3>(expression, (SqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2, T3>(expression, (MySqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2, T3>(expression, (OracleSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T, T2, T3>(expression, (SQLiteSugar.JoinType)((int)type));
            }
            return queryable;
        }

        /// <summary>
        /// 联表查询根据字符串
        /// </summary>
        /// <typeparam name="T">第一个表的对象</typeparam>
        /// <param name="queryable">查询对象</param>
        /// <param name="tableName">表名（可是以表或也可以是SQL语句加括号）</param>
        /// <param name="shortName">表名简写</param>
        /// <param name="onWhere">on后面的条件</param>
        /// <param name="whereObj">匿名参数(例如:new{id=1,name="张三"})</param>
        /// <param name="type">Join的类型</param>
        /// <returns>ISugarQueryable</returns>
        public static ISugarQueryable<T> JoinTable<T>(this ISugarQueryable<T> queryable, string tableName, string shortName, string onWhere, object whereObj, JoinType type = JoinType.Left)
        {
            if (queryable.QueryableCore is SqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T>(tableName,shortName,onWhere,whereObj, (SqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is MySqlSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((MySqlSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T>(tableName, shortName, onWhere, whereObj, (MySqlSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is OracleSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((OracleSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T>(tableName, shortName, onWhere, whereObj, (OracleSugar.JoinType)((int)type));
            }
            else if (queryable.QueryableCore is SQLiteSugar.Queryable<T>)
            {
                queryable.QueryableCore = ((SQLiteSugar.Queryable<T>)queryable.QueryableCore).JoinTable<T>(tableName, shortName, onWhere, whereObj, (SQLiteSugar.JoinType)((int)type));
            }
            return queryable;
        }

    }
}
