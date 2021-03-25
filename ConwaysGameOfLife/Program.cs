using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static int Rows = 5;
        static int Cols = 5;

        static void Main(string[] args)
        {
            var grid = new int[,]
            {
                {0,0,0,0,0},
                {0,1,0,1,0},
                {0,0,1,1,0},
                {0,0,1,0,0},
                {0,0,0,0,0}
            };
            var newGrid = new int[Rows, Cols];

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    if (grid[i, j] == 1 && checkNeighbors(grid, i, j) < 2) //live cell with fewer than 2 neighbors dies
                    {
                        newGrid[i, j] = 0;
                    }
                    else if (grid[i, j] == 1 && (checkNeighbors(grid, i, j) == 2 || checkNeighbors(grid, i, j) == 3)) //live cell with two or three neighbors lives on
                    {
                        newGrid[i, j] = 1;
                    }
                    else if (grid[i, j] == 1 && checkNeighbors(grid, i, j) > 3) //live cell with more than 3 neighbors dies
                    {
                        newGrid[i, j] = 0;
                    }
                    else if (grid[i, j] == 0 && checkNeighbors(grid, i, j) == 3) //dead cell with exactly 3 neighbors becomes alive
                    {
                        newGrid[i, j] = 1;
                    }
                }
            }

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    Console.Write(newGrid[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        private static int checkNeighbors(int[,] grid, int row, int col)
        {
            var liveNeighbors = 0;

            if(row > 0 && grid[row - 1, col] == 1) { liveNeighbors++; } //12 oclock
            if (row > 0 && col < Cols - 1 && grid[row - 1, col + 1] == 1) { liveNeighbors++; }
            if (col < Cols - 1 && grid[row, col + 1] == 1) { liveNeighbors++; } //3 oclock
            if (row < Rows - 1 && col < Cols - 1 && grid[row + 1, col + 1] == 1) { liveNeighbors++; }
            if (row < Rows - 1 && grid[row + 1, col] == 1) { liveNeighbors++; } //6 oclock
            if (row < Rows - 1 && col > 0 && grid[row + 1, col - 1] == 1) { liveNeighbors++; }
            if (col > 0 && grid[row, col - 1] == 1) { liveNeighbors++; } //9 oclock
            if (row > 0 && col > 0 && grid[row - 1, col - 1] == 1) { liveNeighbors++; }

            return liveNeighbors;
        }
    }
}
