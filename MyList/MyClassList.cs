using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class MyClassList<T> : IList<T>,ICloneable,IEnumerable<T>
        where T: IComparable<T>
    {
        private T[] arr;
        int position = -1;
        public MyClassList()
        {
            arr = new T[0];
        }
        public void Add(T a)
        {
            T[] massA = new T[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                massA[i] = arr[i];
            }
            massA[arr.Length] = a;
            arr = massA;
            
        }
        public void Clear()
        {
            arr = new T[0];
        }
        public int Count()
        {
            return arr.Length;
        }
        public T this[int index] 
        { 
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        public override string ToString()
        {
            string stroka = null;
            for (int i = 0; i < arr.Length; i++)
            {
                stroka += arr[i] + " ";
            }
            return "Размерность массива " + arr.Length + " Элементы массива:" + stroka;
        }
        public void Find(T a)
        {
            //string b,b1;
            for (int i = 0; i < arr.Length; i++)
            {
                //b = arr[i].ToString();
                //b1 = a.ToString();
                if (arr[i].CompareTo(a) == 0)
                {
                    Console.WriteLine("Есть такое число в масиве");
                    break;
                }
            }
        }
        public int FindCount(T a)
        {
            //string b, b1;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                //b = arr[i].ToString();
                //b1 = a.ToString();
                if (arr[i].CompareTo(a) == 0)
                {
                    count++;
                }
            }
            return count;
        }
        public void Sort()
        {
            T buff;
            //string b, b1;
            for (int i = 0; i < arr.Length; i++) { 
                for (int j = arr.Length - 1; j > i; j--)
                {
                    //b = arr[j].ToString();
                    //b1 = arr[j - 1].ToString();

                    //IComparer<T> com;
                    //com.Compare(arr[j],arr[j-1]);
                    if (arr[j].CompareTo(arr[j-1]) == -1)
                    {
                        buff = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = buff;
                    }
                }
            }
        }
        public new Type GetType()
        {
            return base.GetType();
        }
        public void Remove(T a)
        {
            var arrayCopy = arr.ToList();
            if (arrayCopy.Remove(a))
            {
                arr = new T[arrayCopy.Count];
                for (int i = 0; i < arrayCopy.Count; i++)
                {
                    arr[i] = arrayCopy[i];
                }
            }
        }
        public void RemoveAll(T a)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                    var arrayCopy = arr.ToList();
                    if (arrayCopy.Remove(a))
                    {
                        arr = new T[arrayCopy.Count];
                        for (int i = 0; i < arrayCopy.Count; i++)
                        {
                            arr[i] = arrayCopy[i];
                        }
                    }
            }
        }
        public void CopyTo(out T[] a)
        {
            a = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                a[i] = arr[i];
            }
        }
        public void Insert(int index, T a)
        {
            try
            {
                int count = 0;
                T[] arr1 = new T[arr.Length + 1];
                arr1[index] = a;
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i].CompareTo(arr[count]) != 0)
                    {
                        if (arr1[i].CompareTo(a) == 0)
                        {
                            continue;
                        }
                        else
                        {
                            arr1[i] = arr[count];
                            count++;
                        }
                    }
                }
                arr = new T[arr1.Length];
                arr = arr1;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Индекс за пределом масива!!!");
                Console.WriteLine(e.Message);
            }
        }
        public object Clone()
        {
            return this;
        }
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (position < arr.Length - 1)
                {
                    position++;
                    yield return arr[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }
        public void Reset()
        {
            position = -1;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
