namespace Hackerrank
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            var totalIslands = 0;
            var visited = new bool[grid.Length][];
            for(int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[i].Length];
            }

            for(int i = 0 ; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[0].Length; j++)
                {
                    if(grid[i][j] == '1' && visited[i][j] == false)
                    {
                        IsIsland(i , j , grid, visited);
                        totalIslands += 1;
                    }
                }
            }
            return totalIslands;
        }

        private void IsIsland(int i , int j , char[][] grid, bool[][] visited)
        {
            if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
                return;

            if(grid[i][j] == '0')
            {
                return;
            }
            else if(grid[i][j] == '1' && visited[i][j] == true)
            {
                return;
            }
            else
            {
                visited[i][j] = true;
                IsIsland(i + 1, j, grid, visited); // bottom
                IsIsland(i - 1, j, grid, visited); // top
                IsIsland(i , j + 1, grid, visited); // right
                IsIsland(i , j - 1, grid, visited); // left
            }
        }
    }
}