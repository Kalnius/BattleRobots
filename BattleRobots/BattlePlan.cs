using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRobots
{
    public class BattlePlan
    {
        public Point BattleArenaBoundaries { get; set; }
        public List<Robot> Robots { get; set; }

        public BattlePlan(string[] battlePlan)
        {
            var bounds = battlePlan[0].Split(' ');
            BattleArenaBoundaries = new Point(int.Parse(bounds[0]), int.Parse(bounds[1]));
            Robots = new List<Robot>();

            var skip = 1;
            while (battlePlan.Skip(skip).Take(2).Count() != 0)
            {
                var robotData = battlePlan.Skip(skip).Take(2).ToArray();
                Robots.Add(new Robot(robotData));
                skip += 2;
            }
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