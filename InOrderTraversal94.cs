using System.Collections.Generic;

namespace Hackerrank
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
 
    public class InOrderTraversal94
    {
        public IList<int> InorderTraversal(TreeNode root) 
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();   
            while(root != null || stack.Count != 0)
            {
                if(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    var item = stack.Pop();
                    result.Add(item.val);
                    root = item.right;
                }
            }
            return result;
        }
    }
}