using System.Collections.Generic;

namespace RandomPancakeStack
{
    //Problem: https://arena.topcoder.com/#/u/practiceCode/16444/47662/13749/2/326037

    public class RandomPancakeStackDiv2
    {                
        public double ExpectedDeliciousness(int[] d)
        {
            if (d.Length == 0)
            {
                return 0;
            }

            List<Pancake> pancakes = CreatePancakes(d);
            var permutations = new PancakePermutations(pancakes);
            List<List<Pancake>> possiblePermutations = permutations.GenerateAll();

            return 1;
        }
        
        private List<Pancake> CreatePancakes(int[] deliciousness)
        {
            var pancakes = new List<Pancake>();

            for (int index = 0; index < deliciousness.Length; index++)
            {
                pancakes.Add(CreateSinglePancake(index, deliciousness[index]));
            }

            return pancakes;
        }

        private Pancake CreateSinglePancake(int index, int deliciousness)
        {
            int width = index + 1;
            
            return new Pancake(width, deliciousness);
        }
    }
}
