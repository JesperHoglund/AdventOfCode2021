using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021
{
    class Template : IDay
    {
        public string filepath { get; set; }
        public Template() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            string[] lines = File.ReadAllLines(filepath);
            

            return "";
        }
        public string SolvePart2()
        {
            string[] lines = File.ReadAllLines(filepath);
            


            return "";
        }
    }
}
