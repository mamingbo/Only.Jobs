using Only.Jobs.Core.Business.Info;
using Only.Jobs.Core.Business.Manager;
using System;
using System.Collections.Generic;

namespace Only.Jobs.Core.Services
{
    public class BackgroundJobService
    {
        public BackgroundJobService() { }

        /// <summary>
        /// Job新增
        /// </summary>
        /// <param name="backgroundJobInfo">BackgroundJobInfo实体</param>
        /// <returns></returns>
        public bool InsertBackgroundJob(BackgroundJobInfo backgroundJobInfo)
        {
            return new BackgroundJobManager().InsertBackgroundJob(backgroundJobInfo);
        }

        /// <summary>
        /// Job修改
        /// </summary>
        /// <param name="backgroundJobInfo">BackgroundJobInfo实体</param>
        /// <returns></returns>
        public bool UpdateBackgroundJob(BackgroundJobInfo backgroundJobInfo)
        {
            return new BackgroundJobManager().UpdateBackgroundJob(backgroundJobInfo);
        }

        /// <summary>
        /// Job删除
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <returns></returns>
        public bool DeleteBackgroundJob(System.Guid BackgroundJobId)
        {
            return new BackgroundJobManager().DeleteBackgroundJob(BackgroundJobId);
        }

        /// <summary>
        /// Job删除
        /// </summary>
        /// <param name="idList">ID集合</param>
        /// <returns></returns>
        public bool DeleteBackgroundJob(List<System.Guid> idList, out string rtMsg)
        {
            bool result = false;
            rtMsg = string.Empty;
            int i = 0;
            if (idList != null && idList.Count > 0)
            {
                foreach (System.Guid BackgroundJobId in idList)
                {
                    BackgroundJobInfo backgroundJobInfo = GetBackgroundJobInfo(BackgroundJobId);
                    if (backgroundJobInfo.State != 0)
                    {
                        rtMsg = string.Format("{0}状态不为 停止状态,无法进行删除！", backgroundJobInfo.Name);
                        return false;
                    }
                }

                foreach (System.Guid BackgroundJobId in idList)
                {
                    DeleteBackgroundJob(BackgroundJobId);
                    i++;
                }
            }
            result = i > 0;
            return result;
        }

        /// <summary>
        /// Job详情
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <returns></returns>
        public BackgroundJobInfo GetBackgroundJobInfo(System.Guid BackgroundJobId)
        {
            return new BackgroundJobManager().GetBackgroundJobInfo(BackgroundJobId);
        }

        /// <summary>
        /// Job集合(分页 )
        /// </summary>
        /// <param name="parameter">参数集</param>
        /// <returns></returns>
        public PagerModel<BackgroundJobInfo> GeBackgroundJobInfoPagerList(PageParameter parameter)
        {
            return new BackgroundJobManager().GeBackgroundJobInfoPagerList(parameter);
        }

        /// <summary>
        /// 获取允许调度的Job集合
        /// </summary>
        /// <returns></returns>
        public List<BackgroundJobInfo> GeAllowScheduleJobInfoList()
        {
            return new BackgroundJobManager().GeAllowScheduleJobInfoList();
        }

        /// <summary>
        /// 更新Job状态
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        public bool UpdateBackgroundJobState(System.Guid BackgroundJobId, int State)
        {
            return new BackgroundJobManager().UpdateBackgroundJobState(BackgroundJobId, State);
        }

        /// <summary>
        /// 更新Job运行信息 
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="LastRunTime">最后运行时间</param>
        /// <param name="NextRunTime">下次运行时间</param>
        public void UpdateBackgroundJobStatus(System.Guid BackgroundJobId, DateTime LastRunTime, DateTime NextRunTime)
        {
            new BackgroundJobManager().UpdateBackgroundJobStatus(BackgroundJobId, LastRunTime, NextRunTime);
        }

