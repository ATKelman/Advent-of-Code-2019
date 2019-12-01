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
            int fuel = File.ReadAllLines("Day01.txt").Select(x => GetFuel(int.Parse(x))).Sum();
            return $"Day 01 Part 1: {fuel}";
        }

        public string PartTwo()
        {
            int fuel = File.ReadAllLines("Day01.txt").Select(x => (int.TryParse(x, out int value) ? GetFuelAndSubFuel(value) : 0)).Sum();
            return $"Day 01 Part 2: {fuel}";
        }

        private int GetFuelAndSubFuel(int value)
        {
            var fuel = GetFuel(value);
            return (fuel > 0) ? (fuel + GetFuelAndSubFuel(fuel)) : 0;
        }

        private int GetFuel(int value)
        {
            return (value / 3) - 2;
        }
    }
}
