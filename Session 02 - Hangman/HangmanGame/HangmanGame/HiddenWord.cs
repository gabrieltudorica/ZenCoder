using System;
using System.Linq;

namespace HangmanGame
{
    public class HiddenWord
    {
        private readonly string solution;
        private readonly char[] partialSolution;
        private const char Placeholder = '_';

        public HiddenWord(string word)
        {
            solution = word.ToUpper();
            partialSolution = Enumerable.Repeat(Placeholder, word.Length).ToArray();

            RevealFirstAndLastLetters();      
        }        

        public string GetPartialSolution()
        {
            return new string(partialSolution);
        }

        public bool SolutionContainsLetter(char letter)
        {
            return solution.IndexOf(letter.ToString(), StringComparison.InvariantCultureIgnoreCase) != -1;
        }

        public bool IsSolved()
        {
            return !partialSolution.Contains(Placeholder);
        }

        public void AddLetterToSolution(char letter)
        {
            if (SolutionContainsLetter(letter))
            {
                RevealAllLettersWith(letter);
            }
        }

        private void RevealFirstAndLastLetters()
        {
            AddLetterToSolution(solution[0]);

            int lastLetterIndex = solution.Length - 1;
            AddLetterToSolution(solution[lastLetterIndex]);            
        }

        private void RevealAllLettersWith(char letter)
        {
            for (int letterIndex = 0; letterIndex < solution.Length; letterIndex++)
            {
                RevealLetter(letterIndex, letter);
            }
        }

        private void RevealLetter(int letterIndex, char letter)
        {
            if (AreEqual(solution[letterIndex], letter))
            {
                partialSolution[letterIndex] = char.ToUpper(letter);
            }
        }

        private static bool AreEqual(char letterA, char letterB)
        {
            return string.Equals(letterA.ToString(), letterB.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
}