using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    interface IDay
    {
        string filepath { get; set; }
        public string SolvePart1();
        public string SolvePart2();
    }
}
