using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day02
    {
        public void BathroomSecurity()
        {
            var inputLines = File.ReadAllLines(Program.InputDir("Day02.txt"));
            List<List<int>> keypad = new List<List<int>>();
            //keypad.Add(new List<int>() { 7, 8, 9 });
            //keypad.Add(new List<int>() { 4, 5, 6 });
            //keypad.Add(new List<int>() { 1, 2, 3 });
            keypad.Add(new List<int>() { 0, 0, 68, 0, 0 });
            keypad.Add(new List<int>() { 0, 65, 66, 67, 0 });            
            keypad.Add(new List<int>() { 5, 6, 7, 8, 9 });
            keypad.Add(new List<int>() { 0, 2, 3, 4, 0 });
            keypad.Add(new List<int>() { 0, 0, 1, 0, 0 });
            int[] coordinate = new int[] { 2, 0 };
            int[] previous = new int[] { 2, 0 };
            StringBuilder sb = new StringBuilder();
            string directions = "URDL";

            foreach (string line in inputLines)
            {
                foreach (char c in line)
                {
                    int pos = directions.IndexOf(c) < 2 ? 1 : -1;
                    int side = (directions.IndexOf(c) + 1) % 2 == 0 ? 1 : 0;
                    coordinate[side] += pos;
                    coordinate[0] = coordinate[0] > keypad.Count() - 1 ? keypad.Count() - 1 : coordinate[0];
                    coordinate[0] = coordinate[0] < 0 ? 0 : coordinate[0];

                    coordinate[1] = coordinate[1] > keypad[coordinate[0]].LastIndexOf(keypad[coordinate[0]].Last(k => k > 0)) ? previous[1] : coordinate[1];
                    coordinate[1] = coordinate[1] < keypad[coordinate[0]].IndexOf(keypad[coordinate[0]].First(k => k > 0)) ? previous[1] : coordinate[1];

                    if (keypad[coordinate[0]][coordinate[1]] == 0)
                        coordinate[0] = previous[0];

                    previous[0] = coordinate[0];
                    previous[1] = coordinate[1];
                }
                if (keypad[coordinate[0]][coordinate[1]] < 10)
                    sb.Append(keypad[coordinate[0]][coordinate[1]]);
                else
                    sb.Append((char)(keypad[coordinate[0]][coordinate[1]]));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
