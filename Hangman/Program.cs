using System;

namespace Hangman
{
    class Program
    {
        // STEP 2 - The secret
        // Place here to make bigger scope, we need it in multiple methods
        static string secret = "";

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

        static void Main(string[] args)
        {
            WelcomeText();      // STEP 1
            GenerateSecret();   // STEP 2
        }
    }
}
