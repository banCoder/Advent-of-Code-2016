using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day07
    {
        public void InternetProtocolVersion7()
        {
            int countTLS = 0;
            int countSSL = 0;
            string[] inputLines = File.ReadAllLines(Program.InputDir("Day07.txt"));
            foreach (var line in inputLines)
            {
                countTLS = isTLS(line) ? countTLS + 1 : countTLS;
                countSSL = isSSL(line) ? countSSL + 1 : countSSL;
            }                
            Console.WriteLine(countTLS + "\n" + countSSL);
        }
        private bool isAbba(string input)
        {
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (input[i] == input[i + 3] && input[i + 1] == input[i + 2] && input[i] != input[i + 1])
                    return true;
            }
            return false;
        }
        private bool isTLS(string line)
        {
            var bracketMatches = Regex.Matches(line, @"\[[a-z]+\]");
            foreach (Match m in bracketMatches)
            {
                if (isAbba(m.Value))
                    return false;
            }
            var split = Regex.Split(line, @"\[[a-z]+\]");
            foreach (var match in split)
            {
                if (isAbba(match))
                    return true;
            }
            return false;
        }
        private bool isSSL(string line)
        {
            var split = Regex.Split(line, @"\[[a-z]+\]");
            var abaListed = abaList(split);
            var bracketMatches = Regex.Matches(line, @"\[[a-z]+\]");
            foreach (Match m in bracketMatches)
            {
                if (abaListed.Where(l => m.Value.Contains(new string(new char[] { l[1], l[0], l[1] }))).Count() > 0)
                    return true;
            }
            return false;
        }
        private List<string> abaList(string[] input)
        {
            List<string> list = new List<string>();
            foreach (var listItem in input)
            {
                for (int i = 0; i < listItem.Length - 2; i++)
                {
                    if (listItem[i] == listItem[i + 2] && listItem[i] != listItem[i + 1])
                        list.Add(listItem.Substring(i, 3));
                }
            }            
            return list;
        }
    }
}
