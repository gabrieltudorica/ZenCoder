using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class WordSolutionTests
    {
        [TestMethod]
        public void WhenFirstAndLastLettersNotContainedInTheWord_GetPartial_RevealsFirstAndLastLetters()
        {
            const string inputWord = "someWord";

            var solution = new WordSolution(inputWord);
            string partialSolution = solution.GetPartial();

            Assert.AreEqual("S______D", partialSolution);
        }

        [TestMethod]
        public void WhenFirstLetterIsDuplicated_GetPartial_RevealsTheDuplicatedFirstLetter()
        {
            const string inputWord = "bomberman";

            var solution = new WordSolution(inputWord);
            string partialWord = solution.GetPartial();

            Assert.AreEqual("B__B____N", partialWord);
        }

        [TestMethod]
        public void WhenLastLetterIsDuplicated_GetPartial_RevelasTheDuplicatedLastLetter()
        {
            const string inputWord = "johann";

            var solution = new WordSolution(inputWord);
            string partialWord = solution.GetPartial();

            Assert.AreEqual("J___NN", partialWord);
        }

        [TestMethod]
        public void WhenBothFirstAndLastLettersAreDuplicated_GetPartial_RevealsAllDuplicatedLetters()
        {
            const string inputWord = "perspective";

            var solution = new WordSolution(inputWord);
            string partialWord = solution.GetPartial();

            Assert.AreEqual("PE__PE____E", partialWord);
        }

        [TestMethod]
        public void WhenFirstAndLastLettersAreTheSame_GetPartial_RevealsDuplicatedLetters()
        {
            const string inputWord = "synopsis";

            var solution = new WordSolution(inputWord);
            string partialWord = solution.GetPartial();

            Assert.AreEqual("S____S_S", partialWord);
        }
    }
}
