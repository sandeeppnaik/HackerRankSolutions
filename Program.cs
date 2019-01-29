using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hackerrank
{
    class Program
    {
        #region Array Selection            
        private static int recursiveMethod(int[] arr, int swaps)
        { 
            bool unsorted = true;
            for(int i = arr.Length - 2; i >= 0 ; i--)
            {
                if(arr[i] > arr[i+1])
                {
                    var temp = arr[i+1];
                    arr[i+1] = arr[i];
                    arr[i] = temp;
                    swaps++;
                    unsorted = false; 
                }
            }

            return unsorted ? swaps : recursiveMethod(arr,swaps);
        }
        private static int Prune(int []arr, int result, int index)
        {
            bool notPruned = false;
            if(arr[index] == arr.Max() && arr[arr.Length - 1 - index] == arr.Min())
            {
                result++;
                notPruned = true;
            }
            index++;
            return notPruned ? Prune(arr, result, index) : result ;

        }
        static int minimumSwaps(int[] arr)
        {
            var result = Prune(arr,0,0);
            int[] newArr;
            if(result > 0)
            {
                newArr = new int [arr.Length - (result * 2)];
                Array.Copy(arr, result, newArr, 0, arr.Length - 1 - result);
                    
            }
            else
            {
                newArr = arr;
            }
            var result1 = recursiveMethod(newArr,0);
            return result + result1;
        }
        static long[] bonetrousle(long n, long k, int b) 
        {
            var result = new long[b];
            var spagetiiFail = false;
            long maxCount = 0;
            for(long i = k;i > k-b ; i--)
            {
                maxCount += i;
                if(maxCount >= n)
                {
                    spagetiiFail = false;
                    break;
                }
                spagetiiFail = true;
            }

            if(spagetiiFail)
            {
                return new long[1]{-1};
            }

            if(b == 1)
            {
                return new long[1]{n};
            }

            for(int i = 1;i <= b; i++ )
            {
                result[i - 1] = i;
            }

            var len = 0;
            var limit = k;
            while(result.Sum() != n)
            {
                if(result[b - 1 - len] < limit)
                {
                    if(result.Take(b - 1 - len).Sum() + result.Reverse().Take(len).Sum()  + limit < n)
                    {
                            result[b - 1 - len] = limit;
                    }
                    else
                    {
                        result[b - 1 - len] ++;
                    }
                }
                else
                {
                    len ++;
                    limit--;
                }
            }

            return result;
        }
        public static string gamingArray(List<int> arr)
        {
            var initial = arr.ToArray();

            var len = initial.Length;
            var temp = initial;
            var BobbyIsPlaying = false;
            
            while(temp.Length > 0)
            {
                var highest = temp.OrderByDescending(c => c).First();
                var cc = Array.FindIndex(initial,c => c ==  highest);
                temp= initial.Take(cc).ToArray();
                BobbyIsPlaying = !BobbyIsPlaying;
            }

            return BobbyIsPlaying ? "BOB" : "ANDY";
        }
        static void minimumBribes(int[] q)
        {            
            #region BruteForce
                
            var bribe = 0;
            var bribeLimit = 2;
            var LimitReached = false;
            for(int i = 0 ; i < q.Length ; i++)
            {
                if(LimitReached)
                {
                    break;
                }
                var bribePerPerson = 0;
                for(int j = i; j < q.Length; j++)
                {
                    if(q[i] > q[j])
                    {
                        bribe++;
                        bribePerPerson++;
                    }
                    if(bribePerPerson > bribeLimit)
                    {
                        LimitReached = true;
                        break;
                    }
                }
            }
            #endregion
        }
        static int[] rotLeft(int[] a, int d) {

            var firstPartLenght = a.Length - d;
            var firstPart = new int[firstPartLenght];
            var secondPart = new int[d];

            for(int i = 0; i < d ; i++)
            {
                secondPart[i] = a[i];
            }

            for(int i = d, j = 0; i < a.Length ; i++, j++)
            {
                firstPart[j] = a[i];
            }

            var result = firstPart.Concat(secondPart).ToArray();
            // var firstPart = a.TakeLast(a.Length - d);
            // var lastPart = a.Take(d);
            // var result = firstPart.Concat(lastPart).ToArray();
            return result;
        }
        static long repeatedString(string s, long n) {
            
            var strlength = s.Length;
            var OccurenceOfA = s.Where(c => c.Equals('a')).Count();
            if(OccurenceOfA == 0 ) return 0;
            var quotient =  n / strlength;
            var remainder = n % strlength;

            var partialString = s.Substring(0,(int)remainder);
            return (OccurenceOfA * quotient) + partialString.Where(c => c.Equals('a')).Count(); 

        }
        static int jumpingOnClouds(int[] c)
        {
            int numberOfJumps = 0;
            for(int i = 0; i < c.Length -1 ; i++)
            {
                if(i + 1 == c.Length - 1)
                {


                }
                else if(c[i+2] == 0 || c[i+1] == 1)
                {
                    i = i+1; 
                }
                numberOfJumps++;
            }
            return numberOfJumps;
        }
        static int countingValleys(int n, string s) {

            int currentLevel = 0;
            int numberOfValleys = 0;
            int previousLevel = 0 ;
            for(int i = 0; i < s.Length ; i++)
            {
                previousLevel = currentLevel;
                switch(s[i])
                {
                    case 'U':
                        currentLevel++;
                        break;
                    case 'D':
                        currentLevel--;
                        break;
                }
                if(currentLevel == 0 && previousLevel == -1)
                {
                    numberOfValleys++;
                }
            }
            return numberOfValleys;
        }
        static int sockMerchant(int n, int[] ar)
        {

            var uniqueDict = new Dictionary<int,int>();
            foreach(int i in ar)
            {
                var valueAlreadyPresent = uniqueDict.TryAdd(i,1);
                if(valueAlreadyPresent)
                {
                    uniqueDict[i] += 1; 
                }
            }

            var totalpairs = 0;
            foreach(KeyValuePair<int,int> i in uniqueDict)
            {
                    totalpairs = i.Value / 2;
            }

            return totalpairs;
        }

        #endregion
        
        static void Main(string[] args)
        {
            // minimumSwaps(new int[7]{1 ,3 ,5 ,2 ,4, 6, 7});
            // minimumSwaps(new int[4]{4 ,3 ,1 ,2 });

            // bonetrousle(210, 20, 20);
            // gamingArray(new List<int>{5, 2, 6, 3, 4});
            // minimumBribes(new int[5]{2, 1, 5, 3, 4});
            // minimumBribes(new int[8]{1 ,2 ,5 ,3, 4, 7, 8, 6});
            // rotLeft(new int[5]{1, 2, 3, 4, 5},4);
            // repeatedString("ceebbcb",817723);
        }
    }
}
