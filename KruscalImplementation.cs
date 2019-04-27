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
            if(Find(grp,source,dest) || Find(grp, dest, source))
                return 0;
            else
            {
                Join(ref grp, source, dest);
            }
            return cost;
        }

        private static void Join(ref DisjointSets grp, int source, int dest)
        {
            if(grp.Rank[source] > grp.Rank[dest])
            {
                grp.Connections[dest] = source;
            }
            else if(grp.Rank[source] < grp.Rank[dest])
            {
                grp.Connections[source] = dest;
            }
            else
            {
                grp.Connections[source] = dest;
                grp.Rank[dest]++;
            }
        }

        private static bool Find(DisjointSets grp, int source, int dest)
        {
            if(grp.Connections[source] == grp.Connections[dest])
            {
                return true;
            }
            else if(grp.Connections[source] == source)
            {   
                return false;
            }
            else if(grp.Connections[source] == dest)
                return true;
            else
            {
                return Find(grp, grp.Connections[source], dest);
            }
        }
    }
}