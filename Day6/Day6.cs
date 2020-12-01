using System;
using System.Linq;
using System.Collections.Generic;

namespace Day6
{
    public class Day6
    {

        public static int Star1(string[] inputSource)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach (var line in inputSource)
            {
                var orb = line.Split(")");
                if (!graph.ContainsKey(orb[0]))
                {
                    graph.Add(orb[0], new List<string>());
                }
                graph[orb[0]].Add(orb[1]);
            }
            Dictionary<string, int> distance = new Dictionary<string, int>();
            Queue<string> visited = new Queue<string>();
            distance.Add("COM", 0);
            visited.Enqueue("COM");
            while (visited.Count > 0)
            {
                var x = visited.Dequeue();
                if (!graph.ContainsKey(x)) continue;
                var near = graph[x];
                var dist = distance[x];
                foreach (var n in near)
                {
                    visited.Enqueue(n);
                    distance.Add(n, dist + 1);
                }
            }
            return distance.Sum(e => e.Value);
        }
        public static int Star2(string[] inputSource, string start, string end)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            var target = end;
            var source = start;
            foreach (var line in inputSource)
            {
                var orb = line.Split(")");
                if (!graph.ContainsKey(orb[0]))
                {
                    graph.Add(orb[0], new List<string>());
                }
                if (!graph.ContainsKey(orb[1]))
                {
                    graph.Add(orb[1], new List<string>());
                }
                graph[orb[0]].Add(orb[1]);
                graph[orb[1]].Add(orb[0]);
                if (orb[1] == end)
                {
                    target = orb[0];
                }
                if (orb[1] == start)
                {
                    source = orb[0];
                }

            }
            Dictionary<string, int> distance = new Dictionary<string, int>();
            Queue<string> visited = new Queue<string>();
            distance.Add(source, 0);
            visited.Enqueue(source);
            while (visited.Count > 0)
            {
                var x = visited.Dequeue();
                if (!graph.ContainsKey(x)) continue;
                var near = graph[x];
                var dist = distance[x];
                foreach (var n in near)
                {
                    if (!distance.ContainsKey(n))
                    {
                        visited.Enqueue(n);
                        distance.Add(n, dist + 1);
                    }
                }
            }
            return distance[target];
        }
    }
}
