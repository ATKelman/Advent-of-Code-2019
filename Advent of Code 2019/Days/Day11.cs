using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
	public class Day11 : IDay
	{
		public string PartOne()
		{
			var intComputerInput = System.IO.File.ReadAllText("Day11.txt").Split(',').Select(x => long.Parse(x)).ToArray();
			var intComputer = new IntComputer(intComputerInput);

			var grid = new Dictionary<(int, int), int>();
			var currentPos = (0, 0);
			var input = 0; // 0 - black tile, 1 - white tile 
			var output = 0;
			var direction = 0;
			intComputer.Inputs.Enqueue(input);

			while(intComputer.RunProgram())
			{
				output = (int)intComputer.Outputs.Dequeue();
				if (!grid.ContainsKey(currentPos))
					grid.Add(currentPos, output);
				else
					grid[currentPos] = output;

				direction = (int)intComputer.Outputs.Dequeue();

				switch (direction)
				{
					case 0:
						currentPos = (currentPos.Item1, currentPos.Item2++);
						break;
					case 1:
						currentPos = (currentPos.Item1++, currentPos.Item2);
						break;
					case 2:
						currentPos = (currentPos.Item1, currentPos.Item2--);
						break;
					case 3:
						currentPos = (currentPos.Item1--, currentPos.Item2);
						break;
				}

				input = grid.ContainsKey(currentPos) ? grid[currentPos] : 0;
				intComputer.Inputs.Enqueue(input);
			}

			var result = grid.Count();
			return $"Day 11 Part 1: {result}.";
		}

		public string PartTwo()
		{
			return $"Day 11 Part 2: ";
		}
	}
}
