using System;
using System.Collections.Generic;
using System.Linq;

// https://leetcode.com/problems/maximum-number-of-non-overlapping-substrings/
public class MaxNumberOfSubString
{
    public IList<string> MaxNumOfSubstrings(string ss)
    {
        char[] s = ss.ToCharArray();
        Dictionary<char, int[]> range = new Dictionary<char, int[]>();
        
		// get each character's range
        for(int i = 0; i < s.Length; i++) {
            char cur = s[i];
            if(range.ContainsKey(cur))
                range[cur][1] = i;
            else 
                range.Add(cur, new int[]{i, i});
        }
        
		// extend the range
        List<int[]> values = new List<int[]>(range.Select(c => c.Value));
        foreach(int[] r in values) {
            
			// gather all characters in the range r[0]...r[1]
            HashSet<char> seen = new HashSet<char>();
            int size = 0, min = r[0], max = r[1];
            for(int i = r[0]; i <= r[1]; i++) {
                if(seen.Add(s[i])) {
                    var temp = range[s[i]];
                    min = Math.Min(min, temp[0]);
                    max = Math.Max(max, temp[1]);
                }
            }
            
			// extend the range untile the range will not cover any other new character
            while(seen.Count() != size) {
                size = seen.Count();
                int nMin = min;
                int nMax = max;
                
                for(int i = min; i < r[0]; i++) {
                    if(seen.Add(s[i])){
                        var temp = range[s[i]];
                        nMin = Math.Min(nMin, temp[0]);
                        nMax = Math.Max(nMax, temp[1]);
                    }
                }
                
                for(int i = r[1] + 1; i <= max; i++) {
                    if(seen.Add(s[i])){
                        var temp = range[s[i]];
                        nMin = Math.Min(nMin, temp[0]);
                        nMax = Math.Max(nMax, temp[1]);
                    }
                }
                
                r[0] = min; // new end point
                r[1] = max;
                min = nMin; // new start point
                max = nMax;
                // System.out.println("====");
            }
        }

        // meeting room solution
        values.Sort((a,b) => a[1] - b[1]);
		
        int p = -1;
        var res = new List<string>();
        
        for(int i = 0; i < values.Count; i++) {
            if(values[i][0] > p) { // can be accepted
                p = values[i][1]; // p means lastest used index
                res.Add(ss.Substring(values[i][0], values[i][1] - values[i][0] + 1));
            }
        }
        return res;
    }
}