using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hackerrank
{
    public class DisjointSets
    {
        public Dictionary<int,int> Connections { get; set; } = new Dictionary<int, int>();
        public Dictionary<int,int> Rank { get; set; } = new Dictionary<int, int>();
    }

    public static class KruscalImplementation
    {
        public static int Kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {
            int minimumSpanningCost = 0;
            var disjointsets = new DisjointSets();

            for(int i = 1; i  <= gNodes; i++)
            {
                disjointsets.Connections.Add(i,i);
                disjointsets.Rank.Add(i,1);
            }

            var collection = new int[gTo.Count()][];
            for(int i = 0; i < collection.Length; i++)
            {
                collection[i] = new int[3];
                collection[i][0] = gWeight[i];
                collection[i][1] = gTo[i];
                collection[i][2] = gFrom[i];
            }

            var orderredCollection = collection.OrderBy(c => c[0]).ToArray();

            for(int i = 0 ; i < orderredCollection.Length; i++)
            {
                int source = orderredCollection[i][1];
                int dest = orderredCollection[i][2];
                int cost = orderredCollection[i][0];
                minimumSpanningCost += CalculateCost(source, dest, cost, disjointsets);

            }

            return minimumSpanningCost;
        }

        private static int CalculateCost(int source, int dest, int cost, DisjointSets grp )
        {
            if(FindRoot(grp,source) == FindRoot(grp, dest))
                return 0;
            else
            {
                Join(ref grp, source, dest);
            }
            return cost;
        }

        private static void Join(ref DisjointSets grp, int source, int dest)
        {
            var x = FindRoot(grp,source);
            var y = FindRoot(grp,dest);


            if(grp.Rank[x] > grp.Rank[y])
            {
                grp.Connections[y] = x;
            }
            else if(grp.Rank[x] < grp.Rank[y])
            {
                grp.Connections[x] = y;
            }
            else
            {
                grp.Connections[y] = x;
                grp.Rank[x]++;
            }
        }

        private static int FindRoot(DisjointSets grp, int vertex)
        {
            if(grp.Connections[vertex] == vertex)
            {
                return vertex;
            }
            else
            {
                return FindRoot(grp,grp.Connections[vertex]);
            }
        }
    }
}