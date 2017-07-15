using log4net;
using Only.Jobs.Core.Business.Info;
using Only.Jobs.Core.Business.Manager;
using Quartz;
using System;

namespace Only.Jobs.Items.TestA
{
    //不允许此 Job 并发执行任务（禁止新开线程执行）
    [DisallowConcurrentExecution]
    public sealed class JobTestA : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(JobTestA));

        public void Execute(IJobExecutionContext context)
        {
            Version Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            _logger.InfoFormat("JobTestA Execute begin Ver." + Ver.ToString());
            try
            {
                context.MergedJobDataMap.Put("extend_logA", "JobTestA Executing" + DateTime.Now);
                context.MergedJobDataMap.Put("extend_run_result", "success");

                _logger.InfoFormat("JobTestA Executing ...");
                Console.WriteLine("---------------------");
            }
            catch (Exception ex)
            {
                _logger.Error("JobTestA 执行过程中发生异常:" + ex.ToString());
            }
            finally
            {
                _logger.InfoFormat("JobTestA Execute end ");
            }
        }
    }
}
