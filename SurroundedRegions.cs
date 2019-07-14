namespace Hackerrank
{
    public class SurroundedRegions
    {
        public void Solve(char[][] board)
        {
            if(board.Length == 0)
                return ;
                
            for(int i = 0; i < board.Length; i++)
            {
                if(board[i][0] == 'O')
                    MarkAsBorder(i,0,board);

                if(board[i][board[0].Length - 1] == 'O')
                    MarkAsBorder(i,board[0].Length - 1,board);
            }

            for(int i = 0; i < board[0].Length; i++)
            {
                if(board[0][i] == 'O')
                    MarkAsBorder(0,i,board);

                if(board[board.Length - 1][i] == 'O')
                    MarkAsBorder(board.Length - 1,i,board);
            }


            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    else if(board[i][j] == '*')
                        board[i][j] = 'O';
                }
            }
        }

        private void MarkAsBorder(int i, int j, char[][] board)
        {
            if (i < 0 || i > board.Length - 1 || j < 0 || j > board[0].Length - 1)
            {
                return ;
            }

            if (board[i][j] == 'X'|| board[i][j] == '*')
            {
                return ;
            }

            if (board[i][j] == 'O')
            {
                board[i][j] = '*';
            }

            MarkAsBorder(i + 1, j, board);  //BOTTOM
            MarkAsBorder(i - 1, j, board);  //TOP      
            MarkAsBorder(i, j + 1, board);  //RIGHT
            MarkAsBorder(i, j - 1, board);  //LEFT
        }
    }
}