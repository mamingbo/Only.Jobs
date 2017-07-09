using Only.Jobs.Core.Business.Info;
using Only.Jobs.Core.Services;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;

namespace Only.Jobs.Core
{
    public class QuartzManager
    {
        /// <summary>
        /// 从程序集中加载指定类
        /// </summary>
        /// <param name="assemblyName">含后缀的程序集名</param>
        /// <param name="className">含命名空间完整类名</param>
        /// <returns></returns>
        private Type GetClassInfo(string assemblyName, string className)
        {
            Type type = null;
            try
            {
                assemblyName = GetAbsolutePath(assemblyName);
                Assembly assembly = null;
                assembly = Assembly.LoadFrom(assemblyName);
                type = assembly.GetType(className, true, true);
            }
            catch (Exception ex)
            {
            }
            return type;
        }

        /// <summary>
        /// 校验字符串是否为正确的Cron表达式
        /// </summary>
        /// <param name="cronExpression">带校验表达式</param>
        /// <returns></returns>
        public bool ValidExpression(string cronExpression)
        {
            return CronExpression.IsValidExpression(cronExpression);
        }

        /// <summary>
        ///  获取文件的绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns></returns>
        public string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                throw new ArgumentNullException("参数relativePath空异常！");
            }
            relativePath = relativePath.Replace("/", "\\");
            if (relativePath[0] == '\\')
            {
                relativePath = relativePath.Remove(0, 1);
            }
            if (HttpContext.Current != null)
            {
                return Path.Combine(HttpRuntime.AppDomainAppPath, relativePath);
            }
            else
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            }
        }


        /// <summary>
        /// Job调度
        /// </summary>
        /// <param name="scheduler"></param>
        /// <param name="jobInfo"></param>
        public void ScheduleJob(IScheduler scheduler, BackgroundJobInfo jobInfo)
        {
            if (ValidExpression(jobInfo.CronExpression))
            {
                Type type = GetClassInfo(jobInfo.AssemblyName, jobInfo.ClassName);
                if (type != null)
                {
                    IJobDetail job = new JobDetailImpl(jobInfo.BackgroundJobId.ToString(), jobInfo.BackgroundJobId.ToString() + "Group", type);
                    job.JobDataMap.Add("Parameters", jobInfo.JobArgs);
                    job.JobDataMap.Add("JobName", jobInfo.Name);

                    CronTriggerImpl trigger = new CronTriggerImpl();
                    trigger.CronExpressionString = jobInfo.CronExpression;
                    trigger.Name = jobInfo.BackgroundJobId.ToString();
                    trigger.Description = jobInfo.Description;
                    trigger.StartTimeUtc = DateTime.UtcNow;
                    trigger.Group = jobInfo.BackgroundJobId + "TriggerGroup";
                    scheduler.ScheduleJob(job, trigger);
                }
                else
                {
                    new BackgroundJobService().WriteBackgroundJoLog(jobInfo.BackgroundJobId, jobInfo.Name, DateTime.Now, jobInfo.AssemblyName + jobInfo.ClassName + "无效，无法启动该任务");
                }
            }
            else
            {
                new BackgroundJobService().WriteBackgroundJoLog(jobInfo.BackgroundJobId, jobInfo.Name, DateTime.Now, jobInfo.CronExpression + "不是正确的Cron表达式,无法启动该任务");
            }
        }


        /// <summary>
        /// Job状态管控
        /// </summary>
        /// <param name="Scheduler"></param>
        public void JobScheduler(IScheduler Scheduler)
        {
            List<BackgroundJobInfo> list = new BackgroundJobService().GeAllowScheduleJobInfoList();
            if (list != null && list.Count > 0)
            {
                foreach (BackgroundJobInfo jobInfo in list)
                {
                    JobKey jobKey = new JobKey(jobInfo.BackgroundJobId.ToString(), jobInfo.BackgroundJobId.ToString() + "Group");
                    if (Scheduler.CheckExists(jobKey) == false)
                    {
                        if (jobInfo.State == 1 || jobInfo.State == 3)
                        {
                            ScheduleJob(Scheduler, jobInfo);
                            if (Scheduler.CheckExists(jobKey) == false)
                            {
                                new BackgroundJobService().UpdateBackgroundJobState(jobInfo.BackgroundJobId, 0);
                            }
                            else
                            {
                                new BackgroundJobService().UpdateBackgroundJobState(jobInfo.BackgroundJobId, 1);
                            }
                        }
                        else if (jobInfo.State == 5)
                        {
                            new BackgroundJobService().UpdateBackgroundJobState(jobInfo.BackgroundJobId, 0);
                        }
                    }
                    else
                    {
                        if (jobInfo.State == 5)
                        {
                            Scheduler.DeleteJob(jobKey);
                            new BackgroundJobService().UpdateBackgroundJobState(jobInfo.BackgroundJobId, 0);
                        }
                        else if (jobInfo.State == 3)
                        {
                            new BackgroundJobService().UpdateBackgroundJobState(jobInfo.BackgroundJobId, 1);
                        }
                    }
                }
            }
        }

    }
}
