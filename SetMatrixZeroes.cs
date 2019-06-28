using System.Collections.Generic;

namespace Hackerrank
{
    public class SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix) 
        {
            var columnLookup = new HashSet<int>();
            var rowLookup = new HashSet<int>();

            int row = matrix.Length;
            int column = matrix[0].Length;

            for(int i = 0; i < row; i++ )
            {
                for(int j = 0; j < column; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        if(!rowLookup.Contains(i))
                            rowLookup.Add(i);
                        if(!columnLookup.Contains(j))
                            columnLookup.Add(j);
                    }
                }
            }

            foreach(var r in rowLookup)
            {
                for(int j = 0; j < column; j++)
                {
                    matrix[r][j] = 0;
                }
            } 

            foreach(var c in columnLookup)
            {
                for(int i = 0; i < row; i++)
                {
                    matrix[i][c] = 0;
                }
            }   

        }
    }
}