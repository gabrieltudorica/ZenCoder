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
        public void GameStarts_RemainingAttempts_ReturnsSix()
        {
            Assert.AreEqual(hangmanTestsHelper.GetMaximumAttempts(), hangman.RemainingAttempts);
        }

        [TestMethod]
        public void LetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            hangman.AttemptGuess('x');

            int expectedAttempts = hangmanTestsHelper.GetMaximumAttempts() - 1;
            Assert.AreEqual(expectedAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void LetterIsGuessed_RemainingAttempts_DoesNotDecrement()
        {
            hangman.AttemptGuess('g');

            Assert.AreEqual(hangmanTestsHelper.GetMaximumAttempts(), hangman.RemainingAttempts);
        }

        [TestMethod]
        public void MultipleLettersAreNotGuessed_RemainingAttempts_DecrementsWithTheTotalOfFailedGuesses()
        {
            var expectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            hangmanTestsHelper.AttemptGuessesWith(expectedInvalidLetters);

            int expectedRemainingAttempts = hangmanTestsHelper.GetMaximumAttempts() - expectedInvalidLetters.Length;

            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void SameLetterNotGuessedMultipleTimes_RemainingAttempts_DecrementByOneOnce()
        {
            hangman.AttemptGuess('x');
            int expectedRemainingAttempts = hangman.RemainingAttempts;

            hangmanTestsHelper.AttemptMultipleGuessesWithSingleLetter('x', 10);

            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }
    }
}
