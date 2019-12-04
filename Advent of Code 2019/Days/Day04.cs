using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019.Days
{
	public class Day04 : IDay
	{
		public string PartOne()
		{
			var result = 0;
			for (int i = 130254; i <= 678275; i++)
			{
				if (MeetsCriteria(i))
				{
					result++;
				}
			}
			return $"Day 4 Part 1: {result}";
		}

		private bool MeetsCriteria(int value)
		{
			var values = new List<int>();
			var matches = 0;
			var containsDouble = false;
			for (int i = 0; i < 6; i++)
			{
				var temp = (int)(value / (Math.Pow(10, (6 - i - 1))) % 10);
				values.Add(temp);
				if (values.Count() > 1)
				{
					if (values[i - 1] > values[i])
						return false;

					if (values[i - 1] == values[i])
					{
						matches++;
						containsDouble = true;
					}
					else
						matches = 0;
				}
			}

			return containsDouble;
		}

		public string PartTwo()
		{
			var result = 0;
			for (int i = 130254; i <= 678275; i++)
			{
				if (MeetsCriteria2(i))
				{
					result++;
				}
			}
			return $"Day 4 Part 2: {result}";
		}

		private bool MeetsCriteria2(int value)
		{
			var values = new List<int>();
			var matches = 0;
			var containsDouble = false;
			for (int i = 0; i < 6; i++)
			{
				var temp = (int)(value / (Math.Pow(10, (6 - i - 1))) % 10);
				values.Add(temp);
				if (values.Count() > 1)
				{
					if (values[i - 1] > values[i])
						return false;

					if (values[i - 1] == values[i])
					{
						matches++;						
					}
					else
					{
						containsDouble = (matches == 1) ? true : containsDouble;
						matches = 0;
					}
				}
			}

			return (containsDouble || matches == 1);
		}
	}
}
