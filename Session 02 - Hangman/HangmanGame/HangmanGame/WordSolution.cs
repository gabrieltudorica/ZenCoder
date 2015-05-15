using System.Linq;

namespace HangmanGame
{
    public class WordSolution
    {
        private readonly string solution;
        private readonly char[] partialSolution;
        private const char Placeholder = '_';

        public WordSolution(string word)
        {
            solution = word.ToUpper();
            partialSolution = new char[word.Length];
            
            InitializePartialSolution();        
        }        

        public string GetPartial()
        {
            return new string(partialSolution);
        }

        public bool IsLetterValid(char letter)
        {
            return solution.Contains(letter.ToString());
        }

        public bool SolutionFound()
        {
            return partialSolution.Contains('_');
        }

        private void InitializePartialSolution()
        {            
            InsertPlaceholders();   
            RevealFirstAndLastLetters();
        }

        private void InsertPlaceholders()
        {
            for (int i = 0; i < partialSolution.Length; i++)
            {
                partialSolution[i] = Placeholder;
            }
        }

        private void RevealFirstAndLastLetters()
        {
            AddToPartialSolution(solution[0]);

            int lastLetterIndex = solution.Length - 1;
            AddToPartialSolution(solution[lastLetterIndex]);            
        }

        private void AddToPartialSolution(char letter)
        {
            if (IsLetterValid(letter))
            {
                RevealLetter(letter);
            }
        }        

        private void RevealLetter(char letter)
        {
            for (int letterIndex = 0; letterIndex < solution.Length; letterIndex++)
            {
                if (solution[letterIndex] == letter)
                {
                    partialSolution[letterIndex] = letter;
                }
            }
        }       
    }
}
