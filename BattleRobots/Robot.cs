namespace BattleRobots
{
    public class Robot
    {
        public Point StartingPoint { get; set; }
        public string StartingDirection { get; set; }
        public string Instructions { get; set; }

        public Robot(string[] robotData)
        {
            var startingPosition = robotData[0].Split(' ');
            StartingPoint = new Point(int.Parse(startingPosition[0]), int.Parse(startingPosition[1]));
            StartingDirection = startingPosition[2];

            Instructions = robotData[1];
        }
    }
}