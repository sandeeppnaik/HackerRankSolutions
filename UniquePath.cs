namespace Hackerrank
{
    public class UniquePath
    {
        public int UniquePaths(int m, int n)
        {
            var lookup = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                lookup[i, 0] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                lookup[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    lookup[i, j] = lookup[i - 1, j] + lookup[i, j - 1];
                }
            }

            return lookup[m - 1, n - 1];
        }

        public int ClimbStairs(int n)
        {

            if (n == 1)
                return 1;

            if (n == 2)
                return 2;

            var lookup = new int[n+1];
            lookup[0] = 1;
            lookup[1] = 1;
            lookup[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                lookup[i] = lookup[i-1] + lookup[i-2];
            }

            return lookup[n];
        }
    }
}