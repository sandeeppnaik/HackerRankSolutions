using System.Collections.Generic;

namespace Hackerrank
{
    public class ZigZagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
        {
            var result = new List<IList<int>>();

            if(root == null)
                return result;

            var q = new Queue<TreeNode>();
            var s = new Stack<TreeNode>();
            q.Enqueue(root);
            bool switchLeftToRight = true;

            while(q.Count != 0)
            {
                var length = q.Count ;

                var nestedList = new List<int>();
                for(int i = 0; i < length; i++)
                {
                    var item = q.Dequeue();
                    if(item != null)
                    {
                        if(!switchLeftToRight)
                        {
                            var sitem= s.Pop();
                            nestedList.Add(sitem.val);
                        }
                        else
                        {
                            nestedList.Add(item.val);
                        }

                        if(item.left != null)
                            q.Enqueue(item.left);
    
                        if(item.right != null)
                            q.Enqueue(item.right);

                        if(switchLeftToRight)
                        {
                            if(item.left != null)
                                s.Push(item.left);

                            if(item.right != null)
                                s.Push(item.right);
                        }
                    }

                }

                result.Add(nestedList);

                switchLeftToRight = !switchLeftToRight;
            }

            return result;
        
        }
    }
}