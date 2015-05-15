using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HangmanTests
    {
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

            Assert.AreEqual(6, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            hangman.AttemptGuess('x');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(5, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsGuessed_RemainingAttempts_DoesNotDecrement()
        {
            hangman.AttemptGuess('g');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(6, remainingAttempts);
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
    }
}
