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
            Assert.AreEqual(MaxAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void LetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            hangman.AttemptGuess('x');

            Assert.AreEqual(MaxAttempts -1, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void LetterIsGuessed_RemainingAttempts_DoesNotDecrement()
        {
            hangman.AttemptGuess('g');

            Assert.AreEqual(MaxAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void MultipleLettersAreNotGuessed_RemainingAttempts_DecrementsWithTheTotalOfFailedGuesses()
        {
            var expectedInvalidLetters = new[] { 'z', 'x', 'r', 'y' };
            AttemptGuessesWith(expectedInvalidLetters);

            int expectedRemainingAttempts = MaxAttempts - expectedInvalidLetters.Count();

            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void LetterIsNotGuessed_GetPartialWord_RemainsUnchanged()
        {
            string expected = hangman.GetPartialWord();
            hangman.AttemptGuess('x');

            Assert.AreEqual(expected, hangman.GetPartialWord());
        }

        [TestMethod]
        public void LetterIsGuessed_GetPartialWord_RevealsGuessedLetter()
        {
            const string expected = "H_NG__N";
            hangman.AttemptGuess('g');

            Assert.AreEqual(expected, hangman.GetPartialWord());
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
            AttemptGuessesWith(explectedInvalidLetters);       

            CollectionAssert.AreEqual(explectedInvalidLetters, hangman.GetInvalidChosenLetters());
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
            var validLetters = new[] { 'a', 'g', 'm'};
            AttemptGuessesWith(validLetters);
            
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
            AttemptGuessesWith(invalidLetters);

            Assert.AreEqual(true, hangman.IsGameOver());
        }

        [TestMethod]
        public void SameLetterNotGuessedMultipleTimes_RemainingAttempts_DecrementByOneOnce()
        {
            hangman.AttemptGuess('x');
            int expectedRemainingAttempts = hangman.RemainingAttempts;

            AttemptMultipleGuessesWithSingleLetter('x', 10);
            
            Assert.AreEqual(expectedRemainingAttempts, hangman.RemainingAttempts);
        }

        [TestMethod]
        public void SameLetterNotGuessedMultipleTimes_GetInvalidChosenLetters_ReturnsTheNotGuessedLetterOnce()
        {
            AttemptMultipleGuessesWithSingleLetter('x', 10);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(1, invalidChosenLetters.Count);
            Assert.AreEqual('x', invalidChosenLetters[0]);
        }

        private void AttemptGuessesWith(IEnumerable<char> letters)
        {
            foreach (char letter in letters)
            {
                hangman.AttemptGuess(letter);
            }     
        }

        private void AttemptMultipleGuessesWithSingleLetter(char letter, int numberOfAttempts)
        {
            for (int i = 0; i < numberOfAttempts; i++)
            {
                hangman.AttemptGuess(letter);
            }
        }
    }
}
