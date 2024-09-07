// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var n = 2;
var board = new int[n,n];

if (SolverQueenPuzzle(board, 0, n))
    PrintBoard(board, n);
else
    Console.WriteLine($"Nao tem solucão para N = {n}.");

Console.WriteLine("Finished");

static bool SolverQueenPuzzle(int[,] board, int column, int length)
{
    if (column >= length) return true;

    for (var i = 0; i < length; i++)
    {
        if (IsSafe(board, i, column, length))
        {
            board[i, column] = 1;

            if (SolverQueenPuzzle(board, column + 1, length))
                return true;
            
            board[i, column] = 0;
        }
    }
    
    return false;

    static bool IsSafe(int[,] board, int row, int column, int length)
    {
        for (var i = 0; i < column; i++)
            if (board[row, i] == 1)
                return false;

        for (int i = row, j = column; i >=0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;
        
        for (int i = row, j = column; i < length && j >= 0; i++, j--)
            if (board[i, j] == 1)
                return false;
        
        return true;
    }
}

static void PrintBoard(int[,] board, int length)
{
    for (var i = 0; i < length; i++)
    {
        for (var j = 0; j < length; j++)
        {
            if (board[i, j] == 1)
                Console.Write("Q ");
            else
                Console.Write(". ");
        }
        
        Console.WriteLine();
    }
}