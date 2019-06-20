using System.IO;

namespace BattleRobots
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var battlePlansDir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "/BattlePlans";
            var selectedBattlePlan = BattleChooser.SelectBattlePlan(battlePlansDir);

            BattleController.StartBattle(selectedBattlePlan);
        }
    }
}
