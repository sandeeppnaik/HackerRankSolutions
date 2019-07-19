using System;
using System.Linq;
using System.Text;

namespace Hackerrank
{
    public class LargestNumberCalculator
    {
        public string LargestNumber(int[] nums) 
        {
            StringBuilder result = new StringBuilder();

            var containsOnlyZeros = true;
            var strArray = new string[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                if(containsOnlyZeros && nums[i] > 0)
                    containsOnlyZeros = false;

                strArray[i] = nums[i].ToString();
            }

            if(containsOnlyZeros)
                return "0";

            Array.Sort(strArray, (s1,s2) => (s1 + s2).CompareTo(s2 + s1) );

            for(int i = strArray.Length - 1; i >= 0; i--)
            {
                result.Append(strArray[i]);
            }

            return result.ToString();            
        }
    }
}