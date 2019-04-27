using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class Town
    {
        public int Id { get; set; }
        public List<Tuple<int,int>> Connections { get; set; } = new List<Tuple<int,int>>();
        public bool HasMachine { get; set; }
        public Town(int id)
        {
            Id = id;
        }
    }

    public static class Machines
    {
        public static int minTime(int[][] roads, int[] machines)
        {
            List<Town> cityList = new List<Town>();

            for (int i = 0; i < roads.Length + 1; i++)
            {
                var t = new Town(i);
                if (Array.IndexOf(machines, i) != -1)
                {
                    t.HasMachine = true;
                }

                cityList.Add(new Town(i));
            }

            foreach (var road in roads)
            {
                var source = road[0];
                var destination = road[1];
                var cost = road[2];
                cityList[source].Connections.Add(Tuple.Create(destination,cost));
                cityList[destination].Connections.Add(Tuple.Create(source,cost));
            }

            int minCost = 0;
            for (int m1 = 0; m1 < machines.Length; m1++)
            {
                for (int m2 = m1 + 1; m2 < machines.Length; m2++)
                {
                    minCost += CalculateCheapestRoad(machines[m1], machines[m2], ref cityList);
                }
            }

            return minCost;
        }

        static int CalculateCheapestRoad(int source, int destination, ref List<Town> cities)
        {
            var minCost = 0;
            var linksource = 0;
            var linkDest = 0;
            var bfs = new Queue<Tuple<int,int>>();
            bfs.Enqueue(new Tuple<int,int>(source,int.MaxValue));
            var currentMinRoadCost = int.MaxValue;
            while (bfs.Count() != 0)
            {
                var tuple = bfs.Dequeue();
                var pathfrom = tuple.Item1;

                var sourceTownConnections = cities[pathfrom].Connections;

                currentMinRoadCost = Math.Min(tuple.Item2, currentMinRoadCost);
                if(currentMinRoadCost >= tuple.Item2)
                {
                    currentMinRoadCost = tuple.Item2;
                    linksource = tuple.Item1;
                }

                foreach (var connection in sourceTownConnections)
                {
                    if(connection.Item1 == destination)
                    {
                        minCost =  Math.Min(currentMinRoadCost,connection.Item2);
                        return minCost;
                    }
                    bfs.Enqueue(new Tuple<int,int>(connection.Item1, connection.Item2));                    
                }
            }

            return minCost; 
        }
    }

}
