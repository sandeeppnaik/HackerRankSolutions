using System.Collections.Generic;

namespace Hackerrank
{
    public class WordBreak
    {
        public bool WordBreaker(string s, IList<string> wordDict) 
        {
            for(int i  = 0; i < wordDict.Count; i++)
            {
                if(Remover(s, wordDict, i))
                    return true;
            }

            return false;
        }

        private bool Remover(string s, IList<string> wordDict, int start)
        {
            for(int i  = start; i < wordDict.Count; i++)
            {
                s = RemoveDups(s, wordDict[i]);
                if(string.IsNullOrEmpty(s))
                    return true;
            }
            return false;
        }

        private string RemoveDups(string original, string remove)
        {
            if(string.IsNullOrEmpty(original))
                return original; 

            if(!original.Contains(remove))
                return original;

            original = original.Replace(remove, "");
            return RemoveDups(original, remove);
        }
    }
}