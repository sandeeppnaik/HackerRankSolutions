using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public static class Machines
    {
        public static int minTime(int[][] roads, int[] machines)
        {

            var connections = new Dictionary<int, int>();
            int minCost = 0;

            for (int i = 0; i <= roads.Length; i++)
            {
                connections.Add(i, i);
            }

            var orderedRoads = roads.OrderByDescending(c => c[2]).ToArray();

            for (int i = 0; i < orderedRoads.Length; i++)
            {
                var src = orderedRoads[i][0];
                var dest = orderedRoads[i][1];

                if (DestroyRoad(connections, machines, src, dest))
                {
                    minCost += orderedRoads[i][2];
                }
            }

            return minCost;
        }

        private static bool DestroyRoad(Dictionary<int, int> connections,
        int[] machines,
        int src, int dest)
        {
            if(HasMachines(connections, machines, src) && HasMachines(connections ,machines, dest))
                return true;
            Union(connections, machines, src, dest);
            return false;
        }

        private static bool HasMachines(Dictionary<int, int> connections
        , int[] machines, int src)
        {
            if(machines.Contains(src))
             return true;
            var root = FindRoot(connections,src);
            return machines.Contains(root);
        }

        private static int FindRoot(Dictionary<int, int> connections, int vertex)
        {
            if(connections[vertex] == vertex)
                return vertex;
            
            return FindRoot(connections, connections[vertex]);
        }

        private static void Union(Dictionary<int, int> connections,
            int[] machines,
            int source, int desti)
        {
            var src = FindRoot(connections,source);
            var dest = FindRoot(connections, desti);

            if (machines.Contains(src))
            {
                connections[dest] = src;
            }
            else if (machines.Contains(dest))
            {
                connections[src] = dest;
            }
            else
            {
                connections[dest] = src;
            }
        }

    }

}
