using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            // var result = new MaximumProductSubArray()
            //                 // .MaxProduct( new int[]{2, 3, -2, 4} );
            //                 // .MaxProduct( new int[]{-2, 0, -1} );
            //                 // .MaxProduct( new int[]{2, 3, -2, -4} );
            //                 .MaxProduct( new int[]{-4, -3, -2} );

            // var result = new PeakElement().FindPeakElement(new int[]{1,2,3,1});

            // var result = new FractionToRecurringDecimal().FractionToDecimal(-2147483648,-1);

            // var result = new LargestNumberCalculator().LargestNumber(new int[]{3,30,34,5,9});

            // var result = new LargestNumberCalculator().LargestNumber(new int[]{3,30,9,5,34});

            var grid = new char[4][]
            {
                new char []{'1','1','0','0','0'},
                new char []{'1','1','0','0','0'},
                new char []{'0','0','1','0','0'},
                new char []{'0','0','0','1','1'},
            };

            var result = new NumberOfIslands().NumIslands(grid);
        }
    }
}
