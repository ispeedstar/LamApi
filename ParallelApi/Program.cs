using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicTasks basicTasks = new BasicTasks();
            //basicTasks.Run();

            //Synchronization sync = new Synchronization();
            //sync.DoSynch();

            ExeParallel exeParallel = new ExeParallel();
            exeParallel.DoAll();
        }
    }
}
