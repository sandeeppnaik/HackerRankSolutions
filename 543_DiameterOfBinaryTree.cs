using System;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTreeDiameter
{
    int result = 0;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        MaxDepth(root);
        return result;
    }

    private int MaxDepth(TreeNode node)
    {
        if(node == null)
            return 0;

        var left = MaxDepth(node.left);
        var right = MaxDepth(node.right);

        result = Math.Max(result, left + right );

        return Math.Max(left, right) + 1;

    }

}