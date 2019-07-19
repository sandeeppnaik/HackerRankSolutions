namespace Hackerrank
{
    public class FractionToRecurringDecimal
    {
        public string FractionToDecimal(int numerator, int denominator) 
        {
            var result = (float) numerator / (float) denominator ;
            long result1 =  (long)numerator /  denominator ;

            var response =  result.ToString();
            if(response.Contains("."))
            {
                var subset = response.Substring(response.IndexOf(".") + 1, response.Length - response.IndexOf(".") - 1 );
                
                if(subset.Length >= 6 )
                {
                    var dec =  subset.Substring(0,6) ;
                    if(dec[0] == dec[1] && dec[2] == dec[3])
                        dec = dec[0].ToString();
                    response = (numerator/denominator).ToString() + ".(" + dec + ")";
                }
            }

            return response;
        }
    }
}