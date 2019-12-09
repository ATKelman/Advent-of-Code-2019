using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day08 : IDay
    {
        public string PartOne()
        {
            var input = System.IO.File.ReadAllText("Day08.txt");
            var imageSize = (25 * 6);
            var layers = Enumerable.Range(0, (input.Count() / imageSize))
                .Select(x => input.Substring(x * imageSize, imageSize)).ToList();

            var lowestCountLayer = layers.OrderBy(x => x.Count(y => y == '0')).First();
            var result = lowestCountLayer.Count(x => x == '1') * lowestCountLayer.Count(x => x == '2');
            return $"Day 8 Part 1: {result}";
        }

        public string PartTwo()
        {
            /* 0 - Black, 1 - White, 2 - Transparent */
            var input = System.IO.File.ReadAllText("Day08.txt");
            var imageSize = (25 * 6);
            var layers = Enumerable.Range(0, (input.Count() / imageSize))
                .Select(x => input.Substring(x * imageSize, imageSize)).ToList();

            /* Originally used multiple nested for-loops, cleaned using 1 nested Enumerable.Range
             * Method learned from:
             * https://github.com/viceroypenguin/adventofcode/blob/master/2019/day08.original.cs
             */
            var result = Enumerable.Range(0, imageSize)
                .Select(x => Enumerable.Range(0, layers.Count)
                    .Select(y => layers[y][x])
                    .Aggregate('2', (v, w) => v != '2' ? v : w == '0' ? ' ' : w)).Batch(25);

            foreach (var line in result.Select(x => string.Join("", x)))
                Console.WriteLine(line);

            return $"Day 8 Part 2 Above.";
        }
    }
}
