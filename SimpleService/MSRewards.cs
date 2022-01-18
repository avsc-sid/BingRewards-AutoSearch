using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleService
{
    public class MSRewards
    {
        private void UrMom()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MsRewards";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + @"\msrewards.bat"))
            {
                StreamWriter file = new StreamWriter(path + @"\msrewards.bat");
                file.WriteLine("@echo OFF & setlocal enabledelayedexpansion\nmode con:cols=80 lines=4\nset ver=10A\nset made=0\nset total=35\ncls\necho. Starting Browser, Please Wait\nstart microsoft-edge:\ngoto:count1\n:count1\nrem CenterSelf\nmode con:cols=30 lines=4\nSET /A wait=(%RANDOM%*1/32768)+1\nSET /a rand=(%RANDOM%*5000/32768)+1\nSET /a made=made+1\nstart microsoft-edge:https://www.bing.com/search?q=%rand% \n:count2\ncls\ntitle %made% of %total% (%wait%)\necho.%made% Searches Made out of %total%\necho.%wait% seconds until next search\nIF %made% GEQ %total% (cls && goto:done) else (goto:wait)\n:wait\nset /a wait=wait-=1\ntimeout 1 >nul\nif %wait%==0 (goto:count1) else (goto:count2)\n:done\necho.Closing\ntimeout 1 > nul\ntaskkill /IM msedge.exe\nexit");
                file.Close();
            }
            ProcessStartInfo pInfo = new ProcessStartInfo(path + @"\msrewards.bat")
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(pInfo);
        }

        private readonly System.Timers.Timer _timer;

        public MSRewards()
        {
            UrMom();
            Console.WriteLine($"Started process: msrewards.bat, Time: {DateTime.Now}");
            _timer = new System.Timers.Timer(60000) { AutoReset = true };
            _timer.Elapsed += timerElapsed;
        }

        private void timerElapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.ToString("HH:mm") == "16:00")
            {
                Console.WriteLine($"Started process: msrewards.bat, Time: {DateTime.Now}");
                UrMom();
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
