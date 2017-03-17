using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day06
    {
        public void SignalsAndNoise()
        {
            var inputList = File.ReadAllLines(Program.InputDir("Day06.txt")).ToList();
            StringBuilder first = new StringBuilder();
            StringBuilder second = new StringBuilder();

            for (int i = 0; i < inputList[0].Length; i++)
            {
                string current = new string(inputList.Select(s => s[i]).ToArray());
                second.Append(current.GroupBy(g => g).Select(hehe => new { Char = hehe.Key, Count = hehe.Count() }).OrderBy(s => s.Count).Select(ayy => ayy.Char).First());
                first.Append(current.GroupBy(g => g).Select(hehe => new { Char = hehe.Key, Count = hehe.Count() }).OrderByDescending(s => s.Count).Select(ayy => ayy.Char).First());
            }               
            Console.WriteLine(first.ToString() + "\n" + second.ToString());
        }
    }
}
