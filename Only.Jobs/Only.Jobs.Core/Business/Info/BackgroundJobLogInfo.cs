using SqlSugar;
using System;

namespace Only.Jobs.Core.Business.Info
{
    /// <summary>
    /// 后台任务执行日志
    /// </summary>
    public class BackgroundJobLogInfo
    {
        /// <summary>
        /// JobID
        /// </summary>				
        public System.Guid BackgroundJobLogId { get; set; }

        /// <summary>
        /// JobID
        /// </summary>
        public System.Guid BackgroundJobId { get; set; }

        /// <summary>
        /// Job名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>				
        public Nullable<DateTime> ExecutionTime { get; set; }

        /// <summary>
        /// 执行持续时长
        /// </summary>				
        public Nullable<double> ExecutionDuration { get; set; }

        /// <summary>
        /// 创建日期时间
        /// </summary>				
        public System.DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>				
        public string RunLog { get; set; }

    }
}
