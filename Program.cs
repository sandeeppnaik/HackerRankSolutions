using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
        //    var root = new TreeNode(3);
        //    root.left = new TreeNode(9);
        //    root.left.left = new TreeNode(5);
        //    root.left.right = new TreeNode(4);

        //    root.right = new TreeNode(20);
        //    root.right.left = new TreeNode(15);
        //    root.right.right = new TreeNode(7);
        //    var result = new ZigZagLevelOrderTraversal().ZigzagLevelOrder(root);

            // https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
            // var preorder = new int[]{3,9,20,15,7};
            // var inorder = new int[]{9,3,15,20,7};
            // var result = new TreeBuilder().BuildTree(preorder, inorder);

            // var result = new WordLadder().LadderLength("hit", "cog",
            //             new List<string>{"hot","dot","dog","lot","log","cog"});

            // var result = new WordLadder().LadderLength("hot", "dog",
            //             new List<string>{"hot","dog"});

            // var result = new MockInterview().RemoveElement(new int[]{3,2,2,3}, 3);

            // var board = new char[4][]
            // {
            //     new char[]{'X','X','X','X'},
            //     new char[]{'X','O','O','X'},
            //     new char[]{'X','X','O','X'},
            //     new char[]{'X','O','X','X'}
            // };

            // var board = new char[5][]
            // {
            //     new char[]{'O','X','X','O','X'},
            //     new char[]{'X','O','O','X','O'},
            //     new char[]{'X','O','X','O','X'},
            //     new char[]{'O','X','O','O','O'},
            //     new char[]{'X','X','O','X','O'}
            // };

            // new SurroundedRegions().Solve(board);

            // var result = new PalindormePartition().Partition("abbab");

            // var gas  = new int[]{1,2,3,4,5};
            // var cost = new int[]{3,4,5,1,2};
            // var gas  = new int[]{2,3,4};
            // var cost = new int[]{3,4,3};
            // var result = new GasStation().CanCompleteCircuit(gas,cost);

            // string s = "leetcode";
            // var wordDict = new List<string>(){"leet", "code"};
            // string s = "applepenapple";
            // var wordDict = new List<string>(){"apple", "pen"};
            // string s = "aaaaaaa";
            // var wordDict = new List<string>(){"aaa","aaaa"};
            // var result = new WordBreak().WordBreaker(s, wordDict);

            var result = new ReversePolishNotation().EvalRPN(new string[]{"2","1","+","3","*"});

        }
    }
}
