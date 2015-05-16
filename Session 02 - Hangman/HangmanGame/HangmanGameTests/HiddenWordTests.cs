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
            Assert.AreEqual("S______D", GetInitialPuzzleFor("someWord"));
        }

        [TestMethod]
        public void FirstLetterIsDuplicated_GetPartial_RevealsTheDuplicatedFirstLetter()
        {
            Assert.AreEqual("B__B____N", GetInitialPuzzleFor("bomberman"));
        }

        [TestMethod]
        public void LastLetterIsDuplicated_GetPartial_RevelasTheDuplicatedLastLetter()
        {
            Assert.AreEqual("J___NN", GetInitialPuzzleFor("johann"));
        }

        [TestMethod]
        public void BothFirstAndLastLettersAreDuplicated_GetPartial_RevealsAllDuplicatedLetters()
        {
            Assert.AreEqual("PE__PE____E", GetInitialPuzzleFor("perspective"));
        }

        [TestMethod]
        public void FirstAndLastLettersAreTheSame_GetPartial_RevealsDuplicatedLetters()
        {
            Assert.AreEqual("S____S_S", GetInitialPuzzleFor("synopsis"));
        }

        private static string GetInitialPuzzleFor(string solution)
        {
            var word = new HiddenWord(solution);
            return word.GetPartialSolution();
        }
    }
}
