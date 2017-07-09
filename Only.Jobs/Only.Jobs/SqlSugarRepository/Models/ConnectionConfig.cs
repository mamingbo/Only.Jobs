using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    /// <summary>
    /// 连接池配置
    /// </summary>
    public class ConnectionConfig
    {
        /// <summary>
        /// 唯一KEY
        /// </summary>
        public Guid UniqueKey = Guid.NewGuid();
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }
    }
}
