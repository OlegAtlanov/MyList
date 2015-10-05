using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    interface IList<T>
    {
        void Add(T a);
        void Clear();
        T this[int index] { get; set; }
        int Count();
        void Find(T a);
        int FindCount(T a);
        void Sort();
        Type GetType();
        void Remove(T a);
        void RemoveAll(T a);
        void CopyTo(out T[] a);
        void Insert(int index,T a);
    }
}
