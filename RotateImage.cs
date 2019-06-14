namespace Hackerrank
{
    public class RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            var rows = matrix.Length;
            var columns = matrix[0].Length;

            var result = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                result[row] = new int[columns];
            }

            for (int i = 0, k = columns - 1; i < rows; i++, k--)
            {

                for (int j = 0; j < columns; j++)
                {
                    result[j][k] = matrix[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = result[i][j];
                }
            }

        }
    }
}