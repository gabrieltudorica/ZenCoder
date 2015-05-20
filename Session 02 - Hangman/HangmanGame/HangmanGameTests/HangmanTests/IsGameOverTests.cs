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

            Assert.IsFalse(hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsTrue_WhenSolutionFound()
        {
            var validLetters = new[] { 'a', 'g', 'm' };
            hangmanTestsHelper.AttemptGuessesWith(validLetters);

            Assert.IsTrue(hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsFalse_WhenRemainingAttemptsIsGreaterThanZero()
        {
            hangman.AttemptGuess('x');

            Assert.IsFalse(hangman.IsGameOver());
        }

        [TestMethod]
        public void ReturnsTrue_WhenRemainingAttemptsIsZero()
        {
            var invalidLetters = new[] { 'x', 'y', 'z', 'r', 'q', 'w' };
            hangmanTestsHelper.AttemptGuessesWith(invalidLetters);

            Assert.IsTrue(hangman.IsGameOver());
        }

        [TestMethod]
        public void GameStops_WhenAllAttemptsHaveBeenExhausted()
        {
            var invalidLettersToExhaustAllAttempts = new[] { 'x', 'y', 'z', 'r', 'q', 'w'};
            hangmanTestsHelper.AttemptGuessesWith(invalidLettersToExhaustAllAttempts);
            var invalidLettersIgnoredOnceGameIsOver = new[] {'v', 'v', 'b', 'k', 'p'};
            hangmanTestsHelper.AttemptGuessesWith(invalidLettersIgnoredOnceGameIsOver);
            
            Assert.IsTrue(hangman.IsGameOver());
            CollectionAssert.AreEqual(invalidLettersToExhaustAllAttempts, hangman.GetFailedGuesses());
            Assert.AreEqual(0, hangman.RemainingAttempts);
        }
    }
}
