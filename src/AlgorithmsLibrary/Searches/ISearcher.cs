using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsLibrary.Searches
{
    public interface ISearcher<T> where T : IComparable
    {
        bool Search(IList<T> list, T target);
    }
}
