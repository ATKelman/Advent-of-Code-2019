using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
    public class Day06 : IDay
    {
        public string PartOne()
        {
            var orbits = GetOrbits();
            var result = orbits.Sum(x => x.Value.indirect.Count);
            return $"Day 6 Part 1: {result}";
        }

        public string PartTwo()
        {
            var orbits = GetOrbits();

            var firstIntersect = orbits["YOU"].indirect.Intersect(orbits["SAN"].indirect).First();
            var result = orbits["YOU"].indirect.IndexOf(firstIntersect) + orbits["SAN"].indirect.IndexOf(firstIntersect) - 2; 

            return $"Day 6 Part 2: {result}";
        }

        private Dictionary<string, (string direct, List<string> indirect)> GetOrbits()
        {
            var orbits = new Dictionary<string, (string direct, List<string> indirect)>();

            System.IO.File.ReadAllLines("Day06.txt").Select(x => x.Split(')')).ToList().ForEach(x =>
            {
                orbits.Add(x[1], (x[0], new List<string>()));
            });

            foreach (var orbit in orbits.Keys)
            {
                var indirects = orbits[orbit].indirect;
                for (string instance = orbit; orbits.ContainsKey(instance); instance = orbits[instance].direct)
                {
                    indirects.Add(instance);
                }
            }

            return orbits;
        }
    }
}
