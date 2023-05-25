using System;

namespace Assessment {
    class Program {
        static void Main(string[] args)
        {
            int[, ] grid = setupGrid();
            Print2DArray(grid);
            Console.WriteLine(NoOfIsland(grid));
        }

        public static int[, ] setupGrid()
        {
            int m = 0;
            int n = 0;
            int noOfRows = 0;
            int noOfColumns = 0;

            while(m == 0)
            {
                Console.WriteLine("Enter the number of rows in your map grid:");
                noOfRows = Convert.ToInt32(Console.ReadLine ());
                if (noOfRows < 1)
                {
                    Console.WriteLine("The number of rows in a map grid should be greater than zero!");
                }
                else
                {
                    m = noOfRows;
                }
            }

            while(n == 0)
            {
                Console.WriteLine("Enter the number of columns in your map grid:");
                noOfColumns = Convert.ToInt32(Console.ReadLine());
                if (noOfColumns < 1)
                {
                    Console.WriteLine("The number of columns in a map grid should be greater than zero!");
                }
                else if (noOfColumns > 300)
                {
                    Console.WriteLine("The number of columns in a map grid should be less than 301!");
                }
                else
                {
                    n = noOfColumns;
                }
            }

            Console.WriteLine("It's time to pass your grid to the app. Enter '0' for a water location and '1' for a land location. Any other characters will be considered as a land!");

            int[, ] grid = new int[m,n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.WriteLine($"Enter the location code for item in row number {i} and column number {j}:");
                    int location = Convert.ToInt32(Console.ReadLine());
                    if (location == 0)
                    {
                        grid[i, j] = location;
                    }
                    else
                    {
                        grid[i, j] = 1;
                    }
                }
            }
            return grid;
        }

        public static void Print2DArray<T> (T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int NoOfIsland(int[, ] grid)
        {
            int output = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            output += FindSingleLandIslands(grid);
            output += FindMultiLandsIslands(grid);
            return output;
        }

        public static int FindSingleLandIslands(int[, ] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int result = 0;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    // count the number of water locations around a land location
                    int noOfWaterLocations = 0;

                    // first row
                    if (i == 0)
                    {
                        noOfWaterLocations += 1;
                        if (grid[i+1, j] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }
                    // last row
                    else if (i == m)
                    {
                        noOfWaterLocations += 1;
                        if (grid[i-1, j] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }
                    // other rows
                    else
                    {
                        if (grid[i+1, j] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                        if (grid[i-1, j] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }

                    // first column
                    if (j == 0)
                    {
                        noOfWaterLocations += 1;
                        if (grid[i, j+1] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }
                    // last column
                    else if (j == n)
                    {
                        noOfWaterLocations += 1;
                        if (grid[i, j-1] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }
                    // other columns
                    else
                    {
                        if (grid[i, j+1] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                        if (grid[i, j-1] == 0)
                        {
                            noOfWaterLocations += 1;
                        }
                    }

                    // check if the current item is an island location:
                    if (noOfWaterLocations == 4)
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        public static int FindMultiLandsIslands(int[, ] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int result = 0;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                }
            }

            return result;
        }
    }
}
