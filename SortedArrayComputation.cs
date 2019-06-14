using System;

namespace Hackerrank
{
    public class SortedArrayComputation
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return nums[0] == target ? 1 : -1;

            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                var mid = (start + end) / 2;

                if (nums[mid] > nums[end])
                {
                    if (target > nums[mid] || nums[end] >= target)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid;
                    }
                }
            }

            return nums[start] == target ? start : -1;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[2] { -1, -1 };
            var start = 0;
            var end = nums.Length - 1;

            result[0] = FindFirstOccurence(0, end, nums, target);
            result[1] = FindLastOccurence(0, end, nums, target);

            return result;
        }

        private int FindFirstOccurence(int start, int end, int[] nums, int target)
        {
            var result = -1;
            while(start <= end)
            {
                var mid = ( start + end ) / 2;
                if(nums[mid] >= target)
                    end = mid - 1;
                else
                    start = mid + 1;

                if(nums[mid] == target)
                    result = mid;
            }
            return result;
        }

        private int FindLastOccurence(int start, int end, int[] nums, int target)
        {
            var result = -1;
            while(start <= end)
            {
                var mid = ( start + end ) / 2;
                if(nums[mid] <= target)
                    start = mid + 1;
                else
                    end = mid - 1;

                if(nums[mid] == target)
                    result = mid;
            }
            return result;
        }
    }
}