using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day09 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day09.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            var intComputer = new IntComputer(input);

            intComputer.Inputs.Enqueue(1);
            intComputer.RunProgram();
            var result = intComputer.Outputs.Dequeue();

            return $"Day 9 Part 1: {result}";
        }

        public string PartTwo()
        {
            var input = System.IO.File.ReadAllText("Day09.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            var intComputer = new IntComputer(input);

            intComputer.Inputs.Enqueue(2);
            intComputer.RunProgram();
            var result = intComputer.Outputs.Dequeue();

            return $"Day 9 Part 2: {result}";
        }
    }
}
