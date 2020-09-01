using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace working_sudoku
{
    class DrawBoard
    {
        public static int[,] board =
        {
                { 7, 8, 0, 4, 0, 0, 1, 2 ,0},
                { 6, 0, 0, 0, 7, 5, 0, 0, 9},
                { 0, 0, 0, 6, 0, 1, 0, 7, 8},
                { 0, 0, 7, 0, 4, 0, 2, 6, 0},
                { 0, 0, 1, 0, 5, 0, 9, 3, 0},
                { 9, 0, 4, 0, 6, 0, 0, 0, 5},
                { 0, 7, 0, 3, 0, 0, 0, 1, 2},
                { 1, 2, 0, 0, 0, 7, 4, 0, 0},
                { 0, 4, 9, 2, 0, 6, 0, 0, 7}
        };

        public void Draw(int col, int row)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i % 3 == 0 & i != 0)
                    Console.WriteLine("-----------");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                   
                    if (j % 3 == 0 & j != 0)
                        Console.Write("|");
                    if (col == j & row == i)
                        Console.Write("@");
                    else
                    Console.Write(board[i, j].ToString());
                }
                Console.WriteLine();

            }
        }

        public bool Solve()
        {
            int[] empty = FindEmpty();
            if (empty == null)
                return true;

            for (int i = 1; i < 10; i++)
            {
                if (check(empty[1], empty[0], i))
                {
                    board[empty[0], empty[1]] = i;
                    if (Solve())
                        return true;
                    board[empty[0], empty[1]] = 0;
                }

            }
            return false;

        }

        int[] FindEmpty()
        {
            int[] EmptySpaceLocation = new int[2];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i,j] == 0)
                    {
                        EmptySpaceLocation[0] = i;
                        EmptySpaceLocation[1] = j;

                        return EmptySpaceLocation;
                    }

                }
            }
            return null;
        }

        public bool check(int col, int row, int num)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row, i] == num)
                    return false;
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[i, col] == num)
                    return false;
            }

            for (int i = row/3*3; i < row / 3 * 3 + 3; i++)
            {
                for (int j = col/3*3; j < col/3*3+3; j++)
                {
                    if(board[i,j] == num)
                    return false;
                }

            }
            return true;

        }

    }
}
