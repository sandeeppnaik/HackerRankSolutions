using System;

namespace Hackerrank
{
    public class MaximumProductSubArray
    {
        public int MaxProduct(int[] nums) 
        {
            if(nums.Length == 0)
                return 0;

            // return recursiveMUltiple(nums, 0, int.MinValue);

            var prevMin = nums[0];
            var prevMax = nums[0];
            var currentMax = nums[0];
            var currentMin = nums[0];
            var Max = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                currentMax = Math.Max( Math.Max(prevMin * nums[i], prevMax * nums[i]), nums[i]);
                currentMin = Math.Min( Math.Min(prevMax * nums[i], prevMin * nums[i]), nums[i]);

                Max = Math.Max(Max, currentMax);
                prevMax = currentMax;
                prevMin = currentMin;
            }

            return Max;
        }

        // private int recursiveMUltiple(int[] nums, int start, int largest)
        // {
        //     var currentMultiple = 1;
        //     for(int i = start; i < nums.Length; i++)
        //     {
        //         currentMultiple = nums[i] * currentMultiple;
        //         largest = Math.Max(largest, currentMultiple);
        //         var isLargestInSubarray = recursiveMUltiple(nums, i+1, largest);
        //         largest = Math.Max(largest, isLargestInSubarray);
        //     }
        //     return largest;
        // }
    }
}