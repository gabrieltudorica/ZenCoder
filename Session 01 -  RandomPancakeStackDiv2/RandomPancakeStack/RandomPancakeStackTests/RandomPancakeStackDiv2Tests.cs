using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomPancakeStack;

namespace RandomPancakeStackTests
{
    [TestClass]
    public class RandomPancakeStackDiv2Tests
    {
        private readonly RandomPancakeStackDiv2 randomPancakeStack = new RandomPancakeStackDiv2();

        [TestMethod]
        public void HavingZeroPancakes_ExpectedDeliciousnessReturnsZero()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new int[0]);

            Assert.AreEqual(0, deliciousness);
        }

        [TestMethod]
        public void HavingOnePancake_ExpectedDeliciousnessReturnsTheDeliciousnessOfThePancake()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] {1});

            Assert.AreEqual(1, deliciousness);
        }
    }
}
