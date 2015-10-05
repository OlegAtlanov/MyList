using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassList<int> arr = new MyClassList<int>();

            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                arr.Add(rand.Next(100));
            }
            arr[9] = 40;
            arr[8] = 40;
            arr[4] = 40;
            arr[10] = 40;
            for (int i = 0; i < arr.Count(); i++)
            {
                Console.WriteLine("{0} - {1}", i, arr[i]);
            }
            Console.WriteLine(arr.ToString());
            arr.Find(40);
            Console.WriteLine("Количество числа {0} в масиве = {1}",40,arr.FindCount(40));
            arr.Sort();
            Console.WriteLine(arr.ToString());
            Console.WriteLine(arr.GetType());
            arr.RemoveAll(40);
            Console.WriteLine(arr.ToString());
            int[] a;
            arr.CopyTo(out a);
            if (a.Length != 0)
            {
                Console.Write("New mass: ");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write("{0} ",a[i]);
                }
            }
            Console.WriteLine();
            arr.Insert(24, 12);
            foreach (var item in arr)
            {
                Console.WriteLine(" {0} ",item);
            }
            Console.WriteLine(arr.ToString());
            Console.ReadKey();
            //arr.Clear();
            var mass = from n in arr
                       where n > 60
                       select new { a = n };

            foreach (var item in mass)
            {
                Console.WriteLine(" {0} ", item.a);
            }
            Console.ReadKey();
        }
    }
}
