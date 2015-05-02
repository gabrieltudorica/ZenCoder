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

        [TestMethod]
        public void TopCoder_TestZero()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 1, 1, 1 });

            Assert.AreEqual(1.6666666666666667, deliciousness);
        }

        [TestMethod]
        public void TopCoder_TestOne()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 10, 20 });

            Assert.AreEqual(20.0, deliciousness);
        }

        [TestMethod]
        public void TopCoder_TestTwo()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 3, 6, 10, 9, 2 });

            Assert.AreEqual(9.891666666666667, deliciousness);
        }

        [TestMethod]
        public void TopCoder_TestThree()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            Assert.AreEqual(10.999999724426809, deliciousness);
        }

        [TestMethod]
        public void TopCoder_TestFour()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(7.901100088183421, deliciousness);
        }

        [TestMethod]
        public void TopCoder_TestFive()
        {
            double deliciousness = randomPancakeStack.ExpectedDeliciousness(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

            Assert.AreEqual(1.7182818011463845, deliciousness);
        }
    }
}
