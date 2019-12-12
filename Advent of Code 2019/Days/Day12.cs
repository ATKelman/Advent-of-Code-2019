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
					new Moon(
						new int[3]
						{
							int.Parse(values[0].Value),
							int.Parse(values[1].Value),
							int.Parse(values[2].Value)
						}
						));
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

		private int[] GetVelocityAdjustment(int[] pos1, int[] pos2)
		{
			var adjustment = new int[pos1.Length];
			for (int i = 0; i < pos1.Length; i++)
			{
				adjustment[i] = (pos1[i] == pos2[i] ? 0 : pos1[i] > pos2[i] ? -1 : 1);
			}

			return adjustment;
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
					new Moon(
						new int[3]
						{
							int.Parse(values[0].Value),
							int.Parse(values[1].Value),
							int.Parse(values[2].Value)
						}
						));
			}

			var result = 0;
			return $"Day 12 Part 2: {result}";
		}
	}

	public class Moon
	{
		public int[] Position { get; set; }
		public int[] Velocity { get; set; }

		public Moon(int[] startPos)
		{
			Position = startPos;
			Velocity = new int[3];
		}

		public void AdjustVelocity(int[] vel)
		{
			if (vel.Length != Velocity.Length)
				throw new Exception($"Error - Velocity adjustment length does not match Velocity length! Velocity Length: {Velocity.Length}, Adjustment Length: {vel.Length}.");

			for (int i = 0; i < vel.Length; i++)
			{
				Velocity[i] += vel[i];
			}
		}

		public void ApplyVelocity()
		{
			for (int i = 0; i < Position.Length; i++)
			{
				Position[i] += Velocity[i];
			}
		}

		public int CalculateTotalEnergy()
		{
			var potentialEnergy = 0;
			foreach (var pos in Position)
				potentialEnergy += Math.Abs(pos);

			var kineticEnergy = 0;
			foreach (var vel in Velocity)
				kineticEnergy += Math.Abs(vel);

			return potentialEnergy * kineticEnergy;
		}
	}
}
