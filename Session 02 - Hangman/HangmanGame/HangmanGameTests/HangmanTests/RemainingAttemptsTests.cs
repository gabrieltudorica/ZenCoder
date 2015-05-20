using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class RemainingAttemptsTests
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
        public void ReturnsSix_WhenGameStarts()
        {
            Assert.AreEqual(hangmanTestsHelper.GetMaximumAttempts(), hangman.RemainingAttempts);
        }

        [TestMethod]
        public void DecrementsByOne_WhenLetterIsNotGuessed()
        {
            hangman.AttemptGuess('x');

            int expectedAttempts = hangmanTestsHelper.GetMaximumAttempts() - 1;
            Assert.AreEqual(expectedAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void DoesNotDecrement_WhenLetterIsGuessed()
        {
            hangman.AttemptGuess('g');

            Assert.AreEqual(hangmanTestsHelper.GetMaximumAttempts(), hangman.RemainingAttempts);
        }

        [TestMethod]
        public void DecrementByOneOnce_WhenGuessIsAttemptedWithSameLetterNotInSolutionMultipleTimes()
        {
            hangman.AttemptGuess('x');
            int expectedRemainingAttempts = hangman.RemainingAttempts;

            hangmanTestsHelper.AttemptMultipleGuessesWithSingleLetter('x', 10);

            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void DecrementsByOne_ForeachFailedGuess()
        {
            var expectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            hangmanTestsHelper.AttemptGuessesWith(expectedInvalidLetters);

            int expectedRemainingAttempts = hangmanTestsHelper.GetMaximumAttempts() - expectedInvalidLetters.Length;

            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }
    }
}
