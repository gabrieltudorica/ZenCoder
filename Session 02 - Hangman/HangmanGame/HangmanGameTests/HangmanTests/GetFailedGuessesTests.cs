using System.Collections.Generic;
using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class GetFailedGuessesTests
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
        public void ReturnsAListWithTheFailedGuess_WhenLetterIsNotGuessed()
        {
            const char invalidLetter = 'x';
            hangman.AttemptGuess(invalidLetter);

            List<char> failedGuesses = hangman.GetFailedGuesses();

            Assert.AreEqual(1, failedGuesses.Count);
            Assert.AreEqual(invalidLetter, failedGuesses[0]);
        }

        [TestMethod]
        public void ReturnsFailedGuesses_WhenMultipleLettersAreNotGuessed()
        {
            var expectedFailedGuesses = new[] { 'z', 'x', 'r', 'y' };
            hangmanTestsHelper.AttemptGuessesWith(expectedFailedGuesses);

            CollectionAssert.AreEqual(expectedFailedGuesses, hangman.GetFailedGuesses());
        }

        [TestMethod]
        public void ReturnsAnEmptyList_WhenLetterIsGuessed()
        {
            const char invalidLetter = 'g';
            hangman.AttemptGuess(invalidLetter);

            List<char> failedGuesses = hangman.GetFailedGuesses();

            Assert.AreEqual(0, failedGuesses.Count);
        }

        [TestMethod]
        public void ReturnsAFailedGuessOnce_WhenSameLetterNotGuessedMultipleTimes()
        {
            hangmanTestsHelper.AttemptMultipleGuessesWithSingleLetter('x', 10);

            List<char> failedGuesses = hangman.GetFailedGuesses();

            Assert.AreEqual(1, failedGuesses.Count);
            Assert.AreEqual('x', failedGuesses[0]);
        }
    }
}
