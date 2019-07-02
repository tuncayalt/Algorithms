using System;
using System.Collections.Generic;

namespace AlgorithmsLibrary.Sorts
{
    public interface ISorter<T> where T : IComparable
    {
        void Sort (IList<T> list);
    }
}
