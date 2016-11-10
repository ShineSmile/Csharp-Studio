using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperveneTimerCallBack
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();

            Trace.WriteLine(string.Format("Main thread ID is {0}", Thread.CurrentThread.ManagedThreadId));
            Timer _timer = new Timer(p.TimerCallBack, null, 0, 3000);
            Console.Read();
        }

        private void TimerCallBack(object obj)
        {
            Trace.WriteLine(string.Format("Timer thread ID is {0}", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
