﻿using Advent_of_Code_2019.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				var Day = new Day15();
				Console.WriteLine(Day.PartOne());
				Console.WriteLine(Day.PartTwo());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

            Console.ReadLine();
        }
    }
}
