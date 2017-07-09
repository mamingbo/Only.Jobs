using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OracleSugar;
namespace SqlSugarRepository
{
    internal class OracleClassGenerating : IClassGenerating
    {
        private SqlSugarClient GetDb(ISqlSugarClient db)
        {
            var reval = (SqlSugarClient)db.GetDb();
            return reval;
        }

        public void CreateClassFiles(ISqlSugarClient db, string fileDirectory, string nameSpace = null, bool? tableOrView = default(bool?), Action<string> callBack = null, Action<string> preAction = null)
        {
            ClassGenerating cg = new ClassGenerating();
            cg.CreateClassFiles(GetDb(db),fileDirectory,nameSpace,tableOrView);
        }

        public void CreateClassFilesByTableNames(ISqlSugarClient db, string fileDirectory, string nameSpace, params string[] tableNames)
        {
            ClassGenerating cg = new ClassGenerating();
            cg.CreateClassFilesByTableNames(GetDb(db),fileDirectory,nameSpace,tableNames);
        }

        public void CreateClassFilesInterface(ISqlSugarClient db, bool? tableOrView, Action<DataTable, string, string> callBack)
        {
            ClassGenerating cg = new ClassGenerating();
            cg.CreateClassFilesInterface(GetDb(db), tableOrView,callBack);
        }

        public string DynamicToClass(object entity, string className)
        {
            ClassGenerating cg = new ClassGenerating();
            return cg.DynamicToClass(entity, className);
        }

        public void ForeachTables(ISqlSugarClient db, Action<string> action)
        {
            ClassGenerating cg = new ClassGenerating();
            cg.ForeachTables(GetDb(db), action);
        }

        public List<string> GetTableNames(ISqlSugarClient db)
        {
            ClassGenerating cg = new ClassGenerating();
            return cg.GetTableNames(GetDb(db));
        }

        public string GetTableNameWithSchema(ISqlSugarClient db, string tableName)
        {
            ClassGenerating cg = new ClassGenerating();
            return cg.GetTableNameWithSchema(GetDb(db), tableName);
        }

        public string SqlToClass(ISqlSugarClient db, string sql, string className)
        {
            ClassGenerating cg = new ClassGenerating();
            return cg.SqlToClass(GetDb(db),sql,className);
        }

        public string TableNameToClass(ISqlSugarClient db, string tableName)
        {
            ClassGenerating cg = new ClassGenerating();
            return cg.TableNameToClass(GetDb(db),tableName);
        }
    }
}
