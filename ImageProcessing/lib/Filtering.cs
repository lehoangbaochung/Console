namespace lib;

internal static class Filtering
{
    public static int[,] Median(this int[,] matrix, int maskSize = 9) {
        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);
        var resultMatrix = new int[width, height];
        var medianMatrix = new int[maskSize];
        for (var i = 1; i < width - 1; i++) 
        {
            for (var j = 1; j < height - 1; j++)
            {
                // row 1
                medianMatrix[0] = matrix[i - 1, j - 1];
                medianMatrix[1] = matrix[i - 1, j];
                medianMatrix[2] = matrix[i - 1, j + 1];
                // row 2
                medianMatrix[3] = matrix[i, j - 1];
                medianMatrix[4] = matrix[i, j];
                medianMatrix[5] = matrix[i, j + 1];
                // row 2
                medianMatrix[6] = matrix[i + 1, j - 1];
                medianMatrix[7] = matrix[i + 1, j];
                medianMatrix[8] = matrix[i + 1, j + 1];
                // sort
                Array.Sort(medianMatrix);
                // median filter
                resultMatrix[i, j] = medianMatrix[4];
            }
        } new List<int>().Find(c => (c == 1));
        return resultMatrix;
    }
}