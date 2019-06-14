using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class GroupAnangrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {

            var lookup = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var ca = str.ToCharArray();
                Array.Sort(ca);
                var val = new string(ca);
                try
                {
                    var value = lookup[val];
                    value.Add(str);
                }
                catch(KeyNotFoundException)
                {
                    lookup.Add(val, new List<string>(){str});
                }
            }

            return lookup.Values.ToList();
        }
    }
}