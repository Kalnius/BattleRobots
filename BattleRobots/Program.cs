using System;
using System.IO;
using System.Linq;

namespace BattleRobots
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var battlePlanFile = File.ReadLines(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "/BattlePlan.txt").ToArray();
            var battlePlan = new BattlePlan(battlePlanFile);

            battlePlan.Execute();

            for (var i = 0; i < battlePlan.Robots.Count; i++)
            {
                var robot = battlePlan.Robots[i];
                Console.WriteLine($"Robot's No. {i+1} coordinates are (x = {robot.Position.X}, y = {robot.Position.Y}), direction is {robot.Direction}");
            }
            Console.ReadKey();
        }
    }
}
