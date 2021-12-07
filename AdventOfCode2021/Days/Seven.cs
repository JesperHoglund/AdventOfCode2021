using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021
{
    public class Seven : IDay
    {
        public string filepath { get; set; }
        public Seven() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            List<int> crabs = Array.ConvertAll(File.ReadAllLines(filepath)[0].Split(","), s => int.Parse(s)).ToList();
            int fuel = Int32.MaxValue;
            foreach (int crab in crabs)
                fuel = crabs.Select(s => Math.Abs(s - crab)).Sum() < fuel ? crabs.Select(s => Math.Abs(s - crab)).Sum() : fuel;
            
            return fuel.ToString();
        }
        public string SolvePart2()
        {
            List<int> crabs = Array.ConvertAll(File.ReadAllLines(filepath)[0].Split(","), s => int.Parse(s)).ToList();
            int fuel = Int32.MaxValue;
            for(int i = crabs.Select(s=>s).OrderByDescending(s=>s).Last();i<=crabs.Select(s=>s).OrderByDescending(s=>s).First();i++)
               fuel = crabs.Select(s => calcPerm(Math.Abs(s - i))).Sum() < fuel ? crabs.Select(s => calcPerm(Math.Abs(s - i))).Sum() : fuel;

            return fuel.ToString();
        }
        public int calcPerm(int input) 
        {
            int output=0;
            for (int i = 1; i <= input; i++)
                output += i;
            return output;
        }
        public string SolvePart1v2()
        {
            return "Not implemented";
        }

        public string SolvePart2v2()
        {
            return "Not implemented";
        }
    }
}
