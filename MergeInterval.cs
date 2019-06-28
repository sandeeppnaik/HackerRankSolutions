using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class MergeInterval
    {
        public int[][] Merge(int[][] intervals)
        {
            Stack<int[]> lookup = new Stack<int[]>();

            foreach (var interval in intervals.OrderBy(u => u[0]))
            {
                if (lookup.Count != 0 && interval[0] <= lookup.Peek()[1])
                {
                    var elementToUpdate = lookup.Pop();
                    elementToUpdate[1] = interval[1] > elementToUpdate[1] ?
                                            interval[1] : elementToUpdate[1];

                    lookup.Push(elementToUpdate);
                }
                else
                {
                    lookup.Push(interval);
                }
            }

            return lookup.ToArray().OrderBy(u => u[0]).ToArray();
        }
    }
}