﻿using System.Collections.Generic;

namespace HangmanGame
{
    public class Hangman
    {
        private const int MaxAttempts = 6;
        
        private readonly HiddenWord word;
        private readonly List<char> failedGuesses = new List<char>(); 

        public int RemainingAttempts { get; private set; }

        public Hangman(string word)
        {
            this.word = new HiddenWord(word);

            RemainingAttempts = MaxAttempts;            
        }        

        public string GetPuzzle()
        {
            return word.GetPartialSolution();
        }

        public void AttemptGuess(char character)
        {
            if (IsGameOver() || !IsLetter(character))
            {
                return;
            }
            
            if (word.SolutionContainsLetter(character))
            {
                word.AddLetterToSolution(character);
                return;
            }

            PenalizePlayerFor(character);
        }

        public List<char> GetFailedGuesses()
        {
            return failedGuesses;
        }

        public bool IsGameOver()
        {
            return RemainingAttempts==0 || IsSolutionFound();
        }

        public bool IsSolutionFound()
        {
            return word.IsSolved();
        }

        private bool IsLetter(char character)
        {
            return char.IsLetter(character);
        }

        private void PenalizePlayerFor(char character)
        {
            if (!failedGuesses.Contains(character))
            {
                RemainingAttempts--;
                failedGuesses.Add(character);
            }
        }
    }
}