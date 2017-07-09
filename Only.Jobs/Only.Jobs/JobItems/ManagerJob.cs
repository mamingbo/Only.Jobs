using log4net;
using Only.Jobs.Core;
using Quartz;
using System;

namespace Only.Jobs.JobItems
{
    [DisallowConcurrentExecution]
    public class ManagerJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ManagerJob));

        public void Execute(IJobExecutionContext context)
        {
            Version Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            _logger.InfoFormat("ManagerJob Execute begin Ver." + Ver.ToString());
            try
            {
                new QuartzManager().JobScheduler(context.Scheduler);
                _logger.InfoFormat("ManagerJob Executing ...");
            }
            catch (Exception ex)
            {
                JobExecutionException e2 = new JobExecutionException(ex);
                e2.RefireImmediately = true;
            }
            finally
            {
                _logger.InfoFormat("ManagerJob Execute end ");
            }
        }
    }
}
