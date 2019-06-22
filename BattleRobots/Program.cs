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
        }
    }
}
