using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2016
{
    public class Day01
    {
        public void NoTimeFortaxicab()
        {
            string input = File.ReadAllText(Program.InputDir("Day01.txt"));
            string[] subInput = Regex.Split(input, @", ");
            int[] coordinates = new int[] { 0, 0 };
            int steps = 4;
            int orientation = 4;
            bool alreadyVisited = false;
            List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
            foreach (var s in subInput)
            {
                if (s.StartsWith("R"))
                    orientation++;
                else
                    orientation--;
                orientation %= 4;
                steps = int.Parse(new string(s.Skip(1).ToArray()));
                int side = (orientation + 2) % 2 == 0 ? 1 : 0;
                int pos = orientation > 1 ? -1 : 1;
                for (int i = 1; i <= steps; i++)
                {
                    coordinates[side] += pos;
                    //if (locations.Any(t => t.Item1 == coordinates[0] && t.Item2 == coordinates[1]))
                    //{
                    //    alreadyVisited = true;
                    //    break;
                    //}
                    //else
                    //    locations.Add(Tuple.Create(coordinates[0], coordinates[1]));
                }
                if (alreadyVisited)
                    break;
                orientation += 4;
            }
            Console.WriteLine(Math.Abs(coordinates[0]) + Math.Abs(coordinates[1]));
        }
    }
}
