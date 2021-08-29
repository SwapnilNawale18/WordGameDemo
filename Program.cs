using System;
using System.Collections;

namespace WordGameDemo
{
    class WrodPuzzleGame
    {
        bool SubCharCheck(string subStr)
        {
            string mainStr = "MASTER";
            char[] mainChar = mainStr.ToCharArray();
            char[] subChar = subStr.ToCharArray();
            int i, j, m = mainChar.Length, n = subChar.Length;
            if (mainStr == subStr)
                return false;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (subChar[i] == mainChar[j])
                        break;
                }
                if (j == m)
                    return false;
            }
            return true;
        }
        internal void WordGame(string[] words)
        {
            int score = 0;
            string enteredString;
            string[] wordsArr = words;
            ArrayList possibleList = new ArrayList();
            ArrayList enteredList = new ArrayList();
            String resp;
            foreach (string s in wordsArr)
            {
                possibleList.Add(s);
            }
            do
            {
                Console.Write("Enter possible word: ");
                enteredString = Console.ReadLine();
                if (enteredString == "QUIT")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Your Final score is: " + score);
                    break;
                }
                else if (enteredString == "RESTART")
                {
                    Console.WriteLine("--------------------------------------------------------------------");
                    possibleList.AddRange(enteredList);
                    enteredList.Clear();
                    score = 0;
                }
                else if (possibleList.Contains(enteredString))
                {
                    enteredList.Add(enteredString);
                    possibleList.Remove(enteredString);
                    Console.WriteLine("Correct\tScore: " + ++score);
                }
                else if (enteredList.Contains(enteredString))
                {
                    Console.WriteLine("You have already entered the word " + enteredString);
                }
                else if (SubCharCheck(enteredString))
                {
                    Console.WriteLine("Entered word Contans all charecters from MASTER");
                    Console.WriteLine("Would you like to add this to the list? ");
                    Console.WriteLine("Press Y or y to add new string");
                    resp = Console.ReadLine();
                    if (resp == "Yes" || resp == "yes" || resp == "Y" || resp == "y")
                    {
                        enteredList.Add(enteredString);
                        Console.WriteLine("Congo new word added \tScore: " + (score += 2));
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            } while (true);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Thank You");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArr = new string[] { "ARE", "ARM", "ART", "ATE", "EAR", "EAT", "ERA", "MET", "RAT", "SEA", "SET", "TEA", "ARMS", "ARTS", "EARS", "EAST", "MARS", "MART", "MATE", "MEAT", "META", "RATE", "RATS", "REST", "SAME", "SEAT", "STAR", "STEM", "TEAM", "TEAR", "TERM", "ARMET", "SMART", "SMEAR", "STARE", "STEAM" };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tWelcome to the game of WORD PUZZLE");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\tCreate words of three or more letter from the word MASTER");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("\tInstructions:");
            Console.WriteLine("\ti. Please enter the word in upper case");
            Console.WriteLine("\tii. Every correct word will add 1 point to your score");
            Console.WriteLine("\tiii. In order to quit from game, type 'QUIT'");
            Console.WriteLine("\tiv. In order to restart the game, type 'RESTART'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("--------------------------------------------------------------------");
            new WrodPuzzleGame().WordGame(wordsArr);
        }
    }
}