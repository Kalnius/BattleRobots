using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleRobots
{
    internal class BattleChooser
    {
        public static BattlePlan SelectBattlePlan(string directory)
        {
            var battlePlans = GetBattlePlans(directory);

            for (var i = 0; i < battlePlans.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + battlePlans[i]);
            }

            var userChoice = GetUserChoice(battlePlans);
            var battlePlan = File.ReadLines(directory + "/" + battlePlans[userChoice]).ToArray();

            return new BattlePlan(battlePlan);
        }

        private static List<string> GetBattlePlans(string directory)
        {
            return Directory.GetFiles(directory, "*.txt")
                                    .Select(Path.GetFileName)
                                    .ToList();
        }

        private static int GetUserChoice(List<string> battlePlans)
        {
            int input;
            do
            {
                Console.WriteLine("Choose a battle plan using a number");
            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input) || battlePlans.ElementAtOrDefault(input - 1) == null);
            return input - 1;
        }
    }
}