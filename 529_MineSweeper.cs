using System.Collections.Generic;

public class Minesweeper
{
    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        var queue = new Queue<int[]> { };
        var visited = new bool[board.Length][];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = new bool[board[0].Length];
        }

        queue.Enqueue(click);
        while (queue.Count != 0)
        {
            var item = queue.Dequeue();
            var row = item[0];
            var column = item[1];

            if (row < 0 || row >= board.Length || column < 0 || column >= board[0].Length
            || visited[row][column])
                continue;

            if (board[row][column] == 'M')
            {
                board[row][column] = 'X';
                break;
            }

            var countOfAdjacentMines = CountAdjacentMines(board, row, column);
            if (countOfAdjacentMines != 0)
            {
                board[row][column] = (char)(countOfAdjacentMines + '0');
                visited[row][column] = true;
            }
            else
            {
                board[row][column] = 'B';
                visited[row][column] = true;
                // enqueue
                queue.Enqueue(new int[] { row + 1, column });
                queue.Enqueue(new int[] { row + 1, column + 1 });
                queue.Enqueue(new int[] { row, column + 1 });
                queue.Enqueue(new int[] { row - 1, column + 1 });
                queue.Enqueue(new int[] { row - 1, column });
                queue.Enqueue(new int[] { row - 1, column - 1 });
                queue.Enqueue(new int[] { row, column - 1 });
                queue.Enqueue(new int[] { row + 1, column - 1 });
            }
        }

        return board;
    }

    private int CountAdjacentMines(char[][] board, int row, int column)
    {
        var count = 0;
        int[] r = new int[]{1,1,0,-1,-1,-1,0,1};
        int[] c = new int[]{0,1,1,1,0,-1,-1,-1};

        for(int x = 0, y = 0; x < r.Length; x++, y++)
        {
            var tempR= row + r[x];
            var tempC = column + c[y];
            if (tempR < 0 || tempR >= board.Length || tempC < 0 || tempC >= board[0].Length)
                continue;
            
            else if(board[tempR][tempC] == 'X' || board[tempR][tempC] == 'M')
            {
                count++;
            }
        }
        return count;
    }
}