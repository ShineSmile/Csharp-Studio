using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Supervene
{
    class Program
    {
        static void Main(string[] args)
        {
            NormalFunction();
        }

        private static void NormalFunction()
        {
            AsyncFunction("M1").Wait();
            Task.Run(
                async () =>
                {
                    await AsyncFunction("TA");
                    await AsyncFunction("TB");
                });

            AsyncFunction("M2").Wait();
            new Action(
                async () =>
                {
                    await AsyncFunction("AA");
                    await AsyncFunction("AB");
                })();

            AsyncFunction("M3").Wait();
            Console.Read();
        }

        private static async Task AsyncFunction(string str)
        {
            Trace.WriteLine(str + " " + 1);
            await Task.Delay(5000);
            Trace.WriteLine(str + " " + 2);
            await Task.Delay(5000);
            Trace.WriteLine(str + " " + 3);
        }
    }
}
