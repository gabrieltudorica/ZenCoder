using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HiddenWordTests
    {
        [TestMethod]
        public void FirstAndLastLettersNotContainedInTheWord_GetPartial_RevealsFirstAndLastLetters()
        {
            const string inputWord = "someWord";

            var word = new HiddenWord(inputWord);
            string partialSolution = word.GetPartial();

            Assert.AreEqual("S______D", partialSolution);
        }

        [TestMethod]
        public void FirstLetterIsDuplicated_GetPartial_RevealsTheDuplicatedFirstLetter()
        {
            const string inputWord = "bomberman";

            var word = new HiddenWord(inputWord);
            string partialWord = word.GetPartial();

            Assert.AreEqual("B__B____N", partialWord);
        }

        [TestMethod]
        public void LastLetterIsDuplicated_GetPartial_RevelasTheDuplicatedLastLetter()
        {
            const string inputWord = "johann";

            var word = new HiddenWord(inputWord);
            string partialWord = word.GetPartial();

            Assert.AreEqual("J___NN", partialWord);
        }

        [TestMethod]
        public void BothFirstAndLastLettersAreDuplicated_GetPartial_RevealsAllDuplicatedLetters()
        {
            const string inputWord = "perspective";

            var word = new HiddenWord(inputWord);
            string partialWord = word.GetPartial();

            Assert.AreEqual("PE__PE____E", partialWord);
        }

        [TestMethod]
        public void FirstAndLastLettersAreTheSame_GetPartial_RevealsDuplicatedLetters()
        {
            const string inputWord = "synopsis";

            var word = new HiddenWord(inputWord);
            string partialWord = word.GetPartial();

            Assert.AreEqual("S____S_S", partialWord);
        }
    }
}
