using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class AttemptGuessTests
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
        public void DoesNothing_WhenInputIsNotALetter()
        {
            hangman.AttemptGuess('|');

            Assert.AreEqual(hangmanTestsHelper.GetMaximumAttempts(), hangman.RemainingAttempts);
            Assert.AreEqual("H_N___N", hangman.GetPuzzle());
            Assert.IsFalse(hangman.IsGameOver());
            Assert.AreEqual(0, hangman.GetFailedGuesses().Count);
        }

        [TestMethod]
        public void FollowsNormalFlow_WhenInputIsALetter()
        {
            hangman.AttemptGuess('x');

            int expectedRemainingAttempts = hangmanTestsHelper.GetMaximumAttempts() - 1;
            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
            Assert.AreEqual("H_N___N", hangman.GetPuzzle());
            Assert.IsFalse(hangman.IsGameOver());
            Assert.AreEqual(1, hangman.GetFailedGuesses().Count);
        }
    }
}
