using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Assessment2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("How many dice would you like to roll?");
            int userInput = 0;
            string Answer;
            string folder = @"C:\Users\102392424\OneDrive - Swinburne University\Prog\AT2\AT2\";
            string filename = "DiceRolls.txt";
            string fullpath = folder + filename;
            string[] empty = { };
            while (true)
            {
                userInput = int.Parse(Console.ReadLine());
                var x = userInput;
                List<int> Dice = new List<int>();
                Random random = new Random();
                for (int i = 0; i < x; i++)
                {
                    Dice.Add(random.Next(1, 6));
                }
                List<string> DiceRolls = Dice.Select(i => i.ToString()).ToList();
                File.AppendAllLines(fullpath, DiceRolls);
                string[] linesarray = File.ReadAllLines(filename);
                int[] Rolls = Array.ConvertAll(linesarray, int.Parse);
                RollList(Rolls);
                Console.WriteLine($"total: {GetTotal(Rolls)}");
                Console.WriteLine($"average: {GetAverage(Rolls)}");
                Console.WriteLine("Would you like to roll again? (Y/N)");
                Answer = Console.ReadLine();
                string a = Answer.ToUpper();
                if (a == "Y" || a == "YES")
                {
                    Console.WriteLine("How many dice would you like to roll?");
                }
                else if (a == "N" || a == "NO")
                {
                    File.WriteAllLines(fullpath, empty);
                    break;
                }
            }
        }
        public static int GetTotal(int[] Rolls)
        {
            int Total = 0;
            for (int i = 0; i < Rolls.Length; i++)
            {
                Total += Rolls[i];
            }
            return Total;
        }
        public static decimal GetAverage(int[] Rolls)
        {
            int sum = GetTotal(Rolls);
            decimal average = (decimal)sum / Rolls.Length;
            return average;
        }
        public static void RollList(int[] Rolls)
        {
            Console.WriteLine("------");
            Console.WriteLine($" Amount of Rolls = {Rolls.Count()}");
            Console.WriteLine("------");
            foreach(int roll in Rolls)
            {
                Console.WriteLine(roll);
            }
        }
    }
}