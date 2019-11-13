using System;

namespace Hangman
{
    class Program
    {
        // STEP 1 - Welcome text to user
        static void WelcomeText()
        {
            Console.WriteLine("Welcome to Hangman.");
            Console.WriteLine("I have a word for you to guess.");
            Console.WriteLine("You have a number of guesses or its the gallows.");
        }

        static void Main(string[] args)
        {
            WelcomeText();      // STEP 1
        }
    }
}
