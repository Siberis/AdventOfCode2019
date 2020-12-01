using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Day3
    {

        public static int Star1(string[] wireA, string[] wireB)
        {
            List<(int x, int y)> wireAParts = GetParts(wireA);
            List<(int x, int y)> wireBParts = GetParts(wireB);
            List<(int x, int y)> intersections = new List<(int, int)>();
            for (int i = 1; i < wireAParts.Count; ++i)
            {
                var a1 = wireAParts[i - 1];
                var a2 = wireAParts[i];
                for (int j = 1; j < wireBParts.Count; ++j)
                {
                    var b1 = wireBParts[j - 1];
                    var b2 = wireBParts[j];
                    if (Math.Sign(b1.y - a1.y) != Math.Sign(b2.y - a1.y) && Math.Sign(a1.x - b1.x) != Math.Sign(a2.x - b1.x))
                    {
                        intersections.Add((b1.x, a1.y));
                    }
                    if (Math.Sign(a1.y - b1.y) != Math.Sign(a2.y - b1.y) && Math.Sign(b1.x - a1.x) != Math.Sign(b2.x - a1.x))
                    {
                        intersections.Add((a1.x, b1.y));
                    }
                }
            }
            return intersections.Where(v => v.x != 0 && v.y != 0).Min(v => Math.Abs(v.x) + Math.Abs(v.y));
        }
        public static int Star2(string[] wireA, string[] wireB)
        {
            List<(int x, int y)> wireAParts = GetParts(wireA);
            List<(int x, int y)> wireBParts = GetParts(wireB);
            List<(int x, int y, int i, int j)> intersections = new List<(int, int, int, int)>();
            for (int i = 1; i < wireAParts.Count; ++i)
            {
                var a1 = wireAParts[i - 1];
                var a2 = wireAParts[i];
                for (int j = 1; j < wireBParts.Count; ++j)
                {
                    var b1 = wireBParts[j - 1];
                    var b2 = wireBParts[j];
                    if (Math.Sign(b1.y - a1.y) != Math.Sign(b2.y - a1.y) && Math.Sign(a1.x - b1.x) != Math.Sign(a2.x - b1.x))
                    {
                        intersections.Add((b1.x, a1.y, i - 1, j - 1));
                    }
                    if (Math.Sign(a1.y - b1.y) != Math.Sign(a2.y - b1.y) && Math.Sign(b1.x - a1.x) != Math.Sign(b2.x - a1.x))
                    {
                        intersections.Add((a1.x, b1.y, i - 1, j - 1));
                    }
                }
            }
            List<int> lengthA = wireA.Select(a => int.Parse(a[1..])).ToList();
            List<int> lengthB = wireB.Select(a => int.Parse(a[1..])).ToList();
            var dists = intersections.Where(v => !(v.i == 0 && v.j == 0)).Select(v =>
                        lengthA.Take(v.i).Sum() + lengthB.Take(v.j).Sum() +
                        Math.Abs(wireAParts[v.i].x - v.x) + Math.Abs(wireAParts[v.i].y - v.y) +
                        Math.Abs(wireBParts[v.j].x - v.x) + Math.Abs(wireBParts[v.j].y - v.y)
            );
            return dists.Min();
        }
        public static List<(int, int)> GetParts(string[] wire)
        {

            List<(int, int)> wireAParts = new List<(int, int)>();
            int currX = 0;
            int currY = 0;
            wireAParts.Add((currX, currY));
            for (int i = 0; i < wire.Length; i++)
            {
                switch (wire[i][0])
                {
                    case 'R':
                        currX += int.Parse(wire[i][1..]);
                        break;
                    case 'L':
                        currX -= int.Parse(wire[i][1..]);
                        break;
                    case 'U':
                        currY += int.Parse(wire[i][1..]);
                        break;
                    case 'D':
                        currY -= int.Parse(wire[i][1..]);
                        break;
                }
                wireAParts.Add((
                    currX,
                    currY
                ));
            }
            return wireAParts;
        }
    }
}
