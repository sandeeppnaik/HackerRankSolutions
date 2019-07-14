using System;

namespace Hackerrank
{
    public class MockInterview
    {
        public int RemoveElement(int[] nums, int val)
        {
            int count = 0;
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] != val)
                {
                    nums[count++] = nums[i];
                }
            }
            return count;
        }
        // Array.Sort(nums);
        // var start = -1;
        // var end = -1;
        // for(int i = 0; i < nums.Length; i++)
        // {
        //     if(nums[i] == val && start == -1)
        //         start = i;

        //     if(nums[i] == val)
        //         end = i;
        // }

        // if(end == nums.Length - 1)
        //     return end - start;

        // for(int j = end + 1; j < nums.Length ; j++ )
        // {
        //     nums[start] = nums[j];
        //     start++;
        // }

        // if(start != -1)
        //     return end - start;
        // return 0;

    }
}
