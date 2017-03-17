using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    class Day03
    {
        public void SquaresWithThreeSides()
        {
            string[] inputLines = File.ReadAllLines(Program.InputDir("Day03.txt"));
            int impossible = 0;
            List<List<int>> allLines = new List<List<int>>();
            foreach (string line in inputLines)
                allLines.Add(Regex.Split(line, "  ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => int.Parse(s)).ToList());
            for (int i = 0; i < allLines.Count() - 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (allLines[i][j] + allLines[i + 1][j] <= allLines[i + 2][j] || allLines[i][j] + allLines[i + 2][j] <= allLines[i + 1][j] || allLines[i + 2][j] + allLines[i + 1][j] <= allLines[i][j])
                        impossible++;
                }
                i += 2;
            }
            Console.WriteLine(inputLines.Length - impossible);
        }
    }
}
