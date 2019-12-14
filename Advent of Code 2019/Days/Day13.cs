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
            var input = System.IO.File.ReadAllText("Day13.txt").Split(',').Select(x => long.Parse(x)).ToArray();
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
            var input = System.IO.File.ReadAllText("Day13.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            input[0] = 2; // Play for free

            var intComputer = new IntComputer(input);
            var grid = new Dictionary<(long, long), long>();
            while (intComputer.RunProgram())
            {
                ProcessOutputs(ref grid, ref intComputer);

                var ball = grid.Where(x => x.Value == 4).SingleOrDefault();
                var paddle = grid.Where(x => x.Value == 3).SingleOrDefault();

                if (ball.Key.Item1 > paddle.Key.Item1)
                    intComputer.Inputs.Enqueue(1);
                else if (ball.Key.Item1 < paddle.Key.Item1)
                    intComputer.Inputs.Enqueue(-1);
                else
                    intComputer.Inputs.Enqueue(0);
            }

            ProcessOutputs(ref grid, ref intComputer);

            var value = grid[(-1, 0)];
            return $"Day 14 Part 2: {value}";
        }

        private void ProcessOutputs(ref Dictionary<(long, long), long> grid, ref IntComputer intComputer)
        {
            while (intComputer.Outputs.Count() > 0)
            {
                var x = intComputer.Outputs.Dequeue();
                var y = intComputer.Outputs.Dequeue();
                var id = intComputer.Outputs.Dequeue();

                if (!grid.ContainsKey((x, y)))
                {
                    grid.Add((x, y), id);
                }
                else
                {
                    grid[(x, y)] = id;
                }
            }
        }
    }
}
