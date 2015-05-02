using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace RandomPancakeStack
{
    public class PancakePermutations
    {
        private readonly Dictionary<int, Pancake> indexedPancakes = new Dictionary<int, Pancake>();
        
        public PancakePermutations(List<Pancake> pancakes)
        {
            for (int i = 0; i < pancakes.Count; i++)
            {
                indexedPancakes.Add(i, pancakes[i]);
            }            
        }

        public List<List<Pancake>> GenerateAll()
        {            
            var permutations = new List<List<Pancake>>();

            foreach (IList<int> indexPermutation in GetAllPermutationsByIndex())
            {
                List<Pancake> singlePermutation = MapPermutationIndexToPancake(indexPermutation);
                permutations.Add(singlePermutation);
            }

            return permutations;
        }

        private Permutations<int> GetAllPermutationsByIndex()
        {
            int[] allPancakes = Enumerable.Range(0, indexedPancakes.Count).ToArray();

            return new Permutations<int>(allPancakes, GenerateOption.WithoutRepetition);
        }

        private List<Pancake> MapPermutationIndexToPancake(IList<int> permutationByIndex)
        {
            var permutation = new List<Pancake>();

            foreach (int pancakeIndex in permutationByIndex)
            {
                int index = pancakeIndex;
                permutation.Add(indexedPancakes[index]);
            }

            return permutation;
        }
    }
}
