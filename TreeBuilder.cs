using System;

namespace Hackerrank
{
    public class TreeBuilder
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Builder(0,0, inorder.Length - 1, preorder, inorder );
        }

        private TreeNode Builder(int prestart, int start
        , int end, int[] preOrder, int[] inOrder)
        {
            if(prestart >= preOrder.Length || start > end )
                return null;

            var root = new TreeNode(preOrder[prestart]);
            var indexOfRootInInOrder = Array.IndexOf(inOrder, root.val);
            root.left = Builder(prestart + 1
            , start
            , indexOfRootInInOrder -1, preOrder, inOrder);

            root.right = Builder(prestart + indexOfRootInInOrder - start + 1
            , indexOfRootInInOrder + 1
            , inOrder.Length - 1, preOrder, inOrder);

            return root;

        }

    }
}