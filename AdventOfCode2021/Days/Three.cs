using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021
{
    public class Three : IDay
    {
        public string filepath { get; set; }
        public Three() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            string[] diagnostic = File.ReadAllLines(filepath);
            string[] rays = new string[diagnostic[0].Length];
            string gamma="";
            string epsilon="";
            for (int i = 0; i < diagnostic[0].Length; i++)
            {
                rays[i] = String.Join("",diagnostic.Select(s => s[i]).ToArray());
            }
            foreach (string ray in rays)
            {
                int one = ray.Select(s => s).Where(s => s.Equals('1')).Count();
                int zero = ray.Select(s => s).Where(s => s.Equals('0')).Count();
                gamma += (one > zero ? '1' : '0');
                epsilon += (one < zero ? '1' : '0');
            }


            return (Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)).ToString();
        }
        public string SolvePart2()
        {
            string[] diagnostic = File.ReadAllLines(filepath);
            string[] w_diagnostic = diagnostic;
            string oxygen="";
            string scrubber="";
            for (int i = 0; i < w_diagnostic[0].Length; i++)
            {
                w_diagnostic = w_diagnostic.Select(s => s).Where(s => s[i].Equals('1')).Count() >= w_diagnostic.Select(s => s).Where(s => s[i].Equals('0')).Count() ? w_diagnostic.Select(s => s).Where(s => s[i].Equals('1')).ToArray() : w_diagnostic.Select(s => s).Where(s => s[i].Equals('0')).ToArray();
                if (w_diagnostic.Length == 2)
                {
                    oxygen = w_diagnostic.Select(s => s).Where(s => s[i + 1].Equals('1')).First();
                    break;
                }
            }
            w_diagnostic = diagnostic;
            for (int i = 0; i < w_diagnostic[0].Length; i++)
            {
                w_diagnostic = w_diagnostic.Select(s => s).Where(s => s[i].Equals('1')).Count() < w_diagnostic.Select(s => s).Where(s => s[i].Equals('0')).Count() ? w_diagnostic.Select(s => s).Where(s => s[i].Equals('1')).ToArray() : w_diagnostic.Select(s => s).Where(s => s[i].Equals('0')).ToArray();
                if (w_diagnostic.Length<= 3)
                {
                    scrubber = w_diagnostic.Select(s => s).Where(s => s[i+1].Equals('0')).First();
                    break;
                }
            }
            return (Convert.ToInt32(oxygen, 2) * Convert.ToInt32(scrubber, 2)).ToString();
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
