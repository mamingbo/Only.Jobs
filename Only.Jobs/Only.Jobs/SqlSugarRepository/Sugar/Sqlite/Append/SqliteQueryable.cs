using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteSugar;

namespace SqlSugarRepository
{
    internal class SqliteQueryable<T> : ISugarQueryable<T>
    {
        public object QueryableCore
        {
            get; set;
        }

        public ISugarQueryable<T> JoinTable<T2>(System.Linq.Expressions.Expression<Func<T, T2, object>> expression, JoinType type = JoinType.Left)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).JoinTable<T2>(expression, (SQLiteSugar.JoinType)(int)type);
            return this;
        }

        public ISugarQueryable<T> JoinTable<T2, T3>(System.Linq.Expressions.Expression<Func<T, T2, T3, object>> expression, JoinType type = JoinType.Left)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).JoinTable<T2, T3>(expression, (SQLiteSugar.JoinType)(int)type);
            return this;
        }

        public TResult Max<TResult>(string maxField)
        {
            return ((Queryable<T>)this.QueryableCore).Max<TResult>(maxField);
        }

        public TResult Min<TResult>(string minField)
        {
            return ((Queryable<T>)this.QueryableCore).Min<TResult>(minField);
        }

        public ISugarQueryable<T> OrderBy<T2>(System.Linq.Expressions.Expression<Func<T, T2, object>> expression, OrderByType type = OrderByType.Asc)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).OrderBy<T2>(expression, (SQLiteSugar.OrderByType)(int)type);
            return this;
        }

        public ISugarQueryable<T2> Select<T2>(string select)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<T2>(select);
            SqliteQueryable<T2> reval = new SqliteQueryable<T2>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<T, TResult>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<TResult>(expression);
            SqliteQueryable<TResult> reval = new SqliteQueryable<TResult>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<TResult> Select<T2, TResult>(System.Linq.Expressions.Expression<Func<T, T2, TResult>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<T2, TResult>(expression);
            SqliteQueryable<TResult> reval = new SqliteQueryable<TResult>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<TResult> Select<T2, T3, TResult>(System.Linq.Expressions.Expression<Func<T, T2, T3, TResult>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<T2, T3, TResult>(expression);
            SqliteQueryable<TResult> reval = new SqliteQueryable<TResult>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<TResult> Select<T2, T3, T4, TResult>(System.Linq.Expressions.Expression<Func<T, T2, T3, T4, TResult>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<T2, T3, T4, TResult>(expression);
            SqliteQueryable<TResult> reval = new SqliteQueryable<TResult>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<TResult> Select<T2, T3, T4, T5, TResult>(System.Linq.Expressions.Expression<Func<T, T2, T3, T4, T5, TResult>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Select<T2, T3, T4, T5, TResult>(expression);
            SqliteQueryable<TResult> reval = new SqliteQueryable<TResult>();
            reval.QueryableCore = this.QueryableCore;
            return reval;
        }

        public ISugarQueryable<T> Where<T2>(System.Linq.Expressions.Expression<Func<T, T2, bool>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Where<T2>(expression);
            return this;
        }

        public ISugarQueryable<T> Where<T2>(string whereString, object whereObj = null)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Where<T2>(whereString, whereObj);
            return this;
        }

        public ISugarQueryable<T> Where<T2, T3>(System.Linq.Expressions.Expression<Func<T, T2, T3, bool>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Where<T2, T3>(expression);
            return this;
        }

        public ISugarQueryable<T> Where<T2, T3, T4>(System.Linq.Expressions.Expression<Func<T, T2, T3, T4, bool>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Where<T2, T3, T4>(expression);
            return this;
        }

        public ISugarQueryable<T> Where<T2, T3, T4, T5>(System.Linq.Expressions.Expression<Func<T, T2, T3, T4, T5, bool>> expression)
        {
            this.QueryableCore = ((Queryable<T>)this.QueryableCore).Where<T2, T3, T4, T5>(expression);
            return this;
        }
    }
}
