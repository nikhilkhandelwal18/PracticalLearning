using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class AsyncAwait
    {
        static void Main(string[] args)
        {
            //SyncMethod();

            //FireAndForget();

            FireAndForgetWithReturnType();

            Console.WriteLine("Press Any Key To Continue ...");
            Console.ReadLine();
        }

        #region sync
        static void SyncMethod()
        {
            Loop();
            Console.WriteLine("End of Line...");

        }

        private static void Loop()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
        #endregion

        #region AsyncAwait - Return void
        //If remove comment await line it will work as normal sync method.
        async static void FireAndForget()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1);
            }
        }
        #endregion

        #region AsyncAwait - Return Type of Task or Task<T>
        async static void FireAndForgetWithReturnType()
        {
          bool b =   await LoopAsync();
            if (b) Console.WriteLine("Return True");
        }

        static async Task<bool> LoopAsync()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1);
            }
            return true;
        }
        #endregion
    }
}
