using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace AdventOfCode2021
{
    public class Four : IDay
    {
        public string filepath { get; set; }
        public Four() 
        {
            this.filepath = @"Inputs\" + this.GetType().Name + ".txt";
        }

        public string SolvePart1()
        {
            string[] lines = File.ReadAllLines(filepath);
            int[] numbers = lines[0].Split(",").Select(s => int.Parse(s)).ToArray();
            List < List<List<KeyValuePair<int,bool>>> > boards = new List<List<List<KeyValuePair<int, bool>>>>();
            for (int i = 2; i < lines.Length; i++)
            {
                List<List<KeyValuePair<int, bool>>> board = new List<List<KeyValuePair<int, bool>>>();
                while (true)
                {
                    if (lines[i].Split(" ").Where(s => s.Length > 0).ToArray().Length < 4)
                    {
                        break;
                    }

                    board.Add(lines[i].Split(" ").Where(s => s.Length > 0).Select(s => new KeyValuePair<int, bool>(int.Parse(s),false)).ToList());
                    i++;
                    if (i >= lines.Length)
                        break;
                }
                boards.Add(board);
                if (i >= lines.Length)
                    break;
            }

            foreach (int number in numbers)
                for (int i = 0; i < boards.Count(); i++)
                    for (int j = 0; j < boards[i].Count(); j++)
                        for (int k = 0; k < boards[i][j].Count(); k++)
                        {
                            if (boards[i][j][k].Key == number)
                            {
                                boards[i][j][k] = new KeyValuePair<int, bool>(number, true);
                                if (boards[i][j][0].Value == true && boards[i][j][1].Value == true && boards[i][j][2].Value == true
                                        && boards[i][j][3].Value == true && boards[i][j][4].Value == true)
                                {
                                    int unmarked = 0;
                                    foreach (List<KeyValuePair<int, bool>> b_line in boards[i])
                                        foreach (KeyValuePair<int, bool> b_kvp in b_line)
                                            if (b_kvp.Value == false)
                                                unmarked += b_kvp.Key;
                                    return (unmarked * number).ToString();
                                }
                                        
                                
                                if (boards[i][0][k].Value == true && boards[i][1][k].Value == true && boards[i][2][k].Value == true
                                        && boards[i][3][k].Value == true && boards[i][4][k].Value == true)
                                {
                                    int unmarked = 0;
                                    foreach (List<KeyValuePair<int, bool>> b_line in boards[i])
                                        foreach (KeyValuePair<int, bool> b_kvp in b_line)
                                            if (b_kvp.Value == false)
                                                unmarked += b_kvp.Key;
                                    return (unmarked * number).ToString();
                                }

                            }

                        }
            return "FAILED!";
        }

        public string SolvePart2()
        {
            string[] lines = File.ReadAllLines(filepath);
            int[] numbers = lines[0].Split(",").Select(s => int.Parse(s)).ToArray();
            List<List<List<KeyValuePair<int, bool>>>> boards = new List<List<List<KeyValuePair<int, bool>>>>();
            for (int i = 2; i < lines.Length; i++)
            {
                List<List<KeyValuePair<int, bool>>> board = new List<List<KeyValuePair<int, bool>>>();
                while (true)
                {
                    if (lines[i].Split(" ").Where(s => s.Length > 0).ToArray().Length < 4)
                    {
                        break;
                    }

                    board.Add(lines[i].Split(" ").Where(s => s.Length > 0).Select(s => new KeyValuePair<int, bool>(int.Parse(s), false)).ToList());
                    i++;
                    if (i >= lines.Length)
                        break;
                }
                boards.Add(board);
                if (i >= lines.Length)
                    break;
            }

            foreach (int number in numbers)
            {
                for (int i = 0; i < boards.Count(); i++)
                {
                        for (int j = 0; j < boards[i].Count(); j++)
                        {
                            for (int k = 0; k < boards[i][j].Count(); k++)
                            {
                                if (boards[i][j][k].Key == number)
                                {
                                    boards[i][j][k] = new KeyValuePair<int, bool>(number, true);
                                    if (boards[i][j][0].Value == true && boards[i][j][1].Value == true && boards[i][j][2].Value == true
                                            && boards[i][j][3].Value == true && boards[i][j][4].Value == true)
                                    {
                                    if (boards.Select(s => s).Where(s => s.Count > 0).ToList().Count == 1)
                                    {
                                        int unmarked = 0;
                                        foreach (List<KeyValuePair<int, bool>> b_line in boards.Select(s => s).Where(s => s.Count > 0).Select(s => s).First())
                                            foreach (KeyValuePair<int, bool> b_kvp in b_line)
                                                if (b_kvp.Value == false)
                                                    unmarked += b_kvp.Key;
                                        return (unmarked * number).ToString();
                                    }
                                    boards[i] = new List<List<KeyValuePair<int, bool>>>();
                                        break;
                                    }
                                    else if (boards[i][0][k].Value == true && boards[i][1][k].Value == true && boards[i][2][k].Value == true
                                            && boards[i][3][k].Value == true && boards[i][4][k].Value == true)
                                    {
                                    if (boards.Select(s => s).Where(s => s.Count > 0).ToList().Count == 1)
                                    {
                                        int unmarked = 0;
                                        foreach (List<KeyValuePair<int, bool>> b_line in boards.Select(s => s).Where(s => s != null).Select(s => s).First())
                                            foreach (KeyValuePair<int, bool> b_kvp in b_line)
                                                if (b_kvp.Value == false)
                                                    unmarked += b_kvp.Key;
                                        return (unmarked * number).ToString();
                                    }
                                    boards[i] = new List<List<KeyValuePair<int, bool>>>();
                                        break;
                                    }

                                }
                                
                            }
                           
                        }
                    
                }
            }
            return "FAILED!";
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
