using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> days = new List<object>();
            days.Add(new _1.One(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\1\Input.txt"));
            days.Add(new _2.Two(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\2\Input.txt"));


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
