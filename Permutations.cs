using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
                return result;

            if (nums.Length == 1)
            {
                result.Add(nums);
                return result;
            }

            var temp = new List<Array>();
            temp.Add(new int[] { nums[0] });
            int i = 1;

            while (i < nums.Length)
            {
                var resultArray = new List<Array>();

                foreach (var item in temp)
                {
                    for (int j = 0; j < item.Length; j++)
                    {
                        int len2 = item.Length - j;
                        var first = new int[j+1];
                        var last = new int[len2];
                        Array.Copy(item, 0, first, 0, j);
                        first[j] = nums[i];
                        Array.Copy(item, j, last, 0, len2);

                        var z = new int[first.Length + last.Length];
                        first.CopyTo(z, 0);
                        last.CopyTo(z, first.Length);
                        resultArray.Add(z);
                    }

                    var lastAdder = new int[item.Length + 1];
                    item.CopyTo(lastAdder, 0);
                    lastAdder[item.Length] = nums[i];
                    resultArray.Add(lastAdder);

                }
                i++;
                temp = resultArray;
            }

            foreach(var item in temp)
            {
                result.Add(item.OfType<int>().ToList());
            }

            return result;
        }
    }
}