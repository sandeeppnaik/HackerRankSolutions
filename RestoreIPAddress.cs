using System.Collections.Generic;

namespace Hackerrank
{
    public class RestoreIPAddress
    {
        public IList<string> BuildIpAddresses(string s) 
        {
            var result = new List<string>();
            Validate(result, s, 1, 0, string.Empty);
            return result;
        }

        private void Validate(List<string> result, string s, int subsetId, int startIndex, string ipAddress)
        {
            string subset  = string.Empty;
            if(startIndex + 4 > s.Length)
            {
                subset = s.Substring(startIndex);
            }
            else
            {
                if(subsetId == 4)
                {
                    return ;
                }

                subset = s.Substring(startIndex,3);
            }

            string ipset = null;
            for(int i = 0; i < subset.Length; i++)
            {
                ipset += subset[i];
                var ipnumber = int.Parse(ipset);

                if(ipnumber >= 0 && ipnumber < 256 && subsetId < 4)
                {
                    Validate(result, s, subsetId + 1, startIndex + i + 1, ipAddress + ipnumber + ".");
                }
                else if(ipnumber >= 0 && ipnumber < 256 && subsetId == 4
                    && startIndex + i + 1 == s.Length)
                {
                    ipAddress += ipnumber;
                    result.Add(ipAddress);
                }

                if(ipnumber == 0)
                {
                    break;
                }
            }
        }
    }

}