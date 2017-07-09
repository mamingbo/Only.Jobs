using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    public class SerialNumber
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 获取流水号函数
        /// </summary>
        public Func<string> GetNumFunc { get; set; }
        /// <summary>
        /// 获取流水号函数(解决事务中死锁BUG)
        /// </summary>
        public Func<ISqlSugarClient, string> GetNumFuncWithDb { get; set; }
    }
}
