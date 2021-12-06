using System;
using System.Collections.Generic;
using AdventOfCode2021;

namespace ConsoleForOutput
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

            foreach (IDay day in days)
            {
                Console.WriteLine("---------------Day " + day.GetType().Name + "--------------");
                Console.WriteLine("Part One: " + day.SolvePart1());
                Console.WriteLine("Part Two: " + day.SolvePart2());
                Console.WriteLine();
            }
        }
    }
}
