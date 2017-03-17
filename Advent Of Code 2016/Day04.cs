using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2016
{
    public class Day04
    {
        public void SecurityThroughObscurity()
        {
            var inputLines = File.ReadAllLines(Program.InputDir("Day04.txt"));

            List<string> reallyEncryptedNames = new List<string>();
            List<string> encryptedNames = new List<string>();
            List<int> sectorIds = new List<int>();
            List<string> checkSums = new List<string>();
            foreach (string line in inputLines)
            {
                reallyEncryptedNames.Add(Regex.Split(line, @"\-[0-9]")[0]);
                encryptedNames.Add(Regex.Split(line, @"\-[0-9]")[0].Replace("-", ""));
                sectorIds.Add(int.Parse(new string(line.Where(c => char.IsNumber(c)).ToArray())));
                checkSums.Add(new string(line.SkipWhile(c => c != '[').Skip(1).TakeWhile(c => char.IsLetter(c)).ToArray()));
            }

            int sectorIdSum = 0;
            for (int i = 0; i < encryptedNames.Count(); i++)
            {
                List<Tuple<char, int>> charCounts = new List<Tuple<char, int>>();
                for (int j = 0; j < encryptedNames[i].Length; j++)
                {
                    if (charCounts.Where(t => t.Item1 == encryptedNames[i][j]).Count() > 0)
                        continue;
                    charCounts.Add(Tuple.Create(encryptedNames[i][j], encryptedNames[i].Count(c => c == encryptedNames[i][j])));
                }
                var sortedNames = charCounts.OrderByDescending(t => t.Item2).ToList();
                for (int cc = 0; cc < checkSums[i].Length; cc++)
                {
                    int max = sortedNames.Max(t => t.Item2);
                    if (sortedNames.Count(c => c.Item2 == max) == 1)
                    {
                        if (sortedNames[0].Item1 != checkSums[i][0])
                            break;
                        sortedNames.RemoveAll(t => t.Item2 == max);
                        checkSums[i] = checkSums[i].Remove(0, 1);
                        cc--;
                    }
                    else
                    {
                        char firstChar = sortedNames.Where(t => t.Item2 == max).OrderBy(t => (int)t.Item1).First().Item1;
                        if (checkSums[i][0] != firstChar)
                            break;
                        sortedNames.RemoveAll(t => t.Item1 == firstChar);
                        checkSums[i] = checkSums[i].Remove(0, 1);
                        cc--;
                    }
                }
                sectorIdSum = checkSums[i].Length == 0 ? sectorIdSum + sectorIds[i] : sectorIdSum;
            }
            Console.WriteLine(sectorIdSum);
            // part 2
            List<string> decryptedNames = new List<string>();
            for (int i = 0; i < encryptedNames.Count(); i++)
            {
                string decrypted = new string(encryptedNames[i].Select(c => (char)((((c % 96) + (sectorIds[i] % 26)) % 26) + 96)).ToArray());
                decryptedNames.Add(decrypted);
            }
            Console.WriteLine(sectorIds[decryptedNames.IndexOf(decryptedNames.Where(n => n.Contains("north")).First())]);
        }
    }
}
