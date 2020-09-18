using System.Collections.Generic;

public class Minesweeper
{
    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        var queue = new Queue<int[]> { };
        queue.Enqueue(click);
        while (queue.Count != 0)
        {
            var item = queue.Dequeue();
            var row = item[0];
            var column = item[1];

            if (row < 0 || row >= board.Length || column < 0 || column >= board[0].Length)
                continue;

            if (board[row][column] == 'M')
            {
                board[row][column] = 'X';
                break;
            }
            else if (board[row][column] != 'M' || board[row][column] != 'E')
            {
                continue;
            }

            int i = 4;
            while(i > 0)
            {
                // if()
            }


            // enqueue
            queue.Enqueue(new int[] { row + 1, column });
            queue.Enqueue(new int[] { row - 1, column });
            queue.Enqueue(new int[] { row, column + 1 });
            queue.Enqueue(new int[] { row, column - 1 });

            board[row][column] = 'B';
        }

        return board;
    }
}