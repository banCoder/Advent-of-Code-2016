using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day09
    {
        public void ExplosivesInCyberspace()
        {
            string instructions = /*File.ReadAllText(Program.InputDir("Day09.txt"));*/"X(8x2)(3x3)ABCY";
            int count = 0;
            int length = 0;
            while (count < instructions.Length)
            {
                int charCount = instructions.Skip(count).TakeWhile(c => c != '(').Count();
                count += charCount;
                length += charCount;
                string repeat = new string(instructions.Skip(count).TakeWhile(c => c != ')').ToArray());
                repeat += new string(instructions.Skip(count + repeat.Length).Take(1).ToArray());
                count += repeat.Length;
                if (count >= instructions.Length)
                    break;
                int repeatTimes = instructions.Skip(count).Take(int.Parse(repeat.Substring(1).Split('x')[0])).Count();
                int times = int.Parse(repeat.Substring(1).Remove(repeat.Length - 2).Split('x')[1]);
                count += repeatTimes;
                length += repeatTimes * times;
                if (count >= instructions.Length)
                    break;
            }
            Console.WriteLine(length);
            count = 0;
            length = 0;
            Console.WriteLine(countStuff(instructions, count, ref length));
        }
        private int countStuff(string instructions, int count, ref int length)
        {
            if (count > instructions.Length)
                return length;
            int charCount = instructions.Skip(count).TakeWhile(c => c != '(').Count();
            count += charCount;
            length += charCount;
            string sub = instructions.Substring(count);
            string repeat = new string(instructions.Skip(count).TakeWhile(c => c != ')').ToArray());
            repeat += new string(instructions.Skip(count + repeat.Length).Take(1).ToArray());
            count += repeat.Length;
            sub = instructions.Substring(count);
            if (count > instructions.Length)
                return length;
            int repeatTimes = instructions.Skip(count).Take(int.Parse(repeat.Substring(1).Split('x')[0])).Count();
            int times = int.Parse(repeat.Substring(1).Remove(repeat.Length - 2).Split('x')[1]);
            length += repeatTimes * times;
            return times * countStuff(sub.Substring(0, repeatTimes), 0, ref length);
        }
    }
}
