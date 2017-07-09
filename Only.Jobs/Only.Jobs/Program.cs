using System;
using System.IO;
using Topshelf;

namespace Only.Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.RunAsLocalSystem();
                x.Service<ServiceRunner>();
                x.SetDescription(string.Format("{0} Ver:{1}", System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName"), System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()));
                x.SetDisplayName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceDisplayName"));
                x.SetServiceName(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceName"));
                x.EnablePauseAndContinue();
            });
        }
    }
}
