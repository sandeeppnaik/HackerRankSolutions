namespace Hackerrank
{
    public class Palindrome
    {
        public string LongestPalindrome(string s) 
        {
            if(string.IsNullOrEmpty(s))
                return string.Empty;

            var LongestPalindrome = string.Empty;

            int evenIncrementer = 0;
            for(int i = 0; i < s.Length; i++)
            {
                while( 0 <= i - evenIncrementer &&
                    i + 1 + evenIncrementer < s.Length &&
                    s[i - evenIncrementer] == s[i + 1 + evenIncrementer])
                {
                    var palindrome = s.Substring(i - evenIncrementer,( 2 *  (evenIncrementer +1) ));
                    LongestPalindrome = LongestPalindrome.Length > palindrome.Length
                        ? LongestPalindrome
                        : palindrome ;

                    evenIncrementer++;
                }
                evenIncrementer = 0;
            }

            int oddIncrementer = 1;
            for(int i = 0; i < s.Length; i++)
            {
                while( 0 <= i - oddIncrementer &&
                    i + oddIncrementer < s.Length &&
                    s[i - oddIncrementer] == s[i + oddIncrementer])
                {
                    var palindrome = s.Substring(i - oddIncrementer,( 1 + (2 *  oddIncrementer)));
                    LongestPalindrome = LongestPalindrome.Length > palindrome.Length
                        ? LongestPalindrome
                        : palindrome ;

                    oddIncrementer++;
                }

                oddIncrementer = 0;
            }

            return LongestPalindrome;
        }
    }
}