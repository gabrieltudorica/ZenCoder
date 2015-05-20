using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class GetPuzzleTests
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
        public void RemainsUnchanged_WhenLetterIsNotGuessed()
        {
            string expected = hangman.GetPuzzle();
            hangman.AttemptGuess('x');

            Assert.AreEqual(expected, hangman.GetPuzzle());
        }

        [TestMethod]
        public void RevealsGuessedLetter_WhenLetterIsGuessed()
        {
            const string expected = "H_NG__N";
            hangman.AttemptGuess('g');

            Assert.AreEqual(expected, hangman.GetPuzzle());
        }

        [TestMethod]
        public void ReturnsTheRevealedSolutionIncrementally_WhenAllGuessesAreCorrect()
        {
            hangman.AttemptGuess('a');
            Assert.AreEqual("HAN__AN", hangman.GetPuzzle());

            hangman.AttemptGuess('g');
            Assert.AreEqual("HANG_AN", hangman.GetPuzzle());

            hangman.AttemptGuess('m');
            Assert.AreEqual("HANGMAN", hangman.GetPuzzle());
        }
    }
}
