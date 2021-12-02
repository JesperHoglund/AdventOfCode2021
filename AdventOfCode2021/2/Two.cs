using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021._2
{
    class Two
    {
        public string SolvePart1()
        {
            string[] actions = System.IO.File.ReadAllLines(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\2\Input.txt");
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
            string[] actions = System.IO.File.ReadAllLines(@"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\2\Input.txt");
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
