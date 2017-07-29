using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LamApi
{
    public class CThread
    {
        public void doThread()
        {
            Worker worker1 = new Worker();
            Thread thread1 = new Thread(new ThreadStart(worker1.Run));
            thread1.Name = "Thread1";

            Worker worker2 = new Worker();
            Thread thread2 = new Thread(new ThreadStart(worker2.Run));
            thread2.Name = "Thread2";

            Console.WriteLine("Starting threads");
            thread1.Start();
            thread2.Start();
            Console.WriteLine("Threads started");
        }
    } // end class CThread

    public class Worker
    {
    
        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Iteration: " + i);
                try
                {
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                } // end try-catch

            } // end for loop
        }
    } // end class Worker
}
