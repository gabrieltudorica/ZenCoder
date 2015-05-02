using System.Collections.Generic;

namespace RandomPancakeStack
{
    //Problem: https://arena.topcoder.com/#/u/practiceCode/16444/47662/13749/2/326037

    public class RandomPancakeStackDiv2
    {       
        Dictionary<int, Pancake> pancakes = new Dictionary<int, Pancake>();
 
        public double ExpectedDeliciousness(int[] d)
        {
            if (d.Length == 0)
            {
                return 0;
            }

            CreatePancakes(d);                   

            return 1;
        }

        private void CreatePancakes(int[] deliciousness)
        {
            for (int index = 0; index < deliciousness.Length; index++)
            {
                CreateSinglePancake(index, deliciousness[index]);
            }
        }

        private void CreateSinglePancake(int index, int deliciousness)
        {
            int width = index + 1;
            var pancake = new Pancake(width, deliciousness);

            pancakes.Add(index, pancake);
        }
    }
}
