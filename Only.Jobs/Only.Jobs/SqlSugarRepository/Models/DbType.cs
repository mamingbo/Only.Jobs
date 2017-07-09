using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DbType
    {
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer = 0,
        /// <summary>
        /// Sqlite
        /// </summary>
        Sqlite = 1,
        /// <summary>
        /// MySql
        /// </summary>
        MySql = 2,
        /// <summary>
        /// Oracle
        /// </summary>
        Oracle = 3
    }
}
