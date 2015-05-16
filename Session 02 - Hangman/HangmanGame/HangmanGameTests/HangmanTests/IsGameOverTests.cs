using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class IsGameOverTests
    {
        private HangmanTestsHelper hangmanTestsHelper;
        private Hangman hangman;

        [TestInitialize]
        public void TestInitialize()
        {
            hangmanTestsHelper = new HangmanTestsHelper();
            hangman = hangmanTestsHelper.GetInstance();
        }

        [TestMethod]
        public void ReturnsFalse_WhenSolutionIsNotFound()
        {
            hangman.AttemptGuess('g');

            Assert.AreEqual(false, hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsTrue_WhenSolutionFound()
        {
            var validLetters = new[] { 'a', 'g', 'm' };
            hangmanTestsHelper.AttemptGuessesWith(validLetters);

            Assert.AreEqual(true, hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsFalse_WhenRemainingAttemptsIsGreaterThanZero()
        {
            hangman.AttemptGuess('x');

            Assert.AreEqual(false, hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsTrue_WhenRemainingAttemptsIsZero()
        {
            var invalidLetters = new[] { 'x', 'y', 'z', 'r', 'q', 'w' };
            hangmanTestsHelper.AttemptGuessesWith(invalidLetters);

            Assert.AreEqual(true, hangman.IsGameOver());
        }
    }
}
