using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public class Subsets
    {
        public IList<IList<int>> CalculateSubsets(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            Recurse(nums, result, new List<int>(), 0);
            return result;
        }
    

        private void Recurse(int[] input, List<IList<int>> result
        , List<int> sublist, int index)
        {
            result.Add(new List<int>(sublist));
            for(int i = index; i < input.Length; i++)
            {
                sublist.Add(input[i]);
                Recurse(input, result, new List<int>(sublist), i + 1);
                sublist.RemoveAt(sublist.Count - 1);
            }
        }
    }
}