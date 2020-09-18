using System;
using System.Collections.Generic;

public class PacificAtlanticWaterFlow
{

    public IList<IList<int>> PacificAtlantic(int[][] matrix)
    {

        var result = new List<IList<int>>();
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return result;
        }
        
        var pacificLookup = new bool[matrix.Length][];
        var atlanticLookup = new bool[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            pacificLookup[i] = new bool[matrix[0].Length];
            atlanticLookup[i] = new bool[matrix[0].Length];
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            IsConnectingOceans(i, 0, matrix, pacificLookup, int.MinValue);
            IsConnectingOceans(i, matrix[0].Length - 1, matrix, atlanticLookup, int.MinValue);
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            IsConnectingOceans(0, i, matrix, pacificLookup, int.MinValue);
            IsConnectingOceans(matrix.Length - 1, i, matrix, atlanticLookup, int.MinValue);
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (pacificLookup[i][j] && atlanticLookup[i][j])
                    result.Add(new List<int> { i, j });
            }
        }
        return result;
    }

    private void IsConnectingOceans(int row, int col, int[][] matrix
    , bool[][] visited, int prevHeight)
    {

        if (row < 0 || row >= matrix.Length
        || col < 0 || col >= matrix[0].Length
        || visited[row][col]
        || matrix[row][col] < prevHeight)
            return;

        visited[row][col] = true;
        int height = matrix[row][col];
        //left
        IsConnectingOceans(row, col - 1, matrix, visited, height);

        //right
        IsConnectingOceans(row, col + 1, matrix, visited, height);

        //up
        IsConnectingOceans(row - 1, col, matrix, visited, height);

        //down
        IsConnectingOceans(row + 1, col, matrix, visited, height);

    }
}