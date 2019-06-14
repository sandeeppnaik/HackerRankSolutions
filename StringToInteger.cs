namespace Hackerrank
{
    public class StringToInteger
    {

        public int MyAtoi(string str) 
        {
            str  = str.Trim();
            bool isNegative = false;
            string result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            for(int s = 0; s < str.Length; s++)
            {
                if(s == 0 && 
                    (str[s] == '+' || str[s] == '-'))
                {
                    isNegative = str[s] == '-';
                    continue;
                }

                var success = int.TryParse(str[s].ToString(), out int n);

                if (!success)
                    break;

                result += str[s];
            } 

            if (string.IsNullOrWhiteSpace(result))
            {
                return 0;
            }

            var withinLimit = int.TryParse(result, out int number);

            if(!withinLimit)
            {
                return isNegative ?  int.MinValue : int.MaxValue ;   
            }
            else
            {
                return isNegative ?  -1 * number : number ;
            }
        }
    }
}