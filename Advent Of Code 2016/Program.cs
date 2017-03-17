using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Day01 day01 = new Day01();
            //day01.NoTimeFortaxicab();

            Day02 day02 = new Day02();
            //day02.BathroomSecurity();

            Day03 day03 = new Day03();
            //day03.SquaresWithThreeSides();

            Day04 day04 = new Day04();
            //day04.SecurityThroughObscurity();

            Day05 day05 = new Day05();
            //day05.HowAboutNiceGameOfChess();

            Day06 day06 = new Day06();
            //day06.SignalsAndNoise();

            Day07 day07 = new Day07();
            //day07.InternetProtocolVersion7();

            Day08 day08 = new Day08();
            //day08.TwoFactorAuthentication();

            Day09 day09 = new Day09();
            //day09.ExplosivesInCyberspace();

            Day10 day10 = new Day10();
            day10.BalanceBots();
            
            Console.ReadLine();
        }
        public static string InputDir(string fileName) => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"/inputs/" + fileName;
    }
}
