namespace BattleRobots
{
    public class Arena
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public bool PointIsInArena(Point point)
        {
            return point.X > Start.X &&
                   point.X < End.X &&
                   point.Y > Start.Y &&
                   point.Y < End.Y;
        }
    }

    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
