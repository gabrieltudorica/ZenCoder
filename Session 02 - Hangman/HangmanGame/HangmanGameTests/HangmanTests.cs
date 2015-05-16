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
        public void GameStarts_RemainingAttempts_ReturnsSix()
        {
            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts, remainingAttempts);
        }

        [TestMethod]
        public void LetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            hangman.AttemptGuess('x');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts -1, remainingAttempts);
        }

        [TestMethod]
        public void LetterIsGuessed_RemainingAttempts_DoesNotDecrement()
        {
            hangman.AttemptGuess('g');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(MaxAttempts, remainingAttempts);
        }

        [TestMethod]
        public void MultipleLettersAreNotGuessed_RemainingAttempts_DecrementsWithTheTotalOfFailedGuesses()
        {
            var expectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            MakeMultipleFailedGuesses(expectedInvalidLetters);

            int expectedRemainingAttempts = MaxAttempts - expectedInvalidLetters.Count();
            int actualRemainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(expectedRemainingAttempts, actualRemainingAttempts);
        }

        [TestMethod]
        public void LetterIsNotGuessed_GetPartialWord_RemainsUnchanged()
        {
            string expected = hangman.GetPartialWord();
            hangman.AttemptGuess('x');

            string actual = hangman.GetPartialWord();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LetterIsGuessed_GetPartialWord_RevealsGuessedLetter()
        {
            const string expected = "H_NG__N";
            hangman.AttemptGuess('g');

            string actual = hangman.GetPartialWord();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllGuessesAreCorrect_GetPartialWord_ReturnsTheRevealedSolutionIncrementally()
        {
            hangman.AttemptGuess('a');
            Assert.AreEqual("HAN__AN", hangman.GetPartialWord());

            hangman.AttemptGuess('g');
            Assert.AreEqual("HANG_AN", hangman.GetPartialWord());

            hangman.AttemptGuess('m');
            Assert.AreEqual("HANGMAN", hangman.GetPartialWord());
        }

        [TestMethod]
        public void LetterIsNotGuessed_GetInvalidChosenLetters_ReturnsAListWithTheChosenLetter()
        {
            const char invalidLetter = 'x';
            hangman.AttemptGuess(invalidLetter);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(1, invalidChosenLetters.Count);
            Assert.AreEqual(invalidLetter, invalidChosenLetters[0]);
        }

        [TestMethod]
        public void MultipleLettersAreNotGuessed_GetInvalidChosenLetters_ReturnsTheChosenLetters()
        {
            var explectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            MakeMultipleFailedGuesses(explectedInvalidLetters);       

            List<char> actualInvalidLetters = hangman.GetInvalidChosenLetters();

            CollectionAssert.AreEqual(explectedInvalidLetters, actualInvalidLetters);
        }

        [TestMethod]
        public void LetterIsGuessed_GetInvalidChosenLetters_ReturnsAnEmptyList()
        {
            const char invalidLetter = 'g';
            hangman.AttemptGuess(invalidLetter);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(0, invalidChosenLetters.Count);
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
            hangman.AttemptGuess('a');
            hangman.AttemptGuess('g');            
            hangman.AttemptGuess('m');

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

            hangman.AttemptGuess('x');
            hangman.AttemptGuess('y');
            hangman.AttemptGuess('z');
            hangman.AttemptGuess('r');
            hangman.AttemptGuess('q');
            hangman.AttemptGuess('w');

            Assert.AreEqual(true, hangman.IsGameOver());
        }

        [TestMethod]
        public void SameLetterNotGuessedMultipleTimes_RemainingAttempts_DecrementByOneOnce()
        {
            hangman.AttemptGuess('x');
            int expectedRemainingAttempts = hangman.RemainingAttempts;

            for (int i = 0; i < 10; i++)
            {
                hangman.AttemptGuess('x');
            }
            int actualRemainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(expectedRemainingAttempts, actualRemainingAttempts);
        }

        [TestMethod]
        public void SameLetterNotGuessedMultipleTimes_GetInvalidChosenLetters_ReturnsTheNotGuessedLetterOnce()
        {
            for (int i = 0; i < 10; i++)
            {
                hangman.AttemptGuess('x');
            }

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(1, invalidChosenLetters.Count);
            Assert.AreEqual('x', invalidChosenLetters[0]);
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
