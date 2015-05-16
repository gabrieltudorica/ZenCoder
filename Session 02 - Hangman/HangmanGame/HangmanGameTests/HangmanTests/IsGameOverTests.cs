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
        public void SolutionIsNotFound_IsGameOver_ReturnsFalse()
        {
            hangman.AttemptGuess('g');

            Assert.AreEqual(false, hangman.IsGameOver());
        }

        [TestMethod]
        public void SolutionFound_IsGameOver_ReturnsTrue()
        {
            var validLetters = new[] { 'a', 'g', 'm' };
            hangmanTestsHelper.AttemptGuessesWith(validLetters);

            Assert.AreEqual(true, hangman.IsGameOver());
        }

        [TestMethod]
        public void RemainingAttemptsIsGreaterThanZero_IsGameOver_ReturnsFalse()
        {
            hangman.AttemptGuess('x');

            Assert.AreEqual(false, hangman.IsGameOver());
        }

        [TestMethod]
        public void RemainingAttemptsIsZero_IsGameOver_ReturnsTrue()
        {
            var invalidLetters = new[] { 'x', 'y', 'z', 'r', 'q', 'w' };
            hangmanTestsHelper.AttemptGuessesWith(invalidLetters);

            Assert.AreEqual(true, hangman.IsGameOver());
        }
    }
}
