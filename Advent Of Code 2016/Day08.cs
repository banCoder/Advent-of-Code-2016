using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_2016
{
    public class Day08
    {
        public void TwoFactorAuthentication()
        {
            string[] instructions = File.ReadAllLines(Program.InputDir("Day08.txt"));
            int[,] screen = new int[6, 50];
            foreach (var line in instructions)
            {
                if (line.StartsWith("rect"))
                    rect(int.Parse((line.Split(' ')[1]).Split('x')[0]), int.Parse((line.Split(' ')[1]).Split('x')[1]), ref screen);
                else if (line.StartsWith("rotate c"))
                    column(int.Parse((line.Split(' ')[2]).Split('=')[1]), int.Parse(line.Split(' ')[4]), ref screen);
                else
                    row(int.Parse((line.Split(' ')[2]).Split('=')[1]), int.Parse(line.Split(' ')[4]), ref screen);
            }
            int count = 0;
            foreach (var pixel in screen)
                count = pixel == 1 ? count + 1 : count;
            Console.WriteLine(count);
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                    if (screen[i, j] == 1)
                        Console.Write('X');
                    else
                        Console.Write(' ');
                Console.WriteLine();
            }
        }
        private void rect(int a, int b, ref int[,] screen)
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                    screen[i, j] = 1;
            }
        }
        private void column(int x, int a, ref int[,] screen)
        {
            int[,] screenBefore = new int[screen.GetLength(0), screen.GetLength(1)];
            Array.Copy(screen, screenBefore, screen.Length);
            for (int i = screen.GetLength(0) - 1; i >= 0; i--)
            {
                int after = i - a;
                if (after > screen.GetLength(0) - 1)
                    after -= screen.GetLength(0);
                else if (after < 0)
                    after += screen.GetLength(0);
                screen[i, x] = screenBefore[after, x];
            }
        }
        private void row(int y, int a, ref int[,] screen)
        {
            int[,] screenBefore = new int[screen.GetLength(0), screen.GetLength(1)];
            Array.Copy(screen, screenBefore, screen.Length);
            for (int i = screen.GetLength(1) - 1; i >= 0; i--)
            {
                int after = i - a;
                if (after > screen.GetLength(1) - 1)
                    after -= screen.GetLength(1);
                else if (after < 0)
                    after += screen.GetLength(1);
                screen[y, i] = screenBefore[y, after];
            }
        }
    }
}
