using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = 5;
            var cols = 5;
            var grid = new int[,]
            {
                {0,1,0,0,0},
                {1,1,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,1},
                {0,0,1,1,0}
            };
            var newGrid = new int[rows, cols];
            Console.WriteLine(checkNeighbors(grid, 3, 3, rows, cols));
        }

        private static int checkNeighbors(int[,] grid, int row, int col, int rows, int cols)
        {
            var liveNeighbors = 0;

            if(row > 0 && grid[row - 1, col] == 1) { liveNeighbors++; } //12 oclock
            if (row > 0 && col < cols - 1 && grid[row - 1, col + 1] == 1) { liveNeighbors++; }
            if (col < cols - 1 && grid[row, col + 1] == 1) { liveNeighbors++; } //3 oclock
            if (row < rows - 1 && col < cols - 1 && grid[row + 1, col + 1] == 1) { liveNeighbors++; }
            if (row < rows - 1 && grid[row + 1, col] == 1) { liveNeighbors++; } //6 oclock
            if (row < rows - 1 && col > 0 && grid[row + 1, col - 1] == 1) { liveNeighbors++; }
            if (col > 0 && grid[row, col - 1] == 1) { liveNeighbors++; } //9 oclock
            if (row > 0 && col > 0 && grid[row - 1, col - 1] == 1) { liveNeighbors++; }

            return liveNeighbors;
        }
    }
}
