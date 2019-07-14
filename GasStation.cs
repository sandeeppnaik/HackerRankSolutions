using System.Collections.Generic;

namespace Hackerrank
{
    public class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost) 
        {
            if(gas.Length == 1)
                return gas[0] >= cost[0] ? 0 : -1;

            int canComplete = -1;
            var gasqueue = new Queue<int>(gas);
            var costqueue = new Queue<int>(cost);

            for(int i = 0; i < gas.Length; i++)
            {
                if(cost[i] < gas[i])
                {
                    canComplete = CheckCircuit(gasqueue.ToArray(), costqueue.ToArray());
                    if(canComplete != -1)
                        return i;
                }

                var gasitem = gasqueue.Dequeue();
                gasqueue.Enqueue(gasitem);

                var costitem = costqueue.Dequeue();
                costqueue.Enqueue(costitem);
            }

            return canComplete;
        }

        private int CheckCircuit(int[] gas, int[] cost)
        {
            var initialGas = gas[0];
            for(int j = 0 ; j < gas.Length ; j++)
            {
                if(cost[j] > initialGas)
                    return -1;

                if(j < gas.Length - 1)
                    initialGas = initialGas + gas[j+1] - cost[j];
            }

            return 0;
        }
    }
}