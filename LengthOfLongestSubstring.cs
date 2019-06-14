using System;

namespace Hackerrank
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s))
            return 0;
        
        var stringLength = s.Length;
        if(stringLength == 1)
            return 1;
        
        int start = 0;
        int end = 1;
        int substringLength = -1;
        while(end < stringLength)
        {
           if(s.Substring(start, end - start).Contains(s[end]))
           {
               start = s.IndexOf(s[end], start) + 1;
           }
            substringLength = Math.Max(substringLength,end - start + 1);
            end++;
        }

        return substringLength;
        }
    }
}