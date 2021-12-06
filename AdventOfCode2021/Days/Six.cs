using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace AdventOfCode2021
{
    public class Six : IDay
    {
        public string filepath { get; set; }
        public Six() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            List<int> lanternfish = Array.ConvertAll(File.ReadAllLines(filepath)[0].Split(","), s => int.Parse(s)).ToList();

            for (int i = 0; i < 80; i++)
            {
                lanternfish = lanternfish.Select(s => { s--; return s; }).ToList();
                lanternfish.Select(s => s).Where(s => s == -1).ToList().ForEach(s => { lanternfish.Add(8); });
                for (int j = 0; j < lanternfish.Count; j++)
                    if (lanternfish[j] == -1)
                        lanternfish[j] = 6;
            }

            return lanternfish.Count().ToString();
        }
        public string SolvePart2()
        {
            List<long> lines = Array.ConvertAll(File.ReadAllLines(filepath)[0].Split(","), s => long.Parse(s)).ToList();
            long[] lanternfish = new long[9];
            for (int i = 0; i < 9; i++)
            {
                lanternfish[i] = lines.Select(s=>s).Count(s=> s==i);
            }

            for (int i = 0; i < 256; i++)
            {
                long newfishes = lanternfish[0];
                lanternfish[0] = lanternfish[1];
                lanternfish[1] = lanternfish[2];
                lanternfish[2] = lanternfish[3];
                lanternfish[3] = lanternfish[4];
                lanternfish[4] = lanternfish[5];
                lanternfish[5] = lanternfish[6];
                lanternfish[6] = lanternfish[7] + newfishes; 
                lanternfish[7] = lanternfish[8];
                lanternfish[8] = newfishes;
            }
            return lanternfish.Select(s => s).Sum(s => s).ToString();
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
