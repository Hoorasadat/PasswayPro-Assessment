using System;

namespace Assessment {
    class Program {
        static void Main(string[] args)
        {
            // string [,] grid = {
            //     {"1","1","1","1","0"},
            //     {"1","1","0","1","0"},
            //     {"1","1","0","0","0"},
            //     {"0","0","0","0","0"}
            // };

            string [,] grid = {
                {"1","1","0","0","0"},
                {"1","1","0","0","0"},
                {"0","0","1","0","0"},
                {"0","0","0","1","1"}
            };

            // string[, ] grid = setupGrid();
            Print2DArray(grid);
            Console.WriteLine("Number of Islands: " + NoOfIsland(grid));
        }

        public static string[,] setupGrid()
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

            string[,] grid = new string[m,n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.WriteLine($"Enter the location code for item in row number {i} and column number {j}:");
                    string? location = Console.ReadLine();
                    if (location == "0")
                    {
                        grid[i,j] = location;
                    }
                    else
                    {
                        grid[i,j] = "1";
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

        public static int NoOfIsland(string[,] grid)
        {
            int output = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            List <int[]> checkedLocationsArray = new List <int[]> ();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i,j] == "1")
                    {
                        int[] location = new int[] { i, j };
                        // see if the location was checked before:
                        bool isLocationChecked = CheckLocation(location, checkedLocationsArray);
                        // add location to checkedLocationsArray if not checked before:
                        if (!isLocationChecked)
                        {
                            checkedLocationsArray.Add(location);
                            checkedLocationsArray = FindLandsAround(m, n, location, checkedLocationsArray, grid);
                            output += 1;

                        }
                    }
                }
            }
            // foreach (var res in checkedLocationsArray)
            // {
            //     Console.WriteLine(string.Join(",", res));
            // }
            return output;
        }

        public static List <int[]> FindLandsAround(int m, int n, int[] location, List <int[]> checkedLocationsArray, string[,] grid)
        {
            int[,] neighbors = CreateNeighboursList(location);
            for(int k = 0; k < neighbors.GetLength(0); k++)
            {
                int[] neighbor = { neighbors[k,0], neighbors[k,1] };
                int i = neighbor[0];
                int j = neighbor[1];
                if((i >= 0 && i < m) && (j >= 0 && j < n))
                {
                    if ((grid[i,j] == "1") && !CheckLocation(neighbor, checkedLocationsArray))
                    {
                        // add location to checkedLocationsArray if not checked before:
                        checkedLocationsArray.Add(neighbor);
                        FindLandsAround(m, n, neighbor, checkedLocationsArray, grid);
                    }
                }
            }
            return checkedLocationsArray;
        }

        public static bool CheckLocation(int[] location, List <int[]> checkedLocations)
        {
            bool isChecked = checkedLocations.Any(item => (item[0] == location[0] && item[1] == location[1]));
            return isChecked;
        }

        public static int[,] CreateNeighboursList(int[] location)
        {
            int i = location[0];
            int j = location[1];
            int[,] neighboursList = new int[,] {
                {i, j+1},
                {i, j-1},
                {i+1, j},
                {i-1, j},
            };
            return neighboursList;
        }
    }
}
