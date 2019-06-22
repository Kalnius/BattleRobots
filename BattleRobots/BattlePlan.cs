﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRobots
{
    public class BattlePlan
    {
        public Arena Arena { get; set; }
        public List<Robot> Robots { get; set; } = new List<Robot>();

        public BattlePlan(string[] battlePlan)
        {
            CreateArena(battlePlan);
            AddRobots(battlePlan);
        }

        internal void Execute()
        {
            foreach (var robot in Robots)
            {
                robot.CarryOutInstructions();
            }
        }

        private void CreateArena(string[] battlePlan)
        {
            Arena = new Arena();
            var bounds = battlePlan[0].Split(' ');
            Arena.Start = new Point(0, 0);
            Arena.End = new Point(int.Parse(bounds[0]), int.Parse(bounds[1]));
        }

        private void AddRobots(string[] battlePlan)
        {
            var skip = 1;
            string[] nextRobot;

            while ((nextRobot = battlePlan.Skip(skip).Take(2).ToArray()).Any())
            {
                //parse data (assuming file contains CORRECT data format)
                var position = nextRobot[0].Split(' ');
                var direction = (Direction)Enum.Parse(typeof(Direction), position[2]);
                var positionPoint = new Point(int.Parse(position[0]), int.Parse(position[1]));
                var instructions = nextRobot[1].ToArray().Select(c => (Command)Enum.Parse(typeof(Command), c.ToString())).ToArray();

                Robots.Add(new Robot(direction, positionPoint, instructions, Arena));
                skip += 2;
            }
        }
    }

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