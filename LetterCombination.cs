using System.Collections.Generic;

namespace Hackerrank
{

    public class LetterCombination
    {
        public IList<string> LetterCombinations(string digits) 
        {
            var result = new List<string>();

            if(string.IsNullOrEmpty(digits))
                return result;

            var lookup = new Dictionary<char, string>
            {
                {'2',"abc"},
                {'3',"def"},
                {'4',"ghi"},
                {'5',"jkl"},
                {'6',"mno"},
                {'7',"pqrs"},
                {'8',"tuv"},
                {'9',"wxyz"},
            };

            for(int i = 0; i < digits.Length ; i ++)
            {
                var latest = new List<string>();
                var num = digits[i];
                var stringLookup = lookup[num];
                foreach(var item in stringLookup)
                {
                    if(i == 0)
                    {
                        latest.Add(item.ToString());
                    }
                    else
                    {
                        foreach(var str in result)
                        {
                            latest.Add(str + item.ToString());
                        }
                    }
                }
                result = latest;
            }

            return result;
        }
    }
}