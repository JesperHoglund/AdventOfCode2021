using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public interface IDay
    {
        string filepath { get; set; }
        string basepath { get => @"C:\Users\Jesper\source\repos\AdventOfCode2021\AdventOfCode2021\"; }
        string filename { get => @"\Input.txt"; }
        public string SolvePart1();
        public string SolvePart2();
        public string SolvePart1v2();
        public string SolvePart2v2();
    }
}
