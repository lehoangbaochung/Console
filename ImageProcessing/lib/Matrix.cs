namespace lib;

internal static class Matrix
{
    public static bool isSquare(this int[,] matrix) 
        => Math.Sqrt(matrix.Length) == (int)Math.Sqrt(matrix.Length);

    public static int GetCenterIndex(this int[,] matrix)
    {
        if (!matrix.isSquare())
        {
            throw new Exception("The matrix is not square");
        }
        return (int)Math.Round(matrix.Length / 2d);
    }

    public static int GetCenterValue(this int[,] matrix)
    {
        if (!matrix.isSquare())
        {
            throw new Exception("The matrix is not square");
        }
        var index = (int)Math.Floor(matrix.GetLength(0) / 2d);
        return matrix[index, index];
    }

    public static int[,] GetNeighborMatrix(this int[,] matrix, int index) 
    {
        var mtx = matrix;
        return matrix;
    }

    public static void Print(this int[,] matrix)
    {
        var columnCount = matrix.GetLength(1);
        var columnIndex = 0;
        var rowIndex = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            rowIndex = i / columnCount;
            columnIndex = i % columnCount;
            Console.Write(matrix[rowIndex, columnIndex] + " ");
            if (columnIndex == columnCount - 1) Console.Write("\n");
        }
    }
}