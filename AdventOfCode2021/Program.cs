﻿using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> days = new List<object>();
            days.Add(new One());
            days.Add(new Two());
            days.Add(new Three());

            foreach (IDay day in days) 
            {
                Console.WriteLine("---------------Day "+day.GetType().Name+"--------------");
                Console.WriteLine("Part One: " + day.SolvePart1());
                Console.WriteLine("Part Two: " + day.SolvePart2());
                Console.WriteLine();
            }
        }
    }
}

