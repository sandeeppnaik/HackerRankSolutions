using System;

public class LongestSubSequence
{
    public int LengthOfLIS(int[] nums)
    {
        if(nums.Length == 0)
            return 0;

        var dp = new int [nums.Length];
        for (int i = 1; i < nums.Length; i++)
        {
            int current = nums[i];
            int maxValue = 0;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < current)
                {
                    maxValue = Math.Max(dp[j], maxValue);
                }
            }
            dp[i] = maxValue + 1;
        }

        return dp[nums.Length - 1];
    }
}