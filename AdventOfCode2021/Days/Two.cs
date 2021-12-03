using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021
{
    class Two : IDay
    {
        public string filepath { get; set; }

        public Two() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            string[] actions = File.ReadAllLines(filepath);
            int depth = 0;
            int horizontal = 0;

            foreach (string action in actions)
            {
                switch (action.Split(" ")[0]) 
                {
                    case "forward":
                        horizontal += int.Parse(action.Split(" ")[1]);
                        break;
                    case "down":
                        depth += int.Parse(action.Split(" ")[1]);
                        break;
                    case "up":
                        depth -= int.Parse(action.Split(" ")[1]);
                        break;
                }
            }
            return (horizontal*depth).ToString();
        }
        public string SolvePart2()
        {
            string[] actions = File.ReadAllLines(filepath);
            int depth = 0;
            int horizontal = 0;
            int aim = 0;

            foreach (string action in actions)
            {
                switch (action.Split(" ")[0])
                {
                    case "forward":
                        horizontal += int.Parse(action.Split(" ")[1]);
                        depth += aim * int.Parse(action.Split(" ")[1]);
                        break;
                    case "down":
                        aim += int.Parse(action.Split(" ")[1]);
                        break;
                    case "up":
                        aim -= int.Parse(action.Split(" ")[1]);
                        break;
                }
            }
            return (horizontal * depth).ToString();
        }
    }
}