        /// <summary>
        /// 更新Job运行信息 
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="JobName">Job名称</param>
        /// <param name="LastRunTime">最后运行时间</param>
        /// <param name="NextRunTime">下次运行时间</param>
        /// <param name="ExecutionDuration">运行时长</param>
        /// <param name="RunLog">日志</param>
        public void UpdateBackgroundJobStatus(System.Guid BackgroundJobId, string JobName, DateTime LastRunTime, DateTime NextRunTime, double ExecutionDuration, string RunLog)
        {
            UpdateBackgroundJobStatus(BackgroundJobId, LastRunTime, NextRunTime);
            WriteBackgroundJoLog(BackgroundJobId, JobName, LastRunTime, ExecutionDuration, RunLog);
        }


        /// <summary>
        /// Job日志详情
        /// </summary>
        /// <param name="BackgroundJobLogId">日志ID</param>
        /// <returns></returns>
        public BackgroundJobLogInfo GetBackgroundJobLogInfo(System.Guid BackgroundJobLogId)
        {
            return new BackgroundJobManager().GetBackgroundJobLogInfo(BackgroundJobLogId);
        }

        /// <summary>
        /// Job日志集合（分页）
        /// </summary>
        /// <param name="parameter">参数集</param>
        /// <returns></returns>
        public PagerModel<BackgroundJobLogInfo> GetBackgroundJobLogInfoPagerList(PageParameter parameter)
        {
            return new BackgroundJobManager().GetBackgroundJobLogInfoPagerList(parameter);
        }

        /// <summary>
        /// Job日志删除
        /// </summary>
        /// <param name="BackgroundJobLogId">日志ID</param>
        /// <returns></returns>
        public bool DeleteBackgroundJobLog(System.Guid BackgroundJobLogId)
        {
            return new BackgroundJobManager().DeleteBackgroundJobLog(BackgroundJobLogId);
        }

        /// <summary>
        /// Job 日志删除
        /// </summary>
        /// <param name="BackgroundJobLogIdList">日志ID集合</param>
        /// <returns></returns>
        public bool DeleteBackgroundJobLog(List<System.Guid> BackgroundJobLogIdList)
        {
            bool result = false;
            if (BackgroundJobLogIdList != null && BackgroundJobLogIdList.Count > 0)
            {
                int i = 0;
                foreach (System.Guid BackgroundJobLogId in BackgroundJobLogIdList)
                {
                    if (DeleteBackgroundJobLog(BackgroundJobLogId))
                        i++;
                }
                result = i > 0;
            }
            return result;
        }


        /// <summary>
        /// Job运行日志记录
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="JobName">Job名称</param>
        /// <param name="ExecutionTime">开始执行时间</param>
        /// <param name="RunLog">日志内容</param>
        public void WriteBackgroundJoLog(System.Guid BackgroundJobId, string JobName, DateTime ExecutionTime, string RunLog)
        {
            WriteBackgroundJoLog(BackgroundJobId, JobName, ExecutionTime, 0, RunLog);
        }

        /// <summary>
        /// Job运行日志记录
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="JobName">Job名称</param>
        /// <param name="ExecutionTime">开始执行时间</param>
        /// <param name="ExecutionDuration">执行时长</param>
        /// <param name="RunLog">日志内容</param>
        public void WriteBackgroundJoLog(System.Guid BackgroundJobId, string JobName, DateTime ExecutionTime, double ExecutionDuration, string RunLog)
        {
            BackgroundJobLogInfo backgroundJobLogInfo = new BackgroundJobLogInfo();
            backgroundJobLogInfo.BackgroundJobLogId = System.Guid.NewGuid();
            backgroundJobLogInfo.BackgroundJobId = BackgroundJobId;
            backgroundJobLogInfo.JobName = JobName;
            backgroundJobLogInfo.ExecutionTime = ExecutionTime;
            backgroundJobLogInfo.ExecutionDuration = ExecutionDuration;
            backgroundJobLogInfo.CreatedDateTime = DateTime.Now;
            backgroundJobLogInfo.RunLog = RunLog;
            new BackgroundJobManager().WriteBackgroundJoLog(backgroundJobLogInfo);
        }

    }
}
