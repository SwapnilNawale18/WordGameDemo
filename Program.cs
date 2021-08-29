using System;
using System.Collections;

namespace WordGameDemo
{
    class WrodPuzzleGame
    {
        internal bool SubCharCheck(string subchar)
        {
            char[] mainChar = new char[] { 'M', 'A', 'S', 'T', 'E', 'R' };
            char[] subChar = subchar.ToCharArray();
            int i, j, m = mainChar.Length, n = subChar.Length;
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
        internal void WordGame()
        {
            int score = 0;
            string enteredString;
            string[] wordsArr = new string[] { "ARE", "ARM", "ART", "ATE", "EAR", "EAT", "ERA", "MET", "RAT", "SEA", "SET", "TEA", "ARMS", "ARTS", "EARS", "EAST", "MARS", "MART", "MATE", "MEAT", "META", "RATE", "RATS", "REST", "SAME", "SEAT", "STAR", "STEM", "TEAM", "TEAR", "TERM", "ARMET", "SMART", "SMEAR", "STARE", "STEAM" };
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
                    Console.WriteLine("Your Final score is: " + score);
                    break;
                }
                else if (enteredString == "RESTART")
                {
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
            Console.WriteLine("Thank You");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the game of WORD PUZZLE");
            Console.WriteLine("\ti. Please enter the word in upper case");
            Console.WriteLine("\tii. Every correct word will add 1 point to your score");
            Console.WriteLine("\tiii. In order to quit from game, type 'QUIT'");
            Console.WriteLine("Create words of three or more letters from word MASTER");
            new WrodPuzzleGame().WordGame();
        }
    }
}