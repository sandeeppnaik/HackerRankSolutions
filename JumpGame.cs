using System;

namespace Hackerrank
{
    public class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            var canReach = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(i > canReach)
                    return false;

                canReach = Math.Max(canReach, nums[i] + i);
            }

            return true;
        }
    }
}