using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> r = new Dictionary<string, int>();
            int max = 0;
            foreach (string s in File.ReadAllLines("Input.txt"))
            {
                string[] c = Regex.Split(s, @"\s");
                if (!r.Keys.Contains(c[0]))
                    r.Add(c[0], 0);
                if (!r.Keys.Contains(c[4]))
                    r.Add(c[4], 0);
                if (Evaluate(r[c[4]] + " " + (c[5] == "==" || c[5] == "!=" ? "=" : c[5]) + " " + c[6]) ^ c[5][0] == '!')
                {
                    r[c[0]] += ((c[1] == "inc" ? 1 : -1) * int.Parse(c[2]));
                    max = Math.Max(r[c[0]], max);
                }
            }
            Console.WriteLine(r.Values.Max());  // part 1
            Console.WriteLine(max);             // part 2
            Console.ReadKey();
        }

        public static bool Evaluate(string exp)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("exp", string.Empty.GetType(), exp);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return Boolean.Parse((string)row["exp"]);
        }
    }
}
