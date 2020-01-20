using System;
using System.Text;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordbank = { "Banan", "Coding", "Beginner", "cat", "attribuets", "loops", "array" };

            string wordToGuess = wordbank[random.Next(0, wordbank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
            displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 6;
            bool won = false;
            int lettersReveald = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                if(input == "")
                {
                    continue;
                }
                guess = input[0];

                if (correctGuesses.Contains (guess))
                {
                    Console.WriteLine($"You alredy tried {guess} and it was correct!");
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine($"You alredy tried {guess} and it was wrong!");
                    continue;
                }
                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);
                    for(int i =0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersReveald++;
                        }
                    }
                    if(lettersReveald == wordToGuess.Length)
                       
                        won = true;
                    
                }
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine($"Nope, there's no {guess} in it!");
                    lives--;
                }
                Console.WriteLine(displayToPlayer.ToString());
            }
            if (won)

                Console.WriteLine("You WON!!!");

            else
            {
                Console.WriteLine($" (X__X) You lost it was {wordToGuess}");
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
