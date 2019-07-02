using System;
using System.Collections.Generic;

namespace AlgorithmsLibrary.Sorts
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable
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

            var index = Partition(list, left, right);

            Sort(list, left, index - 1);
            Sort(list, index + 1, right);
        }

        private int Partition(IList<T> list, int left, int right)
        {
            var pivot = left;

            while (left < right)
            {
                while (list[left].CompareTo(list[pivot]) < 0)
                {
                    left++;
                }

                while (list[right].CompareTo(list[pivot]) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    if (list[left].CompareTo(list[right]) == 0)
                    {
                        left++;
                        continue;
                    }

                    Swap(list, left, right);
                }
            }

            return right;
        }

        private void Swap(IList<T> list, int left, int right)
        {
            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
