using System.Collections.Generic;

namespace RandomPancakeStack
{
    public class PancakeStack
    {
        private readonly Queue<Pancake> pancakes = new Queue<Pancake>();
 
        public PancakeStack(List<Pancake> pancakes)
        {
            foreach (Pancake pancake in pancakes)
            {
                this.pancakes.Enqueue(pancake);
            }            
        }

        public double ComputeDeliciousness()
        {
            double probability = 1.0/pancakes.Count;  
          
            Pancake previousPancake = pancakes.Dequeue();
            double deliciousness = probability * previousPancake.GetDeliciousness();

            while (pancakes.Count != 0)
            {
                Pancake currentPancake = pancakes.Dequeue();

                if (currentPancake.GetWidth() > previousPancake.GetWidth())
                {
                    break;                    
                }

                deliciousness += probability*currentPancake.GetDeliciousness();
                previousPancake = currentPancake;
            }
            
            return deliciousness;
        }
    }
}
