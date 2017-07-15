using Only.Jobs.Core.Services;
using Quartz;
using System;

namespace Only.Jobs.Core
{
    public class SchedulerJobListener : IJobListener
    {
        public void JobExecutionVetoed(IJobExecutionContext context)
        {

        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {

        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            System.Guid BackgroundJobId = System.Guid.Empty;
            Guid.TryParse(context.JobDetail.Key.Name, out BackgroundJobId);
            DateTime NextFireTimeUtc = TimeZoneInfo.ConvertTimeFromUtc(context.NextFireTimeUtc.Value.DateTime, TimeZoneInfo.Local);
            DateTime FireTimeUtc = TimeZoneInfo.ConvertTimeFromUtc(context.FireTimeUtc.Value.DateTime, TimeZoneInfo.Local);

            double TotalSeconds = context.JobRunTime.TotalSeconds;
            string JobName = string.Empty;
            string LogContent = string.Empty;
            if (context.MergedJobDataMap != null)
            {
                JobName = context.MergedJobDataMap.GetString("JobName");
                System.Text.StringBuilder log = new System.Text.StringBuilder();
                int i = 0;
                foreach (var item in context.MergedJobDataMap)
                {
                    string key = item.Key;
                    if (key.StartsWith("extend_"))
                    {
                        if (i > 0)
                        {
                            log.Append(",");
                        }
                        log.AppendFormat("{0}:{1}", item.Key, item.Value);
                        i++;
                    }
                }
                if (i > 0)
                {
                    LogContent = string.Concat("[", log.ToString(), "]");
                }
            }
            if (jobException != null)
            {
                LogContent = LogContent + " EX:" + jobException.ToString();
            }
            new BackgroundJobService().UpdateBackgroundJobStatus(BackgroundJobId, JobName, FireTimeUtc, NextFireTimeUtc, TotalSeconds, LogContent);
        }

        public string Name
        {
            get { return "SchedulerJobListener"; }
        }
    }
}
