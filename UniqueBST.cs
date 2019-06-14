using System.Collections.Generic;

namespace Hackerrank
{
    public static class UniqueBST
    {
        public static List<TreeNode> generateTrees(int n)
        {
            if(n == 0) 
                return new List<TreeNode>();

            return DFS(1,n);
        }

        public static List<TreeNode> DFS(int start, int end)
        {
            var result = new List<TreeNode>();

            if(start > end)
            {
                result.Add(null);
                return result;
            }

            for(int i = start; i <= end; i++)
            {
                var LeftTree = DFS(start,i - 1);
                var RightTree = DFS(i + 1,end);

                foreach(var leftitem in LeftTree)
                {
                    foreach(var rightitem in RightTree)
                    {
                        var root = new TreeNode(i);
                        root.left = leftitem;
                        root.right = rightitem;
                        result.Add(root);
                    }
                }

            }

            return result;
        }
    }
}