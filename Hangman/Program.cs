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

        static void Main(string[] args)
        {
            WelcomeText();      // STEP 1
            GenerateSecret();   // STEP 2
            BuildInitialRevealedSecret();       // STEP 3

            // Print revealed secret
            Console.WriteLine($"Current progress: {revealedSecret.Trim()}");
        }
    }
}
