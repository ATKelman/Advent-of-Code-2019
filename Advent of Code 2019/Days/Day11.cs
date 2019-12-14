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
			var result = GetPaintedGrid(0).Count();
			return $"Day 11 Part 1: {result}.";
		}

		public string PartTwo()
		{
            var grid = GetPaintedGrid(1);

            for (int y = grid.Keys.Max(i => i.Item2); y >= grid.Keys.Min(i => i.Item2); y--)  
            {
                var line = "";
                for (int x = grid.Keys.Min(i => i.Item1); x <= grid.Keys.Max(i => i.Item1); x++)
                {
                    if (grid.ContainsKey((x, y)))
                    {
                        if (grid[(x, y)] == 1) line += "#";
                        else line += " ";
                    }
                    else line += " ";
                }
                Console.WriteLine(line);
            }

            return $"Day 11 Part 2: See Console Above.";
		}

        private Dictionary<(int, int), int> GetPaintedGrid(int firstTile)
        {
            var intComputerInput = System.IO.File.ReadAllText("Day11.txt").Split(',').Select(x => long.Parse(x)).ToArray();
            var intComputer = new IntComputer(intComputerInput);

            var grid = new Dictionary<(int, int), int>();
            var currentPos = (0, 0);
            var input = firstTile; // 0 - black tile, 1 - white tile 
            var output = 0;
            var direction = 0;
            intComputer.Inputs.Enqueue(input);

            while (intComputer.RunProgram())
            {
                output = (int)intComputer.Outputs.Dequeue();
                if (!grid.ContainsKey(currentPos))
                    grid.Add(currentPos, output);
                else
                    grid[currentPos] = output;

                var outputDirection = (int)intComputer.Outputs.Dequeue();

                direction = (outputDirection == 0) ? direction - 1 : direction + 1; // 0 - turn left, 1 - turn right 
                direction = (direction + 4) % 4;

                switch (direction)
                {
                    case 0:
                        currentPos = (currentPos.Item1, currentPos.Item2 + 1);
                        break;
                    case 1:
                        currentPos = (currentPos.Item1 + 1, currentPos.Item2);
                        break;
                    case 2:
                        currentPos = (currentPos.Item1, currentPos.Item2 - 1);
                        break;
                    case 3:
                        currentPos = (currentPos.Item1 - 1, currentPos.Item2);
                        break;
                }

                input = grid.ContainsKey(currentPos) ? grid[currentPos] : 0;
                intComputer.Inputs.Enqueue(input);
            }

            return grid;
        }
	}
}
