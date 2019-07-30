using System.Collections.Generic;

namespace AlgorithmsLibrary.Transpositions
{
    public interface IPermutator<T>
    {
        IList<IList<T>> Permutate(IList<T> list);
    }
}
