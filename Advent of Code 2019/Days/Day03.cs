using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
	public class Day03 : IDay
	{
		public string PartOne()
		{
			var input = System.IO.File.ReadAllLines("Day03.txt").ToArray();
			var wire1 = GetPath(input[0]);
			var wire2 = GetPath(input[1]);

			var result = wire1.Keys.Intersect(wire2.Keys)
				.Where(x => x.Item1 != 0 && x.Item2 != 0)
				.Min(x => ManhattanDistance(x.Item1, x.Item2)); // Minimum Manhattan Distance

			return $"Day 03 Part 1: {result}";
		}

		public string PartTwo()
		{
			var input = System.IO.File.ReadAllLines("Day03.txt").ToArray();
			var wire1 = GetPath(input[0]);
			var wire2 = GetPath(input[1]);

			var result = wire1.Keys.Intersect(wire2.Keys)
				.Where(x => x.Item1 != 0 && x.Item2 != 0)
				.Min(x => wire1[x] + wire2[x] + 2); // Minimum amount of steps + 2 for 0,0

			return $"Day 03 Part 2: {result}";
		}

		private Dictionary<(int, int), int> GetPath(string inputs)
		{
			var path = new Dictionary<(int, int), int>();
			var coordinates = (0, 0);
			var steps = 0;

			foreach (var input in inputs.Split(','))
			{
				var direction = (0, 0);
				switch (input[0]) // Direction
				{
					case 'R':
						direction = (1, 0);
						break;
					case 'L':
						direction = (-1, 0);
						break;
					case 'U':
						direction = (0, 1);
						break;
					case 'D':
						direction = (0, -1);
						break;
				}

				for (int i = 0; i < int.Parse(input.Substring(1)); i++)
				{
					coordinates = AddTuples(direction, coordinates);
					AddToDictionary(path, coordinates, ++steps);
				}
			}

			return path;
		}

		private (int, int) AddTuples((int, int) direction, (int, int) value)
		{
			return (direction.Item1 + value.Item1, direction.Item2 + value.Item2);
		}

		private void AddToDictionary(Dictionary<(int, int), int> path, (int, int) key, int value)
		{
			try
			{
				path.Add(key, value);
			}
			catch { }
		}

		private int ManhattanDistance(int x, int y)
		{
			return Math.Abs(x) + Math.Abs(y);
		}
	}
}
