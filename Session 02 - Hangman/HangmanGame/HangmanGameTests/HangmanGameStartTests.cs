using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HangmanGameStartTests
    {
        [TestMethod]
        public void RemainingAttepts_ReturnsSix()
        {
            var hangman = new Hangman("someWord");
            int remainingAttempts = hangman.RemainingAttempts;

            Assert.AreEqual(6, remainingAttempts);
        }

        [TestMethod]
        public void WhenFirstAndLastLettersNotContainedInTheWord_GetPartialWord_RevealsFirstAndLastLetters()
        {
            const string inputWord = "someWord";

            var hangman = new Hangman(inputWord);
            string partialWord = hangman.GetPartialWord();

            Assert.AreEqual("S______D", partialWord);
        }

        [TestMethod]
        public void WhenFirstLetterIsDuplicatedInTheWord_GetPartialWord_RevealsTheDuplicatedFirstLetter()
        {
            const string inputWord = "bomberman";

            var hangman = new Hangman(inputWord);
            string partialWord = hangman.GetPartialWord();

            Assert.AreEqual("B__B____N", partialWord);
        }

        [TestMethod]
        public void WhenLastLetterIsDuplicatedInTheWord_GetPartialWord_RevelasTheDuplicatedLastLetter()
        {
            const string inputWord = "johann";

            var hangman = new Hangman(inputWord);
            string partialWord = hangman.GetPartialWord();

            Assert.AreEqual("J___NN", partialWord);
        }

        [TestMethod]
        public void WhenBothFirstAndLastLettersAreDuplicatedInTheWord_GetPartialWord_RevealsAllDuplicatedLetters()
        {
            const string inputWord = "perspective";

            var hangman = new Hangman(inputWord);
            string partialWord = hangman.GetPartialWord();

            Assert.AreEqual("PE__PE____E", partialWord);
        }

        [TestMethod]
        public void WhenFirstAndLastLettersAreTheSame_GetPartialWord_RevealsDuplicatedLetters()
        {
            const string inputWord = "synopsis";

            var hangman = new Hangman(inputWord);
            string partialWord = hangman.GetPartialWord();

            Assert.AreEqual("S____S_S", partialWord);
        }
    }
}
