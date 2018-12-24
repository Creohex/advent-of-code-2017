using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AmountOfSteps(347991));
            Console.WriteLine(FindNextMatrixValue(347991));
            Console.ReadKey();
        }

        // part 1:
        static int AmountOfSteps(int target)
        {
            int rank = 1;
            while (target >= 4 * rank * rank - 2 * rank + 1)
                rank++;
            return Math.Abs(((target - ((2 * rank - 3) * (2 * rank - 3))) % (2 * rank - 2)) - (rank - 1)) + rank - 1;
        }

        // part 2:
        // (I'm deeply and honestly ashamed of this unfinished, ugly and bugged solution for part 2. But after 
        // too many hours (way more than i would like to admit i spent on it) trying to solve it 
        // without building a spiral and later finding out about OEIS.. kind of makes me want to just forget about it and move on. Sorry!)
        static int FindNextMatrixValue(int target)
        {
            int size = 20, center = size / 2;
            int[][] matrix = new int[size][];
            for (int i = 0; i < matrix.Count(); i++)
                matrix[i] = new int[size];
            matrix[center][center] = 1;

            int n = 1, r = 1, v = 1;
            Point p;
            while (v <= target)
            {
                p = Coords(n, r);
                v = matrix[center + p.X - 1][center + p.Y - 1] + matrix[center + p.X - 1][center + p.Y] + matrix[center + p.X - 1][center + p.Y + 1]
                    + matrix[center + p.X][center + p.Y - 1] + matrix[center + p.X][center + p.Y + 1]
                    + matrix[center + p.X + 1][center + p.Y - 1] + matrix[center + p.X + 1][center + p.Y] + matrix[center + p.X + 1][center + p.Y + 1];
                matrix[center + p.X][center + p.Y] = v;
                n++;
                if (n >= (r * 2 + 1) * (r * 2 + 1)) r++;
            }
            Point resultCoords = Coords(n - 1, r);
            return matrix[center + resultCoords.X][center + resultCoords.Y];
        }

        static Point Coords(int n, int r)
        {
            int x = r, y = 1 - r, diff = r == 1 ? n - 1 : n - (r + 1) * (r + 1);
            while (diff > 0)
            {
                if (x == r && y < r) y++;
                else if (y == r && x > -r) x--;
                else if (x == -r && y > -r) y--;
                else if (y == -r && y < r) x++;
                diff--;
            }
            return new Point() { X = x, Y = y };
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point() { }
        }
    }
}
