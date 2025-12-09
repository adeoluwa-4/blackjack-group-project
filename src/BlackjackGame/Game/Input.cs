using System;

namespace BlackjackGame.Game
{
    /// <summary>
    /// User input helpers with validation loops.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Reads a non-empty string from the user.
        /// </summary>
        public static string ReadNonEmpty(string prompt)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Reads an integer within a specified range.
        /// </summary>
        public static int ReadIntInRange(string prompt, int min, int max)
        {
            int value;
            bool valid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                valid = int.TryParse(input, out value) && value >= min && value <= max;

                if (!valid)
                {
                    Console.WriteLine($"Please enter a valid number between {min} and {max}.");
                }

            } while (!valid);

            return value;
        }

        /// <summary>
        /// Reads a Yes/No response from the user.
        /// </summary>
        public static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (y/n): ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                if (input == "y" || input == "yes")
                    return true;

                if (input == "n" || input == "no")
                    return false;

                Console.WriteLine("Please enter 'y' or 'n'.");
            }
        }

        /// <summary>
        /// Displays a message and waits for Enter key.
        /// </summary>
        public static void Wait(string message = "Press ENTER to continue...")
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
