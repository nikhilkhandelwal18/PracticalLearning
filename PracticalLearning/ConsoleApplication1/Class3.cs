using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    public class Class3
    {
        static void Main(string[] args)
        {

            Random ran = new Random();
            int min = 0;
            int max = 10;

            ran.Next(min, max);
         

            List<int> lstInt = new List<int>();

            //while(lstInt.Count<10)
            // { 
            //     int x = ran.Next(min, max);
            //     if (lstInt.Contains(x)) continue;
            //     lstInt.Add(x);
            // }

            //OR

            //Enumerable.Range(0, 10).OrderBy(x => ran.Next(0, 9)).ToList().ForEach(x => Console.WriteLine(x));

            lstInt = Enumerable.Range(0, 10).OrderBy(x => ran.Next(0, 9)).ToList();


            Console.WriteLine(String.Join("; ", lstInt));

            //lstInt.


            //foreach (var i in lstInt)
            //{
            //    Console.WriteLine(i.ToString());
            //}

            // Console.WriteLine(ran.Next(0, 9).ToString());


            Console.ReadLine();
        }
    }
}

