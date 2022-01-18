using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<MSRewards>(s =>
                {
                    s.ConstructUsing(Heartbeat => new MSRewards());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("MSRewardsbat");
                x.SetDisplayName("MS Rewards.bat");
                x.SetDescription("idk");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());

            Environment.ExitCode = exitCodeValue;
        }
    }
}
