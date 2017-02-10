using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Problem1
    {
        static public string CheckDate(int x, int y, int z)
        {
            List<string> good_dates = new List<string>();
            int[] arr = { x, y, z };

            List<string> list_of_dates = GroupPermutations_.Perm(arr, 0);

            foreach (var item in list_of_dates)
            {
                string[] str = item.Split(',').Select(p => p.Trim()).ToArray();
                try
                {
                    good_dates.Add(DateTime.Parse(str[0] + "/" + str[1] + "/" + str[2]).ToShortDateString());
                }
                catch (Exception) { }
            }

            if (good_dates.Distinct().ToList().Count == 1)
                return good_dates.Distinct().ToList().First().ToString();
            else
                return "Ambiguous";


        }

    }



    class GroupPermutations_
    {

        static List<string> combination = new List<string>();
        static public List<string> Perm<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
            return combination;
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private static void Print<T>(T[] arr)
        {
            //Console.WriteLine("{" + string.Join(", ", arr) + "}");
            combination.Add(string.Join(", ", arr));
        }


    }
}