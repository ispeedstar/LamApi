using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelApi
{
    class ExeParallel
    {
        private static string batCmd = @"dir";
        private static string[] paths = new string[] { @"C:\temp", @"C:\tmp" };


        private void DoWorkSequentially(string[] pathStrs)
        {
            Console.WriteLine("Start DoWorkSequentially");
            Stopwatch stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < pathStrs.Length; i++)
            {
                Console.WriteLine(ExeConsole.Run(batCmd, pathStrs[i], 30000));
                Console.WriteLine("Execute iteration i = " + i.ToString() + " using " + pathStrs[i]);
            }
            stopWatch.Stop();
            Console.WriteLine("Execution time(ms) is " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine();
        }

        private void DoWorkParallelFor(string[] pathStrs)
        {
            Console.WriteLine("Start DoWorkParallelFor");
            Stopwatch stopWatch = Stopwatch.StartNew();
            Parallel.For(0, pathStrs.Length, (i) =>
            {
                Console.WriteLine(ExeConsole.Run(batCmd, pathStrs[i], 30000));
                Console.WriteLine("Execute iteration i = " + i.ToString() + " using " + pathStrs[i]);
            });
            stopWatch.Stop();
            Console.WriteLine("Execution time(ms) is " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine();
        }

        private void DoWorkParallelForEach(string[] pathStrs)
        {
            Console.WriteLine("Start DoWorkParallelForEach");
            Stopwatch stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(pathStrs, path =>
            {
                Console.WriteLine(ExeConsole.Run(batCmd, path, 30000));
                Console.WriteLine("Execute using " + path);
            });
            stopWatch.Stop();
            Console.WriteLine("Execution time(ms) is " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine();
        }

        public void DoAll()
        {
            DoWorkSequentially(paths);
            DoWorkParallelFor(paths);
            DoWorkParallelForEach(paths);
        }

    } // end class ExeParallel
}
