using System;
//using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelApi
{
    class BasicTasks
    {

        public void DoTask1()
        {
            Task<int> t1 = new Task<int>((obj) =>
            {
                int value = Convert.ToInt32(obj);
                return DoubleValue(value);
            }, 1);

            t1.Start();
            ShowTask(t1);
        }

        public void DoTask2()
        {
            Task<int> t2 = Task.Factory.StartNew((obj) =>
            {
                int value = Convert.ToInt32(obj);
                return DoubleValue(value);
            }, 2);
            ShowTask(t2);
        }

        public void Run()
        {

            DoTask1();
            DoTask2();
        }

        private void ShowTask(Task<int> t)
        {
            MessageBox.Show("Result for task " + t.Result, t.Id.ToString());
        }

        private int DoubleValue(int value)
        {
            return (value * 2);
        }

    } // end class BasicTasks
}
