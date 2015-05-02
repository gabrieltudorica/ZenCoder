namespace RandomPancakeStack
{
    public class Pancake
    {
        private readonly int width;
        private readonly int deliciousness;
        
        public Pancake(int width, int deliciousness)
        {
            this.width = width;
            this.deliciousness = deliciousness;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetDeliciousness()
        {
            return deliciousness;
        }
    }
}
