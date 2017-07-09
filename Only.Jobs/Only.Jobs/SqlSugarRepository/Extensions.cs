using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    internal static class Extensions
    {
        public static MySqlParameter[] ToMySqlPars(this SqlParameter[] pars)
        {
            if (pars == null) {
                return null;
            }
            List<MySqlParameter> reval = new List<MySqlParameter>();
            foreach (var item in pars)
            {
                reval.Add(item.ToMySqlPars());
            }
            return reval.ToArray();
        }
        public static MySqlParameter ToMySqlPars(this SqlParameter par)
        {
            return new MySqlParameter() { ParameterName = par.ParameterName, Value = par.Value };
        }

        public static OracleParameter[] ToOracleSqlPars(this SqlParameter[] pars)
        {
            if (pars == null)
            {
                return null;
            }
            List<OracleParameter> reval = new List<OracleParameter>();
            foreach (var item in pars)
            {
                reval.Add(item.ToOracleSqlPars());
            }
            return reval.ToArray();
        }
        public static OracleParameter ToOracleSqlPars(this SqlParameter par)
        {
            par.ParameterName=par.ParameterName.TrimStart('@');
            par.ParameterName = par.ParameterName.TrimStart(':');
            par.ParameterName = ":"+par.ParameterName;
            return new OracleParameter() { ParameterName = par.ParameterName, Value = par.Value };
        }

        public static SQLiteParameter[] ToSqlitePars(this SqlParameter[] pars)
        {
            if (pars == null)
            {
                return null;
            }
            List<SQLiteParameter> reval = new List<SQLiteParameter>();
            foreach (var item in pars)
            {
                reval.Add(item.ToSqlitePars());
            }
            return reval.ToArray();
        }
        public static SQLiteParameter ToSqlitePars(this SqlParameter par)
        {
            return new SQLiteParameter() { ParameterName = par.ParameterName, Value = par.Value };
        }

    }
}
