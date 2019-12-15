using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day15 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day13.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            var intComputer = new IntComputer(input);

            (int, int) currentPos = (0, 0);
            (int, int) previousPos = currentPos;
            (int, int)[] directions = new (int, int)[]
            {
                (0, 1), 
                (1, 0), 
                (0, -1),
                (-1, 0)
            }; // array pos + 1 
            var grid = new Dictionary<(int x, int y), int>();

            // Give input
            // while not oxygen found 
            // while int computer 
            while (true)
            {
                var index = 0;
                if (grid.ContainsKey(AddTuple2(currentPos, directions[index])) || directions[index] == previousPos)
                    index++;

                intComputer.RunProgram();
            }

            return $"Day 15 Part 1:";
        }

        private (int, int) AddTuple2((int, int) first, (int, int) second)
        {
            return (first.Item1 + second.Item1, first.Item2 + second.Item2);
        }

        private int GetNextDirection(int index)
        {

        }

        public string PartTwo()
        {
            return $"Day 15 Part 2:";
        }
    }
}
