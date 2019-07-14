using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    public class TreeNode
    {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
    }

    //https://leetcode.com/problems/binary-tree-level-order-traversal/
    public class BinaryTreeOrderTraversal
    {        
        public IList<IList<int>> LevelOrder(TreeNode root) 
        {
            var q = new Queue<TreeNode>();
            var result = new List<IList<int>>();

            q.Enqueue(root);
            while(q.Count != 0)
            {
                var level = q.Count;
                var lowlevelList = new List<int>();
                for(int i = 0; i < level; i++)
                {
                    var item = q.Dequeue();
                    if(item != null)
                    {
                        lowlevelList.Add(item.val);
                        q.Enqueue(item.left);
                        q.Enqueue(item.right);
                    }
                }
                result.Add(lowlevelList);
            }

            return result;
        }
    }
}