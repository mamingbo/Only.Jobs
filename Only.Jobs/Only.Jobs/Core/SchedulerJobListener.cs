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
            if (context.MergedJobDataMap != null)
            {
                JobName = context.MergedJobDataMap.GetString("JobName");
            }
            string LogContent = string.Empty;
            if (jobException != null)
            {
                LogContent = jobException.ToString();
            }

            new BackgroundJobService().UpdateBackgroundJobStatus(BackgroundJobId, JobName, FireTimeUtc, NextFireTimeUtc, TotalSeconds, LogContent);
        }

        public string Name
        {
            get { return "SchedulerJobListener"; }
        }
    }
}
