using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsLibrary.Transpositions
{
    public class LexicoPermutator<T> : IPermutator<T> where T : IComparable
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

            result.Add(list);

            var resultLength = Factorial(list.Count);

            for (var i = 1; i < resultLength; i++)
            {
                result.Add(NextPermutation(result[i - 1]));
            }

            return result;
        }

        private int Factorial(int listCount)
        {
            var result = 1;
            
            for (var i = 2; i <= listCount; i++)
            {
                result *= i;
            }

            return result;
        }

        private IList<T> NextPermutation(IList<T> list)
        {
            var result = list.ToList();
            var lessIndex = -1;
            var greaterIndex = -1;

            for (var i = result.Count - 1; i >= 1; i--)
            {
                if (result[i - 1].CompareTo(result[i]) < 0)
                {
                    lessIndex = i - 1;
                    break;
                }
            }

            if (lessIndex == -1)
            {
                return list.Reverse().ToList();
            }

            for (var i = result.Count - 1; i >= 1; i--)
            {
                if (result[i].CompareTo(result[lessIndex]) > 0)
                {
                    greaterIndex = i;
                    break;
                }
            }

            Swap(result, lessIndex, greaterIndex);

            result.Reverse(lessIndex + 1, result.Count - lessIndex - 1);

            return result;
        }

        private void Swap(IList<T> result, int lessIndex, int greaterIndex)
        {
            var temp = result[lessIndex];
            result[lessIndex] = result[greaterIndex];
            result[greaterIndex] = temp;
        }
    }
}
