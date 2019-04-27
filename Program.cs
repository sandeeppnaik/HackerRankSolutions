using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hackerrank
{
    class Node
    {
        public int Value { get; set; }
        public long Color { get; set; }
        public List<int> ConnectedNodes { get; set; }
        public Node(int value, long color)
        {
            Value = value;
            Color = color;
            ConnectedNodes = new List<int>();
        }
    }

    class Program
    {

        static int FindShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, int val)
        {
            var listOfNodes = new Node[graphNodes + 1];
            for (int i = 1; i <= graphNodes; i++)
            {
                listOfNodes[i] = new Node(i, ids[i - 1]);
            }

            for (int i = 0; i < graphFrom.Length; i++)
            {
                var source = graphFrom[i];
                var dest = graphTo[i];
                var sourceNode = listOfNodes[source];
                sourceNode.ConnectedNodes.Add(dest);

                //Maintain bi - directional Link.
                var destNode = listOfNodes[dest];
                destNode.ConnectedNodes.Add(source);
            }

            int minimumLength = int.MaxValue;
            long start = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == val)
                {
                    start = ids[i]; // this is because the list of nodes starts from position 1.
                    var len = CalculateBFS(start, listOfNodes, val);
                    minimumLength = Math.Min(len, minimumLength);
                }
            }

            if (start == 0)
                return -1;

            return minimumLength;
        }

        static int CalculateBFS(long start, Node[] nodes, int color)
        {
            var queue = new Queue<Node>();
            var visitedNodes = new bool[nodes.Length];
            queue.Enqueue(nodes[start]);

            var minLength = 0;
            while (queue.Count > 0)
            {
                var itemsAtAlevel = queue.Count();

                minLength++;
                while (itemsAtAlevel > 0)
                {
                    var node = queue.Dequeue();
                    visitedNodes[node.Value] = true;

                    for (int i = 0; i < node.ConnectedNodes.Count; i++)
                    {
                        var currentNodeId = node.ConnectedNodes[i];
                        if (visitedNodes[currentNodeId])
                        {
                            continue;
                        }
                        else if (nodes[currentNodeId].Color == color)
                        {
                            return minLength;
                        }
                        else
                        {
                            queue.Enqueue(nodes[currentNodeId]);
                        }
                    }
                    itemsAtAlevel--;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            #region FindShortestInput
            const int graphNodes = 4;
            var graphFrom = new int[3] { 1, 1, 4 };
            var graphTo = new int[3] { 2, 3, 2 };
            var graphColor = new long[graphNodes] { 1, 2, 3, 4 };
            var toFind = 2;

            // var result =  FindShortest(graphNodes,graphFrom,graphTo,graphColor,toFind);
            #endregion

            #region RoadConstruction
            const int numberofCities = 3;
            var c_lib = 2;
            var c_road = 1;
            var cityConnections = new int[numberofCities][];
            cityConnections[0] = new int[] { 1, 2 };
            cityConnections[1] = new int[] { 3, 1 };
            cityConnections[2] = new int[] { 2, 3 };

            var s = RoadsLibraries.RoadsAndLibraries(numberofCities, c_lib, c_road, cityConnections);
            #endregion

            #region Machines
            // var roads = new int [4][];
            // roads[0] = new int[]{2,1,8};
            // roads[1] = new int[]{1,0,5};
            // roads[2] = new int[]{2,4,5};
            // roads[3] = new int[]{1,3,4};

            // var machines = new int[]{0,2,4};
            // var cost = Machines.minTime(roads,machines);
            #endregion

            #region Kruskal
            int gNodes = 4;

            List<int> gFrom = new List<int>(){1,1,4,2,3,3};
            List<int> gTo = new List<int>(){2,3,1,4,2,4};
            List<int> gWeight = new List<int>(){5,3,6,7,4,5};

            var minimumSpanningCost = KruscalImplementation.Kruskals(gNodes,gFrom,gTo,gWeight);
            #endregion
        }
    }
}