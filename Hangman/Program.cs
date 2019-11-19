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

        // STEP 5 - Previous guessed letters
        static string previousGuessedLetters = "";

        // STEP 7 - Number of wrong tries
        static int numberOfWrongTriesLeft = 5;

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
            secret = "Hello World".ToLower();
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

        // STEP 6 - Process User Guessed Letter
        static void ProcessUserGuess(char letter)
        {
            if (secret.Contains(letter) && !previousGuessedLetters.Contains(letter))
            {
                // OKAY
                Console.WriteLine("Good guess.");

                // Need to make a new revealed secret with guess + old guesses
                string newRevealedSecret = "";
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == letter)        // Found match
                    {
                        newRevealedSecret += $"{letter} ";
                    }
                    else if (previousGuessedLetters.Contains($"{secret[i]}"))
                    {
                        newRevealedSecret += $"{secret[i]} ";
                    }
                    else
                    {
                        newRevealedSecret += "_ ";
                    }
                }
                revealedSecret = newRevealedSecret;

                // Add the letter to the list of guessed letters
                previousGuessedLetters += letter + " ";
            }
            else if (!previousGuessedLetters.Contains(letter))
            {
                // STEP 7
                numberOfWrongTriesLeft--;
                Console.WriteLine("Sorry, wrong guess. Getting closer to the gallows.");
                Console.WriteLine($"You have {numberOfWrongTriesLeft} tries left");

                // Add the letter to the list of guessed letters
                previousGuessedLetters += letter + " ";
            }
            else
            {
                Console.WriteLine("Sorry. Already tried that one.");
            }
        }

        static void GameLoop()
        {
            do
            {
                // Print revealed secret
                Console.WriteLine($"Current progress: {revealedSecret.Trim()}");

                // STEP 5 - Show previous guesses
                Console.WriteLine($"Previous guessed letters: {previousGuessedLetters.Trim()}");

                // STEP 4 - Get a guess from the user and save in variable
                char userGuess = RequestLetterFromUser();
                Console.WriteLine($"Your guess: {userGuess}");

                // STEP 6 - Process the letter from the user
                ProcessUserGuess(userGuess);

                Console.WriteLine($"Current progress: {revealedSecret.Trim()}");
            } while (numberOfWrongTriesLeft != 0 && revealedSecret.Contains("_"));
        }

        static void Main(string[] args)
        {
            WelcomeText();      // STEP 1
            GenerateSecret();   // STEP 2
            BuildInitialRevealedSecret();       // STEP 3
            GameLoop();     // Loop the guessing

            if (numberOfWrongTriesLeft != 0)
            {
                Console.WriteLine("You have won the game. Congratz.");
            }
            else
            {
                Console.WriteLine("Aah you lost from the best. Gallows for u");
            }

            Console.WriteLine("Thank you for playing Hangman");

        }
    }
}
