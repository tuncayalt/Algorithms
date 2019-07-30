using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLibrary.Transpositions
{
    public class FastPermutator<T> : IPermutator<T>
    {
        public IList<IList<T>> Permutate(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var result = new List<IList<T>>();

            if (list.Count == 0)
            {
                return result;
            }

            Permutate(list, result, 0, list.Count - 1);

            return result;
        }

        public IList<IList<T>> LexicoPermutate(IList<T> list)
        {
            throw new NotImplementedException();
        }

        private void Permutate(IList<T> list, ICollection<IList<T>> result, int lo, int hi)
        {
            if (lo == hi)
            {
                result.Add(list.ToList());
            }
            else
            {
                for (var i = lo; i <= hi; i++)
                {
                    Swap(list, lo, i);
                    Permutate(list, result, lo + 1, hi);
                    Swap(list, lo, i);
                }
            }
        }

        private void Swap(IList<T> list, int index1, int index2)
        {
            if (index1 == index2)
            {
                return;
            }

            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
