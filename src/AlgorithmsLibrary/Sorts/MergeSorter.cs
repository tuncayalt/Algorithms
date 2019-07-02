using System;
using System.Collections.Generic;

namespace AlgorithmsLibrary.Sorts
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable
    {
        public void Sort(IList<T> list)
        {
            if (list == null || list.Count <= 1)
            {
                return;
            }

            Sort(list, 0, list.Count - 1);
        }

        private void Sort(IList<T> list, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var mid = (left + right) / 2;
            Sort(list, left, mid);
            Sort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        private void Merge(IList<T> list, int left, int mid, int right)
        {
            var lo = 0;
            var hi = mid + 1;
            var result = new List<T>();
            
            while (lo <= mid && hi <= right)
            {
                if (list[lo].CompareTo(list[hi]) <= 0)
                {
                    result.Add(list[lo]);
                    lo++;
                }
                else
                {
                    result.Add(list[hi]);
                    hi++;
                }
            }

            while (lo <= mid)
            {
                result.Add(list[lo]);
                lo++;
            }

            while (hi <= right)
            {
                result.Add(list[hi]);
                hi++;
            }

            var ind = 0;
            for (var i = left; i <= right; i++)
            {
                list[i] = result[ind];
                ind++;
            }
        }
    }
}
