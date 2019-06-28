using System.Collections.Generic;

namespace Hackerrank
{
    public class DecodeWays
    {
        Dictionary<string,char> lookup = new Dictionary<string,char>
        {
            {"1",'A'},{"2",'B'},{"3",'C'},{"4",'D'},{"5",'E'},{"6",'F'},
            {"7",'G'},{"8",'H'},{"9",'I'},{"10",'J'},{"11",'K'},{"12",'L'},{"13",'M'},
            {"14",'N'},{"15",'O'},{"16",'P'},{"17",'Q'},{"18",'R'},{"19",'S'},
            {"20",'T'},{"21",'U'},{"22",'V'},{"23",'W'},{"24",'X'},{"25",'Y'},{"26",'Z'}
        };

        public int NumDecodings(string s) 
        {
            if(s[0] == '0')
                return 0;

            var reference = new int [s.Length + 1];
            reference[0] = 1;
            reference[1] = 1;

            for(int i = 1; i < s.Length ; i++)
            {
                if(s[i] == '0')
                {
                    if(s[i-1] == '0' || int.Parse(s[i - 1].ToString()) > 2)
                        return 0;
                    reference[i+1] = reference[i - 1];
                }
                else if(s[i - 1] == '1' || s[i - 1] == '2' 
                && int.Parse(s[i].ToString()) < 7)
                {
                    reference[i+1] = reference[i] + reference[i-1];
                }
                else
                {
                    reference[i+1] = reference[i];
                }
            }

            return reference[reference.Length - 1];
        }
    }
}