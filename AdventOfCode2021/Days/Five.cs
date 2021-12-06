using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;


namespace AdventOfCode2021
{
    public class Five : IDay
    {
        public string filepath { get; set; }
        private int[][] cords = new int[1000][];
        Dictionary<string, int> cords2;
        public Five() 
        {
            this.filepath = @"Inputs\Test" + this.GetType().Name + ".txt";
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
                else if (Math.Abs(keyValuePair.Key.Key -keyValuePair.Value.Key) == Math.Abs(keyValuePair.Key.Value - keyValuePair.Value.Value))
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

        public string SolvePart1v2()
        {
            string[] lines = File.ReadAllLines(filepath);
            cords2 = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    cords2.Add(i + "," + j, 0);
            List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> keyValuePairs = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
            foreach (string line in lines)
            {
                GetLine(int.Parse(line.Split(",")[0]), int.Parse(line.Split(" -> ")[0].Split(",")[1]), int.Parse(line.Split(" -> ")[1].Split(",")[0]), int.Parse(line.Split(" -> ")[1].Split(",")[1]),false);
            }
            return cords2.Select(s => s).Where(s => s.Value > 1).Count().ToString();
        }

        public string SolvePart2v2()
        {
            string[] lines = File.ReadAllLines(filepath);
            cords2 = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    cords2.Add(i + "," + j, 0);
            List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> keyValuePairs = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
            foreach (string line in lines)
            {
                GetLine(int.Parse(line.Split(",")[0]), int.Parse(line.Split(" -> ")[0].Split(",")[1]), int.Parse(line.Split(" -> ")[1].Split(",")[0]), int.Parse(line.Split(" -> ")[1].Split(",")[1]), true);
            }
            return "Not implemented!";
        }

        public void GetLine(int X1, int Y1, int X2, int Y2,bool incDiagonal) 
        {
            List<string> Line = new List<string>();
            if (X1 == X2)
                for (int i = (Y1 < Y2 ? Y1 : Y2); i <= (Y1 > Y2 ? Y1 : Y2); i++)
                    cords2[X1 + "," + i]++;
            else if (Y1 == Y2)
                for (int i = (X1 < X2 ? X1 : X2); i <= (X1 > X2 ? X1 : X2); i++)
                    cords2[i + "," + Y1]++;
            else if (incDiagonal)
            {
                int X = int.Parse(X1 + "" + Y1);
                int Y = int.Parse(X2 + "" + Y2);
                var s = Math.Abs(X1 - X2);
                var d = Math.Abs(Y1 - Y2);
                for (int i = (X < Y ? X : Y);i<= (X > Y ? X : Y); i +=11)
                    cords2[i.ToString("00")[0]+","+ i.ToString("00")[1]]++;
                //int points = Math.Abs(int.Parse(X1 + "" + Y1)- int.Parse(X2 + "" + Y2))/9;
                //if (int.Parse(string.Concat(X1, Y1)) < int.Parse(string.Concat(X2, Y2)))
                //    X1 = 1;
                //else if (int.Parse(string.Concat(X1,Y1)) > int.Parse(string.Concat(X2,Y2)))
                //    for(int i = 1;i<=points;i++)
                //        cords2[]++;

                    //for (int i = 1; i <= points; i++)
                    //{ 
                    //    cords2[(i*9)+","]++;
                    //}
            }
                //X1 = 8, Y1 = 0
                //X2 = 0, Y2 = 8

        }
    }
}
