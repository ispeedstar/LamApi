using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;
using System.IO;

namespace ParallelApi
{
    class ExeConsole
    {
        public static string Run(string command, string args, double timeout = 30000L)
        {
            string result = null;
            try
            {
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo(command);
                processStartInfo.Arguments = args;
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.ErrorDialog = false;
                Timer timer = new Timer(timeout);
                timer.Elapsed += new ElapsedEventHandler(ExeConsole.TimerElapsed);
                timer.Enabled = true;
                process.StartInfo = processStartInfo;
                process.Start();
                StreamReader standardOutput = process.StandardOutput;
                result = standardOutput.ReadToEnd();
                standardOutput.Close();
                standardOutput.Dispose();
                timer.Enabled = false;
                timer.Close();
                timer.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: excecute " + command + " " + args + ". " + ex.Message);
                result = null;
            }

            return (result);
        } // end method Run

        private static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Process[] javaProcesses = Process.GetProcessesByName("java");
            foreach (Process p in javaProcesses)
            {
                p.Kill();
            }


            Process[] guiProcesses = Process.GetProcessesByName("guixt");
            foreach (Process p in guiProcesses)
            {
                p.Kill();
            }

        } // end TimerElapsed

    } // end class ExeConsole
}