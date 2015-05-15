using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HangmanTests
    {
        [TestMethod]
        public void RemainingAttempts_ReturnsSix()
        {
            var solution = new WordSolution("hangman");
            var hangman = new Hangman(solution);
            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(6, remainingAttempts);
        }        
    }
}
