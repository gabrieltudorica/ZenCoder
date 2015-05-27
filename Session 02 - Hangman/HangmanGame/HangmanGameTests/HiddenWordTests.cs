using HangmanGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTests
{
    [TestClass]
    public class HiddenWordTests
    {
        [TestMethod]
        public void FirstAndLastLettersNotContainedInTheWord_GetPartialSolution_RevealsFirstAndLastLetters()
        {
            Assert.AreEqual("S______D", GetInitialPuzzleFor("someWord"));
        }

        [TestMethod]
        public void FirstLetterIsDuplicated_GetPartialSolution_RevealsTheDuplicatedFirstLetter()
        {
            Assert.AreEqual("B__B____N", GetInitialPuzzleFor("bomberman"));
        }

        [TestMethod]
        public void LastLetterIsDuplicated_GetPartialSolution_RevelasTheDuplicatedLastLetter()
        {
            Assert.AreEqual("J___NN", GetInitialPuzzleFor("johann"));
        }

        [TestMethod]
        public void BothFirstAndLastLettersAreDuplicated_GetPartialSolution_RevealsAllDuplicatedLetters()
        {
            Assert.AreEqual("PE__PE____E", GetInitialPuzzleFor("perspective"));
        }

        [TestMethod]
        public void FirstAndLastLettersAreTheSame_GetPartialSolution_RevealsDuplicatedLetters()
        {
            Assert.AreEqual("S____S_S", GetInitialPuzzleFor("synopsis"));
        }

        private static string GetInitialPuzzleFor(string solution)
        {
            var word = new HiddenWord(solution);
            return word.GetPartial();
        }
    }
}
