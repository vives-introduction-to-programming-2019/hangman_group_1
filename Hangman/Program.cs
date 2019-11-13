using System;

namespace Hangman
{
    class Program
    {
        // STEP 2 - The secret
        // Place here to make bigger scope, we need it in multiple methods
        static string secret = "";

        // STEP 3 - Revealed secret (includes correct guessed letters)
        static string revealedSecret = "";

        // STEP 1 - Welcome text to user
        static void WelcomeText()
        {
            Console.WriteLine("Welcome to Hangman.");
            Console.WriteLine("I have a word for you to guess.");
            Console.WriteLine("You have a number of guesses or its the gallows.");
        }

        // STEP 2 - Generate a secret word
        static void GenerateSecret()
        {
            secret = "Hello World";
        }

        // STEP 3 - Build the initial revealed secret string
        // Hello World => _ _ _ _ _   _ _ _ _ _
        static void BuildInitialRevealedSecret()
        {
            // This will make revealed secret twice as long as original secret
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] != ' ')
                {
                    revealedSecret += "_ ";
                } else
                {
                    revealedSecret += "  ";
                }
            }
        }

        // STEP 4 - Request a letter from the user
        // returns a letter of type char
        static char RequestLetterFromUser()
        {
            // Keep asking for valid lowercased letter
            char letter = ' ';
            do
            {
                Console.Write("Please enter your guess (single letter): ");

                // Long version:
                string input = Console.ReadLine();      // Read letter
                input = input.ToLower();                // Lowercase
                letter = Convert.ToChar(input);         // String to single char

                // Short version:
                // letter = Convert.ToChar(Console.ReadLine().ToLower());
            } while (!(letter >= 'a' && letter <= 'z')) ;
            
            //char letter = Console.ReadLine()[0];      // Alternative

            return letter;
        }

        static void Main(string[] args)
        {
            WelcomeText();      // STEP 1
            GenerateSecret();   // STEP 2
            BuildInitialRevealedSecret();       // STEP 3

            // Print revealed secret
            Console.WriteLine($"Current progress: {revealedSecret.Trim()}");

            // STEP 4 - Get a guess from the user and save in variable
            char userGuess = RequestLetterFromUser();
            Console.WriteLine($"Your guess: {userGuess}");
        }
    }
}
