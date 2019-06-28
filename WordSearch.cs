using System.Collections.Generic;

namespace Hackerrank
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            for(int row = 0; row < board.Length; row++)
            {
                for(int column = 0; column < board[0].Length ; column++)
                {
                    if(board[row][column] == word[0] 
                    && CheckWord(board, word, row, column, 0))
                        return true;
                }
            }
            return false;
        }

        private bool CheckWord(char[][] board, string word, int row, int column, int lookupPos)
        {
            if(word.Length == lookupPos)
                return true;

            if(row >= board.Length || column >= board[0].Length
                || row < 0 || column < 0)
                return false;
            
            if(board[row][column] == word[lookupPos])
            {
                var temp = board[row][column];
                board[row][column] = '0';

                //Left
                if(CheckWord(board, word, row, column - 1, lookupPos + 1))
                    return true;

                //Right
                if(CheckWord(board, word, row, column + 1, lookupPos + 1))
                    return true;         

                //Top
                if(CheckWord(board, word, row - 1, column , lookupPos + 1))
                    return true;

                //Bottom
                if(CheckWord(board, word, row + 1, column , lookupPos + 1))
                    return true;

                board[row][column] = temp;
            }

            return false;
        }

    }
}