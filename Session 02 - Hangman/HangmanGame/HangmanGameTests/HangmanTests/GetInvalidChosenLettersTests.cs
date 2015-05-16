using System.Collections.Generic;
using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests.HangmanTests
{
    [TestClass]
    public class GetInvalidChosenLettersTests
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
            hangmanTestsHelper.AttemptGuessesWith(explectedInvalidLetters);

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
        public void SameLetterNotGuessedMultipleTimes_GetInvalidChosenLetters_ReturnsTheNotGuessedLetterOnce()
        {
            hangmanTestsHelper.AttemptMultipleGuessesWithSingleLetter('x', 10);

            List<char> invalidChosenLetters = hangman.GetInvalidChosenLetters();

            Assert.AreEqual(1, invalidChosenLetters.Count);
            Assert.AreEqual('x', invalidChosenLetters[0]);
        }
    }
}
