using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
	public class Day12 : IDay
	{
		public string PartOne()
		{
			var input = System.IO.File.ReadAllLines("Day12.txt");
			var numbersPattern = new Regex(@"-?\d+");
			var moons = new List<Moon>();
			var steps = 1000;

			foreach (var line in input)
			{
				var values = numbersPattern.Matches(line);
				moons.Add(
					new Moon((int.Parse(values[0].Value), int.Parse(values[1].Value), int.Parse(values[2].Value))));
			}

			for (int i = 0; i < steps; i++)
			{
				foreach (var moon in moons)
				{
					foreach (var moon2 in moons.Where(x => x != moon))
					{
						moon.AdjustVelocity(GetVelocityAdjustment(moon.Position, moon2.Position));
					}
				}

				moons.ForEach(x => x.ApplyVelocity());
			}

			var result = moons.Sum(x => x.CalculateTotalEnergy());
			return $"Day 12 Part 1: {result}";
		}

		private (int x, int y, int z) GetVelocityAdjustment((int x, int y, int z) pos1, (int x, int y, int z) pos2)
		{
			var x = (pos1.x == pos2.x) ? 0 : (pos1.x > pos2.x) ? -1 : 1;
			var y = (pos1.y == pos2.y) ? 0 : (pos1.y > pos2.y) ? -1 : 1;
			var z = (pos1.z == pos2.z) ? 0 : (pos1.z > pos2.z) ? -1 : 1;

			return (x, y, z);
		}

		public string PartTwo()
		{
			var input = System.IO.File.ReadAllLines("Day12.txt");
			var numbersPattern = new Regex(@"-?\d+");
			var moons = new List<Moon>();

			foreach (var line in input)
			{
				var values = numbersPattern.Matches(line);
				moons.Add(
					new Moon((int.Parse(values[0].Value), int.Parse(values[1].Value), int.Parse(values[2].Value))));
			}

			var result = 0;
			return $"Day 12 Part 2: {result}";
		}
	}

	public class Moon
	{
		public (int x, int y, int z) Position { get; set; }
		public (int x, int y, int z) Velocity { get; set; }

		public Moon((int x, int y, int z) startPos)
		{
			Position = startPos;
			Velocity = (0, 0, 0);
		}

		public void AdjustVelocity((int x, int y, int z) vel)
		{
			Velocity = (Velocity.x + vel.x, Velocity.y + vel.y, Velocity.z + vel.z);
		}

		public void ApplyVelocity()
		{
			Position = (Position.x + Velocity.x, Position.y + Velocity.y, Position.z + Velocity.z);
		}

		public int CalculateTotalEnergy()
		{
			return (Math.Abs(Position.x) + Math.Abs(Position.y) + Math.Abs(Position.z)) * (Math.Abs(Velocity.x) + Math.Abs(Velocity.y) + Math.Abs(Velocity.z));
		}
	}
}
