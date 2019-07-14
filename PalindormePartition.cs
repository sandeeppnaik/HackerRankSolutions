using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public class PalindormePartition
    {
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            Palindromes(s, 0, result, new List<string>());
            return result;
        }

        public IList<IList<string>> Palindromes(string s, int start,
         IList<IList<string>> dromes, List<string> pals)
        {
            if(start == s.Length)
            {
                dromes.Add(new List<string>(pals));
            }

            for(int i = start; i < s.Length ; i++)
            {
                int length = i - start + 1;
                var piece = s.Substring(start, length);
                if(piece == "abba")
                    System.Console.WriteLine( "");
                if(IsPalindrome(piece))
                {
                    pals.Add(piece);
                    Palindromes(s,i+1,dromes,pals);
                    pals.RemoveAt(pals.Count - 1);
                }
            }

            return dromes;
        }

        private bool IsPalindrome(string s)
        {
            var ca = s.ToCharArray();
            Array.Reverse(ca);
            return new string(ca) == s;
        }
    }
}