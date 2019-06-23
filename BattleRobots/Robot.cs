using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRobots
{
    public class Robot
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
        public Command[] Instructions { get; set; }
        private Arena Arena { get; set; }

        public Robot(Direction direction, Point position, Command[] instructions, Arena arena)
        {
            //robot should know arena boundaries
            Arena = arena;

            if (Arena.PointIsInArena(position))
                Position = position;
            Direction = direction;
            Instructions = instructions;
        }

        public void CarryOutInstructions()
        {
            foreach (var instruction in Instructions)
            {
                if (instruction is Command.L || instruction is Command.R)
                    Turn(instruction);
                else if (!WillHitWall())
                    Move();
            }
        }

        private void Move()
        {
            if (Direction is Direction.N)
                Position.Y++;
            if (Direction is Direction.E)
                Position.X++;
            if (Direction is Direction.S)
                Position.Y--;
            if (Direction is Direction.W)
                Position.X--;
        }

        private void Turn(Command instruction)
        {
            if (instruction is Command.L)
                if (Direction is Direction.N)
                    Direction = Direction.W;
                else Direction--;
            else if (instruction is Command.R)
                if (Direction is Direction.W)
                    Direction = Direction.N; 
                else Direction++;
        }

        private bool WillHitWall()
        {
            return Direction is Direction.N && Position.Y == Arena.End.Y ||
                Direction is Direction.E && Position.X == Arena.End.X ||
                Direction is Direction.S && Position.Y == Arena.Start.Y ||
                Direction is Direction.W && Position.X == Arena.Start.X;
        }
    }

    public class Position
    {
        public Point Coordinates { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Command
    {
        L,
        R,
        M
    }

    public enum Direction
    {
        N,
        E,
        S,
        W
    }
}