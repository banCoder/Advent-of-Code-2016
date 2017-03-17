using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day10
    {
        public void BalanceBots()
        {
            List<string> instructions = File.ReadAllLines(Program.InputDir("Day10.txt")).ToList();
            int numberOfBots = 0;
            foreach (var item in instructions.Where(s => s.StartsWith("bot ")))
            {
                int current = int.Parse(new string(item.Skip(4).TakeWhile(c => char.IsDigit(c)).ToArray()));
                numberOfBots = numberOfBots > current ? numberOfBots : current;
            }
            int[,] bots = new int[numberOfBots + 1, 2];
            int[,] outputs = new int[numberOfBots + 1, 2];
            var assignments = instructions.Where(s => s.StartsWith("value ")).ToList();
            for (int i = 0; i < assignments.Count(); i++)
            {
                var nums = Regex.Matches(assignments[i], @"[0-9]+");
                int pos = bots[int.Parse(nums[1].Value), 0] == 0 ? 0 : 1;
                bots[int.Parse(nums[1].Value), pos] = int.Parse(nums[0].Value);
                instructions.Remove(instructions.Where(s => s.StartsWith("value " + int.Parse(nums[0].Value) + " goes to bot " + int.Parse(nums[1].Value))).First());
            }
            while (instructions.Count() > 0)
            {
                for (int i = 0; i < bots.GetLength(0); i++)
                {
                    if (bots[i, 0] > 0 && bots[i, 1] > 0)
                        giveMicrochip(i, bots[i, 0], bots[i, 1], ref bots, ref instructions, ref outputs);
                }
            }
            Console.WriteLine("Bot responsible for handling 61 and 17 is ");
        }
        private void giveMicrochip(int botNumber, int value1, int value2, ref int[,] bots, ref List<string> isntructions, ref int[,] outputs)
        {
            var botInstructions = isntructions.Where(s => s.StartsWith("bot " + botNumber + " gives"));
            for (int i = 0; i < botInstructions.Count(); i++)
            {
                var line = botInstructions.ToList()[i];
                int lowBotNum = int.Parse(Regex.Matches(line, @"[0-9]+")[1].Value);
                int highBotNum = int.Parse(Regex.Matches(line, @"[0-9]+")[2].Value);
                int lower = value1 < value2 ? value1 : value2;
                int higher = value1 > value2 ? value1 : value2;
                int pos = bots[lowBotNum, 0] == 0 ? 0 : 1;
                if (line.Split(' ')[5] == "bot")
                    bots[lowBotNum, pos] = lower;
                else
                    outputs[lowBotNum, pos] = lower;
                pos = bots[highBotNum, 0] == 0 ? 0 : 1;
                if (line.Split(' ')[10] == "bot")
                    bots[highBotNum, pos] = higher;
                else
                    outputs[highBotNum, pos] = higher;
                string hehe = botInstructions.First();
                isntructions.Remove(hehe);
            }
        }
    }
}
