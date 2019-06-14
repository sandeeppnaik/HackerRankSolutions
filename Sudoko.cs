using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public class Sudoko
    {
        public bool IsValidSudoku(char[][] board)
        {
            int x = 3;
            while (x < 10)
            {
                var uniqueItems = new HashSet<char>();
                var uniqueItems1 = new HashSet<char>();
                var uniqueItems2 = new HashSet<char>();

                for (int i = x - 3; i < x; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i][j] != '.')
                        {
                            if (!uniqueItems.Add(board[i][j]))
                                return false;
                        }
                    }

                    for (int j = 3; j < 6; j++)
                    {
                        if (board[i][j] != '.')
                        {
                            if (!uniqueItems1.Add(board[i][j]))
                                return false;
                        }
                    }

                    for (int j = 6; j < 9; j++)
                    {
                        if (board[i][j] != '.')
                        {
                            if (!uniqueItems2.Add(board[i][j]))
                                return false;
                        }
                    }
                }
                x = x + 3;
            }

            for (int i = 0; i < 9; i++)
            {
                var uniqueItem = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        if (!uniqueItem.Add(board[i][j]))
                        {
                            return false;
                        }
                    }
                }

                var uniqueItem1 = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    if (board[j][i] != '.')
                    {
                        if (!uniqueItem1.Add(board[j][i]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}