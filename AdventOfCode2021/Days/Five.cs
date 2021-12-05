using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021
{
    class Five : IDay
    {
        public string filepath { get; set; }
        private int[][] cords = new int[1000][];
        List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> diagonal = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
        public Five() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            string[] lines = File.ReadAllLines(filepath);
            
            for (int i = 0; i < cords.Length; i++)
            {
                cords[i] = new int[1000];
                Array.Clear(cords[i], 0, 1000);
            }
            List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> keyValuePairs = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
            foreach (string line in lines)
            {
                keyValuePairs.Add(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(int.Parse(line.Split(",")[0]), int.Parse(line.Split(" -> ")[0].Split(",")[1])), new KeyValuePair<int, int>(int.Parse(line.Split(" -> ")[1].Split(",")[0]), int.Parse(line.Split(" -> ")[1].Split(",")[1]))));
            }
            foreach (KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Key.Key == keyValuePair.Value.Key)
                    setPointsVertical(keyValuePair.Key, keyValuePair.Value);
                else if (keyValuePair.Key.Value == keyValuePair.Value.Value)
                    setPointsHorizontal(keyValuePair.Key,keyValuePair.Value);
            }
            int overlaps = 0;
            for (int i = 0; i < cords.Length; i++)
                for (int j = 0;j< cords[i].Length; j++)
                    if(cords[i][j]>=2)
                        overlaps++;
            return overlaps.ToString();
        }
        public string SolvePart2()
        {
            string[] lines = File.ReadAllLines(filepath);

            for (int i = 0; i < cords.Length; i++)
            {
                cords[i] = new int[1000];
                Array.Clear(cords[i], 0, 1000);
            }
            List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> keyValuePairs = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
            foreach (string line in lines)
            {
                keyValuePairs.Add(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(int.Parse(line.Split(",")[0]), int.Parse(line.Split(" -> ")[0].Split(",")[1])), new KeyValuePair<int, int>(int.Parse(line.Split(" -> ")[1].Split(",")[0]), int.Parse(line.Split(" -> ")[1].Split(",")[1]))));
            }
            foreach (KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Key.Key == keyValuePair.Value.Key)
                    setPointsVertical(keyValuePair.Key, keyValuePair.Value);
                else if (keyValuePair.Key.Value == keyValuePair.Value.Value)
                    setPointsHorizontal(keyValuePair.Key, keyValuePair.Value);
                else //if (Math.Abs(keyValuePair.Key.Key -keyValuePair.Value.Key) == Math.Abs(keyValuePair.Key.Value - keyValuePair.Value.Value))
                    setPointsDiagonal(keyValuePair.Key, keyValuePair.Value);
            }
            int overlaps = 0;
            for (int i = 0; i < cords.Length; i++)
                for (int j = 0; j < cords[i].Length; j++)
                    if (cords[i][j] >= 2)
                        overlaps++;
            return overlaps.ToString();
        }

        private void setPointsHorizontal(KeyValuePair<int, int> leftKvp, KeyValuePair<int, int> rightKvp)
        {
            int i_min, i_max,i_line;
            if (leftKvp.Key < rightKvp.Key)
            {
                i_min = leftKvp.Key;
                i_max = rightKvp.Key;
            } else
            {
                i_max = leftKvp.Key;
                i_min = rightKvp.Key;
            }
            i_line = leftKvp.Value;
            for (int i = i_min; i <= i_max; i++)
            {
                cords[i][i_line] += 1;
            }
        }

        private void setPointsVertical(KeyValuePair<int, int> leftKvp, KeyValuePair<int, int> rightKvp)
        {
            int i_min, i_max, i_line;
            if (leftKvp.Value < rightKvp.Value)
            {
                i_min = leftKvp.Value;
                i_max = rightKvp.Value;
            }
            else
            {
                i_max = leftKvp.Value;
                i_min = rightKvp.Value;
            }
            i_line = leftKvp.Key;
            for (int i = i_min; i <= i_max; i++)
            {
                cords[i_line][i] += 1;
            }
        }
        private void setPointsDiagonal(KeyValuePair<int, int> leftKvp, KeyValuePair<int, int> rightKvp)
        {
            int l_row, l_col, r_row, r_col;
            l_row = leftKvp.Value;
            r_row = rightKvp.Value;
            l_col = leftKvp.Key;
            r_col = rightKvp.Key;
            diagonal.Add(new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(leftKvp, rightKvp));
            if (l_row < r_row) //Go down
            {
                if (l_col < r_col)//go right
                    for (int i = l_col; i <= r_col; i++)
                        for (int j = l_row; j <= r_row; j++)
                        {
                            cords[i][j] += 1;
                            i++;
                            if (i > r_col)
                                break;
                        }
                else //go left

                    for (int i = l_col; i >= r_col; i--)
                        for (int j = l_row; j <= r_row; j++)
                        {
                            cords[i][j] += 1;
                            i--;
                            if (i < r_col)
                                break;
                        }
            }
            else    //go up
            {
                if (l_col < r_col)  //go right
                    for (int i = l_col; i <= r_col; i++)
                        for (int j = l_row; j >= r_row; j--)
                        {
                            cords[i][j] += 1;
                            i++;
                            if (i > r_col)
                                break;
                        }
                else    // go left
                    for (int i = l_col; i >= r_col; i--)
                        for (int j = l_row;j >=r_row;j--)
                        {
                            cords[i][j] += 1;
                            i--;
                            if (i < r_col)
                                break;
                        }
            }

        }

    }
}
