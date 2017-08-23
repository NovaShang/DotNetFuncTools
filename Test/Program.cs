using System;
using DotNetFuncTools;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;

            var func1 = FuncUtils.Debounce(() => { Console.WriteLine("XXXX" + count1++ +"\t"+DateTime.Now.ToString()); }, TimeSpan.FromSeconds(1));
            var func2 = FuncUtils.Throttle(() => { Console.WriteLine("YYYY" + count2++ + "\t" + DateTime.Now.ToString()); }, TimeSpan.FromSeconds(1));
            var func3 = FuncUtils.Throttle(() => { Console.WriteLine("ZZZZ" + count3++ + "\t" + DateTime.Now.ToString()); }, TimeSpan.FromSeconds(10));
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(100);
                func1();
                //func2();
                //func3();

            }
            Console.ReadKey();

        }
    }
}