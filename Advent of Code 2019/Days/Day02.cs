using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_of_Code_2019.Days
{
	public class Day02 : IDay
	{
		public string PartOne()
		{
			var input = File.ReadAllText("Day02.txt").Split(',').Select(x => int.Parse(x)).ToArray();

			input[1] = 12;
			input[2] = 2;

			return $"Day 2 Part 1: {GetResult(input).ToString()}";
		}

		public string PartTwo()
		{
			var input = File.ReadAllText("Day02.txt").Split(',').Select(x => int.Parse(x)).ToArray();

			for (int noun = 0; noun <= 99; noun++)
			{
				for (int verb = 0; verb <= 99; verb++)
				{
					int[] values = new int[input.Length];
					input.CopyTo(values, 0);

					values[1] = noun;
					values[2] = verb;

					if (GetResult(values) == 19690720)
					{
						return $"Day 2 Part 2: {(100 * noun + verb)}";
					}
				}
			}

			return "Day 2 Part 2: No Result found";
		}

		private int GetResult(int[] values)
		{
			var op = 0;
			while (values[op] != 99)
			{
				var opcode = values[op];
				var a = values[values[op + 1]];
				var b = values[values[op + 2]];
				var c = values[op + 3];

				switch (opcode)
				{
					case 1:
						values[c] = a + b;
						break;
					case 2:
						values[c] = a * b;
						break;
					default:
						throw new Exception($"Unknown Opcode Encountered: {opcode}.");
				}

				op += 4;
			}

			return values[0];
		}
	}
}
