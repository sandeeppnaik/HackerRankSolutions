using System.Collections.Generic;

public class IntegerToWords
{
    Dictionary<int, string> Resolver = new Dictionary<int, string>
    {
        {1, "One"},{2, "Two"},{3, "Three"},{4, "Four"},{5, "Five"},
        {6, "Six"},{7, "Seven"},{8, "Eight"},{9, "Nine"},{10, "Ten"},
        {11, "Eleven"},{12, "Twelve"},{13, "Thirteen"},{14, "Fourteen"},{15, "Fifteen"},
        {16, "Sixteen"},{17, "Seventeen"},{18, "Eighteen"},{19, "Nineteen"},
    };

    Dictionary<int, string> TensResolver = new Dictionary<int, string>
    {
        {2, "Twenty"},{3, "Thirty"},{4, "Forty"},
        {5, "Fifty"},{6, "Sixty"},{7, "Seventy"},
        {8, "Eighty"},{9, "Ninety"}
    };

    List<KeyValuePair<int, string>> ValueResolver = new List<KeyValuePair<int, string>>
    {
        { new KeyValuePair<int, string>(1000000000, "Billion") },
        { new KeyValuePair<int, string>(1000000, "Million") },
        { new KeyValuePair<int, string>(1000, "Thousand") },
        { new KeyValuePair<int, string>(100, "Hundred") },
        { new KeyValuePair<int, string>(10, "") },
    };

    public string NumberToWords(int num)
    {
        if (num == 0) 
            return "Zero";

        var result = Iterator(num, string.Empty, ValueResolver);

        return result.TrimEnd();
    }

    private string Iterator(int num, string s, List<KeyValuePair<int, string>> divisorList)
    {
        if (num == 0)
            return s;

        for (int i = 0; i < divisorList.Count; i++)
        {
            var divisor = divisorList[i].Key;
            var quotient = num / divisor;
            var remainder = num % divisor;

            if (quotient == 0 && remainder == 0)
                return s;
            
            if(num < 20)
                return s + Resolver.GetValueOrDefault(num, string.Empty);

            if (Resolver.ContainsKey(quotient))
            {
                var val = string.Empty;
                if (num < 100)
                {
                    TensResolver.TryGetValue(quotient, out val);
                    s += val + " " + Resolver.GetValueOrDefault(remainder, string.Empty);
                }
                else
                {
                    Resolver.TryGetValue(quotient, out val);
                    s += val + " " + divisorList[i].Value + " ";
                }
            }
            else if (quotient != 0)
            {
                var updatedList = new List<KeyValuePair<int, string>>();
                updatedList.AddRange(divisorList);
                updatedList.RemoveRange(0, i + 1);
                s = Iterator(quotient, s, updatedList).TrimEnd() + " " + divisorList[i].Value + " ";
            }


            num = remainder;

        }

        return s;

    }

}