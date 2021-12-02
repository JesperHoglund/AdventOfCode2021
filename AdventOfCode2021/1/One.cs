using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2021._1
{
    class One : IDay
    {
        public string filepath { get; set; }

        public One(string filepath) 
        {
            this.filepath = filepath;
        }

        public string SolvePart1()
        {
            int[] numbers = Array.ConvertAll(System.IO.File.ReadAllLines(filepath), s => int.Parse(s));
            int count = 0;

            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] > numbers[i - 1])
                    count++;
            return count.ToString();
        }
        public string SolvePart2()
        {
            int[] numbers = Array.ConvertAll(System.IO.File.ReadAllLines(filepath), s => int.Parse(s));
            int[] sumMeasurements = new int[numbers.Length - 1];
            int count = 0;

            for (int i = 0; i < numbers.Length - 2; i++)
                sumMeasurements[i] = numbers[i] + numbers[i + 1] + numbers[i + 2];
            for (int i = 1; i < sumMeasurements.Length; i++)
                if (sumMeasurements[i] > sumMeasurements[i - 1])
                    count++;
            return count.ToString();
        }


        public string SolvePart1v2()
        {
            int[] numbers = Array.ConvertAll(System.IO.File.ReadAllLines(filepath), s => int.Parse(s));
            return Enumerable.Range(1, numbers.Length - 1).Where(i => numbers[i] > numbers[i - 1]).Count().ToString();

        }
        public string SolvePart2v2()
        {
            int[] numbers = Array.ConvertAll(System.IO.File.ReadAllLines(filepath), s => int.Parse(s));
            int[] sum = Enumerable.Range(0, numbers.Length - 2).Select(i => numbers[i] + numbers[i + 1] + numbers[i + 2]).ToArray();
            return Enumerable.Range(1, sum.Length-1).Where(j => sum[j] > sum[j - 1]).Count().ToString();

        }
    }
}
