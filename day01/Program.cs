using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SolveCaptcha(File.ReadAllText("Input.txt")));
            Console.WriteLine(SolveHardCaptcha(File.ReadAllText("Input2.txt")));
            Console.ReadKey();
        }

        // part 1:
        static int SolveCaptcha(string s)
        {
            s = s[s.Length - 1] + s;
            return s.Skip(1).Select((_, i) => _ == s[i] ? (int)Char.GetNumericValue(_) : 0).Sum();
        }

        // part 2:
        static int SolveHardCaptcha(string s)
        {
            return s.Select((_, i) => _ == s[(i + s.Length / 2) % s.Length] ? (int)Char.GetNumericValue(_) : 0).Sum();
        }
    }
}
