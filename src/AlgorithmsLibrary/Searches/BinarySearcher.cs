using System;
using System.Collections.Generic;

namespace AlgorithmsLibrary.Searches
{
    public class BinarySearcher<T> : ISearcher<T> where T : IComparable
    {
        public bool Search(IList<T> list, T target)
        {
            if (list == null || list.Count <= 0)
            {
                return false;
            }

            var lo = 0;
            var hi = list.Count - 1;

            while (lo <= hi)
            {
                var mid = (lo + hi) / 2;

                if (list[mid].CompareTo(target) == 0)
                {
                    return true;
                }

                if (list[mid].CompareTo(target) > 0)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return false;
        }
    }
}
