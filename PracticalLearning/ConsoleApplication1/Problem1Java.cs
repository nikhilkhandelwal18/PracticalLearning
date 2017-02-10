using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Problem1Java
    {
        static public string CheckDate(int x, int y, int z)
        {
            List<string> good_dates = new List<string>();
            int[] arr = { x, y, z };

            List<string> list_of_dates = GroupPermutations.Perm(arr, 0);

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



    class GroupPermutations
    {

        static List<string> combination = new List<string>();
        static public List<string> Perm(int[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Merge(arr);
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    // Swap( arr[k],  arr[i]);
                    int temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;

                  
                    Perm(arr, k + 1);

                    //Swap( arr[k],  arr[i]);
                    temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;
                }
            }
            return combination;
        }

        private static void Swap( int item1,  int item2)
        {
            int temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private static void Merge(int[] arr)
        {
            //Console.WriteLine("{" + string.Join(", ", arr) + "}");
            combination.Add(string.Join(", ", arr));
        }


    }
}