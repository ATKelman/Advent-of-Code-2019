using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day05 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day05.txt").Split(',').Select(x => int.Parse(x)).ToArray();
            var result = GetResult(input, 1);

            return $"Day 5 Part 1 : {result}";
        }

        public string PartTwo()
        {
            var input = System.IO.File.ReadAllText("Day05.txt").Split(',').Select(x => int.Parse(x)).ToArray();
            var result = GetResult(input, 5);

            return $"Day 5 Part 2: {result}";
        }

        private int GetResult(int[] values, int input)
        {
            var op = 0;
            var lastEcho = 0;
            while (values[op] != 99)
            {
                var opcode = values[op] % 10;
                var modeA = ((values[op] / 100) % 10);
                var modeB = ((values[op] / 1000) % 10);

                var a = (modeA > 0) ? values[op + 1] : values[values[op + 1]];
                var b = (modeB > 0) ? values[Math.Min((op + 2), (values.Count() - 1))] : values[Math.Min(values[Math.Min((op + 2), (values.Count() - 1))], (values.Count() - 1))];

                switch (opcode)
                {
                    case 1:                                             
                        values[values[op + 3]] = a + b;
                        op += 4;
                        continue;
                    case 2:
                        values[values[op + 3]] = a * b;
                        op += 4;
                        continue;
                    case 3:
                        values[values[op + 1]] = input;
                        op += 2;
                        continue;
                    case 4:
                        lastEcho = values[values[op + 1]];
                        Console.WriteLine(lastEcho);
                        op += 2;
                        continue;
                    case 5:
                        op = (a != 0) ? b : op + 3;
                        continue;
                    case 6:
                        op = (a == 0) ? b : op + 3;
                        continue;
                    case 7:
                        values[values[op + 3]] = (a < b) ? 1 : 0;
                        op += 4;
                        continue;
                    case 8:
                        values[values[op + 3]] = (a == b) ? 1 : 0;
                        op += 4;
                        continue;
                    default:
                        throw new Exception($"Unknown Opcode Encountered: {opcode}.");
                }
            }

            return lastEcho;
        }
    }
}
