using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HangmanTests
    {
        [TestMethod]
        public void WhenGameStarts_RemainingAttempts_ReturnsSix()
        {
            var solution = new WordSolution("hangman");
            var hangman = new Hangman(solution);

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(6, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsNotGuessed_RemainingAttempts_DecrementsByOne()
        {
            var solution = new WordSolution("hangman");
            var hangman = new Hangman(solution);
            hangman.AttemptGuess('x');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(5, remainingAttempts);
        }

        [TestMethod]
        public void WhenLetterIsGuessed_remainingAttempts_DoesNotDecrement()
        {
            var solution = new WordSolution("hangman");
            var hangman = new Hangman(solution);
            hangman.AttemptGuess('g');

            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(6, remainingAttempts);
        }
    }
}
