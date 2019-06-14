using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class RemoveDups : IEqualityComparer<IList<int>>
    {
        const int _multiplier = 89;

        public bool Equals(IList<int> x, IList<int> y)
        {
            return (x[0] == y[0] && x[1] == y[1] && x[2] == y[2] );
            
        }

        public int GetHashCode(IList<int> obj)
        {
            int result = 0;

            if (obj == null)
            {
                return 0;
            }

            var let1 = obj[0];          
            var let2 = obj[1]; 
            var let3 = obj[2]; 

            int part1 = let1 + 3;
            result = (_multiplier * part1) + let2 + let3;
            return result;
        }
    }

    public class ThreeSum
    {
        public IList<IList<int>> CalculateThreeSum(int[] nums) 
        {
            Array.Sort(nums);
            var result = new HashSet<IList<int>>(new RemoveDups());

            for(int i = 0 ; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var k = nums.Length - 1;

                while(j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if(sum == 0)
                    {
                        if(!result.Contains(new List<int>{nums[i], nums[j], nums[k]}))
                        {
                            result.Add(new List<int>{nums[i], nums[j], nums[k]});
                        }
                        j++;
                        k--;
                    }
                    else if(sum < 0)
                        j++;
                    else
                        k--;
                }
            }

            return result.ToList();
        }
    }
}