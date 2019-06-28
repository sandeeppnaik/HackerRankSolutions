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

    public class ValidateBinaryTree
    {
        public bool IsValidBST(TreeNode root)
        {

            TreeNode previous = null;
            var stk = new Stack<TreeNode>();
            while (root != null || stk.Count != 0)
            {
                if (root != null)
                {
                    stk.Push(root);
                    root = root.left;
                }
                else
                {
                    var rt = stk.Pop();
                    if (previous != null && previous.val >= rt.val)
                        return false;

                    previous = rt;
                    root = rt.right;
                }
            }
            return true;
        }
    }
}