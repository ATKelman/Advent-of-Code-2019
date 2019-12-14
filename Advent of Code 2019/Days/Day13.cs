using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day13 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day14.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            var intComputer = new IntComputer(input);

            intComputer.RunProgram();

            var grid = new Dictionary<(long, long), long>();
            while (intComputer.Outputs.Count() > 0)
            {
                var x = intComputer.Outputs.Dequeue();
                var y = intComputer.Outputs.Dequeue();
                var id = intComputer.Outputs.Dequeue();

                if (!grid.ContainsKey((x, y)))
                {
                    grid.Add((x, y), id);
                }
            }

            return $"Day 14 Part 1 {grid.Values.Where(x => x == 2).Count()}.";
        }

        public string PartTwo()
        {
            var input = System.IO.File.ReadAllText("Day14.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            input[0] = 2; // Play for free

            var intComputer = new IntComputer(input);

            intComputer.RunProgram();
            long playerScore = 0;
            var grid = new Dictionary<(long, long), long>();
            while (intComputer.Outputs.Count() > 0)
            {
                var x = intComputer.Outputs.Dequeue();
                var y = intComputer.Outputs.Dequeue();
                var id = intComputer.Outputs.Dequeue();

                if (x == -1 && y == 0)
                {
                    playerScore = id;
                }
                else if (!grid.ContainsKey((x, y)))
                {
                    grid.Add((x, y), id);
                }
                else
                {
                    grid[(x, y)] = id;
                }
            }

            return $"Day 14 Part 2: {playerScore}";
        }
    }
}
