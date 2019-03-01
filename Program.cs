using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hackerrank
{
    class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode(int d){
            data=d;
            next=null;
        }
    }

    class Node
    {
        public Node left,right;
        public int data;
        public Node(int data){
            this.data=data;
            left=right=null;
        }
    }

    class Program
    {
        #region GCD of List
        private static int EucladianPrinciple(int a, int b)
        {
            if(a % b == 0)
                return b;
            
            if(b % a == 0)
                return a;

            var q = 0; var r = 0;

            r = Math.Max(a,b) % Math.Min(a,b);

            return EucladianPrinciple(r,Math.Min(a,b));
        }

        private static int FindGCD(List<int> nums)
        {
            var gcd = EucladianPrinciple(nums[0],nums[1]);

            for(int i = 1; i < nums.Count() - 1; i++)
            {
                gcd = EucladianPrinciple(gcd, nums[i+1]);
            }

            return gcd;
        }
        #endregion

        #region DUPLICATE LINKED LIST
        public static LinkedListNode removeDuplicates(LinkedListNode head)
        {
            if(head == null || head.next == null)
                return head;

            unlinkDuplicate(head, head.next);

            removeDuplicates(head.next);

            return head;
        }

        private static void unlinkDuplicate(LinkedListNode head, LinkedListNode duplicate)
        {
            if(duplicate == null)
            {
                head.next = null;
            }
            if(head.data == duplicate.data)
            {
                unlinkDuplicate(head, duplicate.next);
            }
            else
            {
                head.next = duplicate;
            }
        }

        public static  LinkedListNode insertLinkedList(LinkedListNode head,int data)
        {
            LinkedListNode p=new LinkedListNode(data);
            
            
            if(head==null)
                head=p;
            else if(head.next==null)
                head.next=p;
            else
            {
                LinkedListNode start=head;
                while(start.next!=null)
                    start=start.next;
                start.next=p;
                
            }
            return head;
        }
        #endregion

        #region DEPTH OF TREE 
        static Node insert(Node root, int data)
        {
            if(root==null){
                return new Node(data);
            }
            else{
                Node cur;
                if(data<=root.data){
                    cur=insert(root.left,data);
                    root.left=cur;
                }
                else{
                    cur=insert(root.right,data);
                    root.right=cur;
                }
                return root;
            }
        }
        static int getHeight(Node root)
        {
            if(root == null)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(getHeight(root.left), getHeight(root.right));
            }
            // System.Collections.Generic.Stack<Node> nodeStack = new System.Collections.Generic.Stack<Node>();
            // int height = 0;
            // int i = 0;

            // while(root != null || nodeStack.Count != 0)
            // {
            //     if(root != null)
            //     {
            //         i++;
            //         nodeStack.Push(root);
            //         root = root.left;
            //     }
            //     else
            //     {
            //         var parent = nodeStack.Pop();
            //         root = parent.right;
            //         if(root != null)
            //         {
            //             i++;
            //         }
            //         else
            //         {
            //             i--;
            //         }
            //     }

            //     height = Math.Max(height,i);
            // }

        }
        #endregion

        #region Implementation

        static List<int> freqQuery(List<int[]> queries) 
        {
            var manager = new Dictionary<int,int>();
            var frequencies = new Dictionary<int,HashSet<int>>();

            var result = new List<int>();

            foreach(var item in queries)
            {
                var operation = item[0];
                int i = 0;
                switch(operation)
                {
                    case 1:
                        try
                        {
                            manager.Add(item[1],1);                            
                        }
                        catch(Exception)
                        {
                            manager[item[1]]++;
                        }
                        try
                        {
                            var freq = manager[item[1]];
                            var previousFreq = manager[item[1]] - 1;
                            if(previousFreq != 0 )
                            {
                                frequencies[previousFreq].Remove(item[1]);
                            }

                            if(frequencies.ContainsKey(freq))
                            {
                                frequencies[freq].Add(item[1]);
                            }
                            else
                            {
                                frequencies.Add(freq, new HashSet<int>{ item[1]});
                            }
                        }
                        catch(Exception)
                        {

                        }
                        break;
                    case 2:
                        try
                        {
                            manager[item[1]]--;
                            var freq = manager[item[1]];
                            if(freq != 0)
                            {
                                frequencies[freq].Add(item[1]);
                            }

                            frequencies[freq + 1].Remove(item[1]);
                        }
                        catch(Exception)
                        {}
                        break;
                    case 3:
                        var frequency = item[1];
                        var matches = 0;
                        try
                        {
                            matches =   frequencies[frequency].Count();
                        }
                        catch(KeyNotFoundException)
                        {

                        }
                        result.Add(matches > 0 ? 1 : 0);
                        break;
                    default:
                        break;
                }
                i++;
            }     

            return result;
        }

        static long countTriplets_v1(List<long> arr, long r) 
        {
            var mp2 = new System.Collections.Generic.Dictionary<long,long>();
            var mp3 = new System.Collections.Generic.Dictionary<long,long>();
            long res = 0;
            foreach (long val in arr)
            {
                if (mp3.ContainsKey(val))
                    res += mp3[val];
                if (mp2.ContainsKey(val))
                    if (mp3.ContainsKey(val*r))
                        mp3[val*r] += mp2[val];
                    else
                        mp3[val*r] = mp2[val];
                if (mp2.ContainsKey(val*r))
                    mp2[val*r]++;
                else
                    mp2[val*r] = 1;
            }
            return res;
        }

        static long countTriplets(List<long> arr, long r) 
        {
            var lookup = new Dictionary<long,HashSet<int>>();

            for(int i = 0; i < arr.Count; i++)
            {
                try
                {
                    lookup.Add(arr[i], new HashSet<int>(){i});
                }
                catch(Exception)
                {
                    lookup[arr[i]].Add(i);
                }
            }

            long triplets = 0;

            for(int i = 0; i < arr.Count; i++)
            {
                var start = arr[i];
                long secondOccurence = 1;
                long thirdOccurence = 1;

                if(lookup.ContainsKey(start * r))
                {
                    lookup[start * r].RemoveWhere(c => c <= i);
                    secondOccurence = lookup[start * r].Count();

                    if(lookup.ContainsKey(start * r * r))
                    {
                        lookup[start * r * r].RemoveWhere(c => c <= i);
                        thirdOccurence = lookup[start * r * r].Count();

                        triplets = triplets + (secondOccurence * thirdOccurence);
                    }
                }
            }

            return triplets;
        }

        static int sherlockAndAnagrams(string s)
        {
            var hashSet = new HashSet<string>();
            if(s.Length == s.Distinct().Count())
            {
                return 0;
            }

            for(int i = 0; i < s.Length - 1 ; i++)
            {
                for(int j = i, k = 1 ; j < s.Length; j++,k++)
                {
                    hashSet.Add( new string(s.Substring(i,k).Reverse().ToArray()));
                }
            }

            int pairs = 0;
            for(int i = 0; i < s.Length - 1 ; i++)
            {
                for(int j = i, k = 1 ; j < s.Length -1; j++,k++)
                {
                    var lookup = s.Substring(i,k);
                    if(hashSet.Contains(lookup))
                        pairs++;
                    
                }
            }

            return pairs;
        }

        static void checkMagazine(string[] magazine, string[] note) 
        {
            var hashSet = new Dictionary<string,int>();
            foreach(var n in magazine)
            {
                try
                {
                    hashSet.Add(n,1);
                }
                catch(Exception)
                {
                    hashSet[n] = hashSet[n] + 1;
                }
            }

            var charMatch = true;
            for(int i = 0; i < note.Length ; i++)
            {
                if(!hashSet.ContainsKey(note[i]) || hashSet[note[i]] == 0)
                {
                    charMatch = false;
                    break;
                }
                else
                {
                    hashSet[note[i]] =  hashSet[note[i]] - 1; 
                }
                
            }

            Console.WriteLine(charMatch ? "Yes" : "No");

        }

        static string twoStrings(string s1, string s2)
        {
            var s1HashSet = new HashSet<char>();
            foreach(var c in s1)
            {
                s1HashSet.Add(c);
            }

            foreach(var c in s2)
            {
                if(s1HashSet.Contains(c));
                    return "YES";
            }     
            return "NO";
        }

        #endregion

        #region functions sample

        public static Func<int, int> SumByFiveFunc(Func<int, int, int> sum)
        {
            return x => sum(x,5);
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }
        #endregion
        static void Main(string[] args)
        {
            var resultGCD = FindGCD(new List<int>{18,27,81,90});
            Func<int,int> f = SumByFiveFunc(Sum);
            var result = f(3);

            // sherlockAndAnagrams("abba");
            // countTriplets(new List<long>{1 ,2, 2, 4},2);
            // countTriplets(new List<long>{1 ,1, 1, 1, 1, 1},1);
            // countTriplets_v1(new List<long>{1 ,2, 1, 2, 4},2);
            #region DEPTH OF TREE INVOCATION
            // Node root = null;
            // int[] l = new int[]{9,20,50,35,44,15,62,11,13};
            // for(int i = 0; i < l.Length ; i++)
            // {
            //     root=insert(root,l[i]); 
            // }

            // var result = getHeight(root);
            #endregion

            #region DUPLICATES IN LINKEDLIST
            LinkedListNode head=null;
            var li = new []{1,2,2,3,3,4};
            for(int i = 0; i< li.Length ; i++)
            {
                head = insertLinkedList(head,li[i]);
            }
      	    head=removeDuplicates(head);
            #endregion
        }
    }
}