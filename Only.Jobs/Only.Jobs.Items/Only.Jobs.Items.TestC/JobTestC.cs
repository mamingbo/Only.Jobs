using log4net;
using Quartz;
using System;

namespace Only.Jobs.Items.TestC
{
    //不允许此 Job 并发执行任务（禁止新开线程执行）
    [DisallowConcurrentExecution]
    public sealed class JobTestC : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(JobTestC));

        public void Execute(IJobExecutionContext context)
        {
            Version Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            _logger.InfoFormat("JobTestC Execute begin Ver." + Ver.ToString());
            try
            {
                _logger.InfoFormat("JobTestC Executing ...");
                Console.WriteLine("---------------------");
            }
            catch (Exception ex)
            {
                _logger.Error("JobTestC 执行过程中发生异常:" + ex.ToString());
            }
            finally
            {
                _logger.InfoFormat("JobTestC Execute end ");
            }
        }
    }
}
