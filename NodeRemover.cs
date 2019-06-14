namespace Hackerrank
{
    public class NodeRemover
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int linkLength = 1;
            ListNode iterator = head;
            while(iterator.next != null)
            {
                linkLength++;
                iterator = iterator.next;
            }
            
            var nodeToDelete = linkLength - n;
            ListNode result = null;
            var currentNode = 1;
            while(head.next != null)
            {
                if(nodeToDelete == 0)
                {
                    result = head.next;
                    break;
                }
                else if(currentNode == 1)
                {
                    result = head;
                }
                
                if(currentNode == nodeToDelete)
                {
                    head.next = head.next.next;
                    break;
                }

                currentNode++;
                head = head.next;
            }
        
            return result;
        }
    }
}