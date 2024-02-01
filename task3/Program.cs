// See https://aka.ms/new-console-template for more information
using System;

class A
{
    static bool IsSafe(int[,] board, int row, int col)
    {
        int n = board.GetLength(0);

        
        for (int i = 0; i < n; i++)
        {
            if (board[row, i] == 1)
                return false;
        }

        
        for (int i = 0; i < n; i++)
        {
            if (board[i, col] == 1)
                return false;
        }

        
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == 1)
                return false;
        }

        for (int i = row, j = col; i < n && j < n; i++, j++)
        {
            if (board[i, j] == 1)
                return false;
        }

        for (int i = row, j = col; i < n && j >= 0; i++, j--)
        {
            if (board[i, j] == 1)
                return false;
        }

        for (int i = row, j = col; i >= 0 && j < n; i--, j++)
        {
            if (board[i, j] == 1)
                return false;
        }

        return true;
    }

    static bool PlaceQueens(int[,] board, int col)
    {
        int n = board.GetLength(0);
        if (col >= n)
            return true;

        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            if (IsSafe(board, i, col))
            {
                board[i, col] = 1;

                if (PlaceQueens(board, col + 1))
                    return true;

                board[i, col] = 0;
            }
        }

        return false;
    }

    static void PrintBoard(int[,] board)
    {
        int n = board.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] board = new int[8, 8];
        PlaceQueens(board, 0);
        PrintBoard(board);
    }
}
