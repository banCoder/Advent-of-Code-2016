using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent_Of_Code_2016
{
    public class Day05
    {
        public void HowAboutNiceGameOfChess()
        {
            MD5 md5 = MD5.Create();
            char[] password = new char[8];
            string target = "00000";
            int append = 0;
            int complete = 0;
            while (complete < 8)
            {
                StringBuilder hashBuilder = new StringBuilder();
                byte[] inputBytes = Encoding.ASCII.GetBytes("reyedfim" + append);
                byte[] hash = md5.ComputeHash(inputBytes);
                for (int i = 0; i < 4; i++)
                {
                    string h = hash[i].ToString("X2");
                    hashBuilder.Append(h);
                    if (hashBuilder.ToString().Substring(0, Math.Min(5, hashBuilder.Length)) != target.Substring(0, Math.Min(5, hashBuilder.Length)))
                        break;
                    if (hashBuilder.Length == 8 && hashBuilder.ToString().Substring(0, 5) == target /*&& char.IsDigit(hashBuilder[5].ToString().ToCharArray()[0]) && int.Parse(hashBuilder[5].ToString()) < 8 && password[int.Parse(hashBuilder[5].ToString())] == '\0'*/)
                    {
                        //password[int.Parse(hashBuilder[5].ToString())] = hashBuilder[6];
                        password[complete] = hashBuilder[5];
                        complete++;
                    }                        
                }
                append++;
            }
            Console.WriteLine(new string(password));
        }
    }
}
