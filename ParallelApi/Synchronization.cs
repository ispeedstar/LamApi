using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ParallelApi
{
    class Synchronization
    {
        class BankAccount
        {
            public int Balance
            {
                get;
                set;
            }
        } // end class BankAccount


        public void DoSynch()
        {
            BankAccount account = new BankAccount();

            int numTasks = 10;

            // create an array of task
            Task[] tasks = new Task[numTasks];

            // create a lock object
            object lockObj = new object();

            // start timer
            Stopwatch stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < numTasks; i++)
            {
                // create new task
                tasks[i] = new Task(() =>
                {
                    // create a loop of 500 balance updates
                    for (int j = 0; j < 500; j++)
                    {
                        lock (lockObj)
                        {
                            // update the account balance
                            account.Balance = account.Balance + 1;
                        }
                    }
                });
                // start the task
                tasks[i].Start();
            } // end for loop

            // wait for all task to complete
            Task.WaitAll(tasks);

            stopWatch.Stop();
            MessageBox.Show("Expected value 5000 and balance is " + account.Balance.ToString());

            MessageBox.Show("Run time (ms) is " + stopWatch.ElapsedMilliseconds);
        }
    }
}
