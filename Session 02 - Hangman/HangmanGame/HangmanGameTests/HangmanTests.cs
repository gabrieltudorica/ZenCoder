using System.Collections.Generic;
using System.Linq;
using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HangmanTests
    {
        private const int MaxAttempts = 6;

        private WordSolution solution;
        private Hangman hangman;

        [TestInitialize]
        public void TestInitialize()
        {
            solution = new WordSolution("hangman");
            hangman = new Hangman(solution);
        }

        [TestMethod]
        public void WhenGameStarts_RemainingAttempts_ReturnsSix()
        {
            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            hangman.AttemptGuess('x');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts -1, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsGuessed_RemainingAttempts_DoesNotDecrement()
        {
            hangman.AttemptGuess('g');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts, remainingAttempts);
        }

        [TestMethod]
        public void WhenMultipleLettersAreNotGuessed_RemainingAttempts_DecrementsWithTheTotalOfFailedGuesses()
        {
            var expectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            MakeMultipleFailedGuesses(expectedInvalidLetters);

            int expectedRemainingAttempts = MaxAttempts - expectedInvalidLetters.Count();
            int actualRemainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(expectedRemainingAttempts, actualRemainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsNotGuessed_GetPartialWord_RemainsUnchanged()
        {
            string expected = hangman.GetPartialWord();
            hangman.AttemptGuess('x');

            string actual = hangman.GetPartialWord();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenLetterIsGuessed_GetPartialWord_RevealsGuessedLetter()
        {
            const string expected = "H_NG__N";
            hangman.AttemptGuess('g');

            string actual = hangman.GetPartialWord();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenAllGuessesAreCorrect_GetPartialWord_ReturnsTheRevealedSolutionIncrementally()
        {
            hangman.AttemptGuess('a');
            Assert.AreEqual("HAN__AN", hangman.GetPartialWord());

            hangman.AttemptGuess('g');
            Assert.AreEqual("HANG_AN", hangman.GetPartialWord());

            hangman.AttemptGuess('m');
            Assert.AreEqual("HANGMAN", hangman.GetPartialWord());
        }

        [TestMethod]
        public void WhenLetterIsNotGuessed_GetInvalidChosenLetters_ReturnsAListWithTheChosenLetter()
        {
            const char invalidLetter = 'x';
            hangman.AttemptGuess(invalidLetter);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(1, invalidChosenLetters.Count);
            Assert.AreEqual(invalidLetter, invalidChosenLetters[0]);
        }

        [TestMethod]
        public void WhenMultipleLettersAreNotGuessed_GetInvalidChosenLetters_ReturnsAListWithTheChosenLetters()
        {
            var explectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            MakeMultipleFailedGuesses(explectedInvalidLetters);       

            List<char> actualInvalidLetters = hangman.GetInvalidChosenLetters();

            CollectionAssert.AreEqual(explectedInvalidLetters, actualInvalidLetters);
        }

        [TestMethod]
        public void WhenLetterIsGuessed_GetInvalidChosenLetters_ReturnsAnEmptyList()
        {
            const char invalidLetter = 'g';
            hangman.AttemptGuess(invalidLetter);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(0, invalidChosenLetters.Count);
        }

        private void MakeMultipleFailedGuesses(IEnumerable<char> invalidLetters)
        {
            foreach (char invalidLetter in invalidLetters)
            {
                hangman.AttemptGuess(invalidLetter);
            }     
        }
    }
}
