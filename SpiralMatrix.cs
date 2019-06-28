using System.Collections.Generic;

namespace Hackerrank
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix.Length == 0)
                return result;

            int i = 0;
            int j = 0;
            int maxJ = matrix[0].Length - 1;
            int maxI = matrix.Length - 1;

            var visited = new bool[maxI + 1, maxJ + 1];
            int iteration = 0;
            while (maxI >= 0)
            {
                while (i + iteration <= maxI && j >= 0 && j <= maxJ)
                {
                    if (visited[i + iteration, j] != true)
                    {
                        result.Add(matrix[i + iteration][j]);
                    }

                    visited[i + iteration, j] = true;
                    j++;
                }

                j--;
                while (j >= 0 && j <= maxJ && i <= maxI)
                {
                    if (visited[i + iteration, j] != true)
                    {
                        result.Add(matrix[i + iteration][j]);
                    }

                    visited[i + iteration, j] = true;
                    i++;
                }

                i--;
                while (j >= iteration && i >= 0 && i <= maxI)
                {
                    if (visited[i, j] != true)
                    {
                        result.Add(matrix[i][j]);
                    }

                    visited[i, j] = true;
                    j--;
                }

                j++;
                while (i >= iteration && j >= 0 && j <= maxI)
                {
                    if (visited[i, j] != true)
                    {
                        result.Add(matrix[i][j]);
                    }

                    visited[i, j] = true;
                    i--;
                }

                i = 0; j = 0;
                iteration++;
                maxI--;
                maxJ--;
            }

            return result;
        }
    }
}