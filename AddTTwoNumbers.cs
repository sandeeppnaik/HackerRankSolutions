namespace Hackerrank
{
    public class ListNode 
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
   }

    public class AddTTwoNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
        
            ListNode result = null;
            var carryForward = 0;
            ListNode tail = null;

            while(l1 != null || l2 != null)
            {
                if(l1 != null && l2 != null)
                {
                    var sum = l1.val + l2.val + carryForward;
                    carryForward = sum / 10;
                    if(result == null)
                    {
                        result = new ListNode(sum % 10);
                        tail = result;
                    }
                    else 
                    {
                        tail.next = new ListNode(sum % 10);
                        tail = tail.next;
                    }
                }

                else if(l1 == null && l2 != null)
                {
                    var sum = l2.val + carryForward;
                    carryForward = sum / 10;
                    tail.next = new ListNode(sum % 10);
                    tail = tail.next;
                }

                else if(l1 != null && l2 == null)
                {
                    var sum = l1.val + carryForward;
                    carryForward = sum / 10;
                    tail.next = new ListNode(sum % 10);
                    tail = tail.next;
                }

                if(l1 != null)
                    l1 = l1.next;

                if(l2 != null)
                    l2 = l2.next;

            }

            if(carryForward != 0)
            {
                tail.next = new ListNode(carryForward);
            }
        
            return result;
        }
    }
}