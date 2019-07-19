using System;

namespace Hackerrank
{
    public class PeakElement
    {
        public int FindPeakElement(int[] nums) 
        {
            if(nums.Length == 0 || nums.Length == 1)
                return 0;

            var left = 0;
            var right = nums.Length - 1;

            while(left < right)
            {
                var mid = ( left + right ) / 2;
                if(nums[mid] < nums[mid+1])
                    left = mid + 1;
                else
                    right = mid;
            }

            return left;
        }
    }
}