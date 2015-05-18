using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class SolutionFound
    {
        private HangmanTestsHelper hangmanTestsHelper;
        private Hangman hangman;
        private readonly char[] solution = { 'a', 'g', 'm' };

        [TestInitialize]
        public void TestInitialize()
        {
            hangmanTestsHelper = new HangmanTestsHelper();
            hangman = hangmanTestsHelper.GetInstance();
        }

        [TestMethod]
        public void ReturnsFlase_WhenSolutionIsNotFound()
        {
            Assert.IsFalse(hangman.SolutionFound());
        }

        [TestMethod]
        public void ReturnsTrue_WhenSolutionIsFound()
        {
            hangmanTestsHelper.AttemptGuessesWith(solution);
            
            Assert.IsTrue(hangman.SolutionFound());
        }

        [TestMethod]
        public void GameStops_WhenSolutionIsFound()
        {
            hangmanTestsHelper.AttemptGuessesWith(solution);
            var invalidLettersIgnoredOnceGameIsOver = new[] { 'v', 'v', 'b', 'k', 'p' };
            hangmanTestsHelper.AttemptGuessesWith(invalidLettersIgnoredOnceGameIsOver);

            Assert.IsTrue(hangman.IsGameOver());
            Assert.IsTrue(hangman.SolutionFound());
            Assert.AreEqual(6, hangman.RemainingAttempts);
            Assert.AreEqual(0, hangman.GetInvalidChosenLetters().Count);
        }
    }
}
