using System;
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
            days.Add(new Four());
            days.Add(new Five());
            days.Add(new Six());
            days.Add(new Seven());

            foreach (IDay day in days) 
            {
                Console.WriteLine("---------------Day "+day.GetType().Name+"--------------");
                Console.WriteLine("Part One: " + day.SolvePart1());
                Console.WriteLine("Part One v2: " + day.SolvePart1v2());
                Console.WriteLine("Part Two: " + day.SolvePart2());
                Console.WriteLine("Part Two v2: " + day.SolvePart2v2());
                Console.WriteLine();
            }
        }
    }
}

