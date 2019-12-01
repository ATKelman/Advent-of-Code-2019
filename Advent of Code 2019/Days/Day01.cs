using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    class Day01 : IDay
    {
        public string PartOne()
        {
            int fuel = 0;
            File.ReadAllLines("Day01.txt").Select(x => Convert.ToDecimal(x)).ToList().ForEach(x =>
            {
                fuel += (int)(Math.Floor(x / 3) - 2);
            });

            return $"Day 01 Part 1: {fuel}";
        }

        public string PartTwo()
        {
            int fuel = 0;
            File.ReadAllLines("Day01.txt").Select(x => Convert.ToDecimal(x)).ToList().ForEach(x =>
            {
                fuel += GetFuel(x);
            });

            return $"Day 01 Part 2: {fuel}";
        }

        private int GetFuel(decimal value)
        {
            var fuel = Math.Floor(value / 3) - 2;
            return (fuel > 0) ? (int)(fuel + GetFuel(fuel)) : 0;
        }
    }
}
