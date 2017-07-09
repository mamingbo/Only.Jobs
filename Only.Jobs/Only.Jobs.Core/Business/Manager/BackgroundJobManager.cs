using Only.Jobs.Core.Business.Info;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace Only.Jobs.Core.Business.Manager
{
    public class BackgroundJobManager : BaseManager
    {
        #region BackgroundJobInfo

        /// <summary>
        /// Job新增
        /// </summary>
        /// <param name="backgroundJobInfo">BackgroundJobInfo实体</param>
        /// <returns></returns>
        public bool InsertBackgroundJob(BackgroundJobInfo backgroundJobInfo)
        {
            backgroundJobInfo.CreatedDateTime = DateTime.Now;
            backgroundJobInfo.LastUpdatedDateTime = DateTime.Now;
            return db.Insertable(backgroundJobInfo).ExecuteCommand() > 0;
        }

        /// <summary>
        /// Job修改
        /// </summary>
        /// <param name="backgroundJobInfo">BackgroundJobInfo实体</param>
        /// <returns></returns>
        public bool UpdateBackgroundJob(BackgroundJobInfo backgroundJobInfo)
        {
            backgroundJobInfo.LastUpdatedDateTime = DateTime.Now;
            db.Updateable(backgroundJobInfo).IgnoreColumns(it => new { it.LastRunTime, it.NextRunTime, it.RunCount, it.CreatedByUserId, it.CreatedByUserName, it.CreatedDateTime, it.IsDelete }).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// Job删除
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <returns></returns>
        public bool DeleteBackgroundJob(System.Guid BackgroundJobId)
        {
            BackgroundJobInfo backgroundJobInfo = new BackgroundJobInfo();

            backgroundJobInfo.BackgroundJobId = BackgroundJobId;
            backgroundJobInfo.IsDelete = 1;
            backgroundJobInfo.LastUpdatedDateTime = DateTime.Now;
            db.Updateable(backgroundJobInfo).UpdateColumns(it => new { it.IsDelete, it.LastUpdatedDateTime }).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// Job详情
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <returns></returns>
        public BackgroundJobInfo GetBackgroundJobInfo(System.Guid BackgroundJobId)
        {
            return db.Queryable<BackgroundJobInfo>().InSingle(BackgroundJobId);
        }

        /// <summary>
        /// Job集合(分页 )
        /// </summary>
        /// <param name="parameter">参数集</param>
        /// <returns></returns>
        public PagerModel<BackgroundJobInfo> GeBackgroundJobInfoPagerList(PageParameter parameter)
        {
            int TotalRecord = 0;
            List<BackgroundJobInfo> dataList = null;
            string Name = parameter.GetParameter("Name");
            if (!string.IsNullOrWhiteSpace(Name))
            {
                dataList = db.Queryable<BackgroundJobInfo>()
                    .Where(it => it.Name.Contains(Name) && it.IsDelete == 0)
                     .OrderBy(it => it.CreatedDateTime, OrderByType.Desc)
                     .ToPageList(parameter.currentPageIndex, parameter.rows, ref TotalRecord);
            }
            else
            {
                dataList = db.Queryable<BackgroundJobInfo>()
                    .Where(it => it.IsDelete == 0)
                      .OrderBy(it => it.CreatedDateTime, OrderByType.Desc)
                      .ToPageList(parameter.currentPageIndex, parameter.rows, ref TotalRecord);
            }

            PagerModel<BackgroundJobInfo> pagerModel = new PagerModel<BackgroundJobInfo>();
            pagerModel.dataList = dataList;
            pagerModel.TotalRecord = TotalRecord;
            pagerModel.CurrentPage = parameter.currentPageIndex;
            pagerModel.CalculateTotalPage(parameter.rows, TotalRecord);
            return pagerModel;
        }

        /// <summary>
        /// 获取允许调度的Job集合
        /// </summary>
        /// <returns></returns>
        public List<BackgroundJobInfo> GeAllowScheduleJobInfoList()
        {
            List<BackgroundJobInfo> list = null;
            list = db.Queryable<BackgroundJobInfo>().Where(it => it.IsDelete == 0 && (it.State == 1 || it.State == 3 || it.State == 5)).OrderBy(it => it.CreatedDateTime, OrderByType.Desc).ToList();
            return list;
        }

        /// <summary>
        /// 更新Job状态
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        public bool UpdateBackgroundJobState(System.Guid BackgroundJobId, int State)
        {
            BackgroundJobInfo backgroundJobInfo = new BackgroundJobInfo();
            backgroundJobInfo.BackgroundJobId = BackgroundJobId;
            backgroundJobInfo.State = State;
            db.Updateable(backgroundJobInfo).UpdateColumns(it => new { it.State }).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 更新Job运行信息 
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="LastRunTime">最后运行时间</param>
        /// <param name="NextRunTime">下次运行时间</param>
        public void UpdateBackgroundJobStatus(System.Guid BackgroundJobId, DateTime LastRunTime, DateTime NextRunTime)
        {
            db.Updateable<BackgroundJobInfo>()
                .ReSetValue(it => it.RunCount == (it.RunCount + 1))
                .UpdateColumns(it => new BackgroundJobInfo() { LastRunTime = LastRunTime, NextRunTime = NextRunTime })
                .Where(it => it.BackgroundJobId == BackgroundJobId)
                .ExecuteCommand();
        }
        #endregion

        #region BackgroundJobLogInfo


        /// <summary>
        /// Job日志详情
        /// </summary>
        /// <param name="BackgroundJobLogId">日志ID</param>
        /// <returns></returns>
        public BackgroundJobLogInfo GetBackgroundJobLogInfo(System.Guid BackgroundJobLogId)
        {
            return db.Queryable<BackgroundJobLogInfo>().InSingle(BackgroundJobLogId);
        }

        /// <summary>
        /// Job日志集合（分页）
        /// </summary>
        /// <param name="parameter">参数集</param>
        /// <returns></returns>
        public PagerModel<BackgroundJobLogInfo> GetBackgroundJobLogInfoPagerList(PageParameter parameter)
        {
            int TotalRecord = 0;
            List<BackgroundJobLogInfo> dataList = null;
            string JobName = parameter.GetParameter("JobName");
            if (!string.IsNullOrWhiteSpace(JobName))
            {
                dataList = db.Queryable<BackgroundJobLogInfo>()
                    .Where(it => it.JobName.Contains(JobName))
                     .OrderBy(it => it.CreatedDateTime, OrderByType.Desc)
                     .ToPageList(parameter.currentPageIndex, parameter.rows, ref TotalRecord);
            }
            else
            {
                dataList = db.Queryable<BackgroundJobLogInfo>()
                      .OrderBy(it => it.CreatedDateTime, OrderByType.Desc)
                      .ToPageList(parameter.currentPageIndex, parameter.rows, ref TotalRecord);
            }

            PagerModel<BackgroundJobLogInfo> pagerModel = new PagerModel<BackgroundJobLogInfo>();
            pagerModel.dataList = dataList;
            pagerModel.TotalRecord = TotalRecord;
            pagerModel.CurrentPage = parameter.currentPageIndex;
            pagerModel.CalculateTotalPage(parameter.rows, TotalRecord);
            return pagerModel;
        }

        /// <summary>
        /// Job日志删除
        /// </summary>
        /// <param name="BackgroundJobLogId">日志ID</param>
        /// <returns></returns>
        public bool DeleteBackgroundJobLog(System.Guid BackgroundJobLogId)
        {
            return db.Deleteable<BackgroundJobLogInfo>().Where(it => it.BackgroundJobLogId == BackgroundJobLogId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// Job日志记录
        /// </summary>
        /// <param name="BackgroundJobId">Job ID</param>
        /// <param name="JobName">Job名称</param>
        /// <param name="ExecutionTime">开始执行时间</param>
        /// <param name="ExecutionDuration">执行时长</param>
        /// <param name="RunLog">日志内容</param>
        public void WriteBackgroundJoLog(BackgroundJobLogInfo backgroundJobLogInfo)
        {
            db.Insertable<BackgroundJobLogInfo>(backgroundJobLogInfo).ExecuteCommand();
        }
        #endregion
    }
}
