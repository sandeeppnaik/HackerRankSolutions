using System.Collections.Generic;

namespace Hackerrank
{
    public class ParanthesesGenerator
    {

        IList<string> result = new List<string>();

        public IList<string> GenerateParenthesis(int n) 
        {
            Generator("", 0, 0, n);
            return result;
        }

        private void Generator(string s, int open, int close, int n)
        {
            if(s.Length == n * 2)
            {
                result.Add(s);
                return;
            }

            if(open < n)
            {
                Generator(s + "(", open + 1, close, n);
            }
            if(close < open)
            {
                Generator(s + ")", open, close + 1, n);
            }
        }
    }
}