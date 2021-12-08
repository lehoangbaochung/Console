namespace src;
using lib;

internal static class Histogram
{
    /// <summary>
    /// Cân bằng Histogram của ảnh với mức xám mới cho trước
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <param name="grayLevel">Mức xám mới cần cân bằng</param>
    public static void Equalize(ref int[,] matrix, int grayLevel)
    {
        // Initialize a dictionary with r is key and n, cdf, s are values
        var equalizations = new SortedDictionary<int, int[]>();
        // Tính toán số lượng pixel cần cân bằng so với mức xám mới
        var equalizerSize = grayLevel;
        foreach (var value in matrix) if (value > equalizerSize) equalizerSize = value + 1;
        // Thống kê số lượng các pixel n tương ứng đối với từng mức xám r
        for (var i = 0; i < equalizerSize; i++)
        {
            foreach (var value in matrix)
            {
                // Nếu pixel trong ma trận là pixel cần cân bằng
                if (value == i)
                {
                    if (equalizations.ContainsKey(i))
                        equalizations[i][0] += 1;
                    else
                        equalizations.Add(i, new int[3] { 1, 0, 0 });
                }
            }
        }
        // Sắp xếp lại các pixel theo thứ tự tăng dần
        equalizations.OrderBy(e => e.Key);
        var currentCdf = 0.0;
        var minCdf = equalizations.First().Value[0];
        foreach (var equalizer in equalizations)
        {
            // Tính các hàm phân bố tĩch lũy cho (cdf) các điểm ảnh có mức xám nhỏ hơn hoặc bằng k
            currentCdf += equalizations[equalizer.Key][0];
            equalizations[equalizer.Key][1] = (int)currentCdf;
            // Tính giá trị các pixel mới s theo công thức sau
            equalizations[equalizer.Key][2] = 
                (int)Math.Round((((currentCdf - minCdf) / (matrix.Length - minCdf))) * (grayLevel - 1));
        }
        Console.WriteLine("Qua trinh bien doi:");
        equalizations.Print();
        // Thay thế các pixel cũ trong ma trận bằng pixel mới
        var columnCount = matrix.GetLength(1);
        var columnIndex = 0;
        var rowIndex = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            rowIndex = i / columnCount;
            columnIndex = i % columnCount;
            matrix[rowIndex, columnIndex] = equalizations[matrix[rowIndex, columnIndex]][2];  
        }
    }

    public static void Print(this SortedDictionary<int, int[]> dictionary)
    {
        var keys = string.Empty;
        var n = "";
        var cdf = "";
        var s = "";
        foreach (var key in dictionary.Keys)
        {
            keys += key + " ";
            n += dictionary[key][0] + " ";
            cdf += dictionary[key][1] + " ";
            s += dictionary[key][2] + " ";
        }
        Console.WriteLine(keys);
        Console.WriteLine(n);
        Console.WriteLine(cdf);
        Console.WriteLine(s);
    }
  
    public static void G(int[] grayLevels)
    {
        var matrix = new int[,]
        {
            { 2, 3, 3, 2 },
            { 4,2,4,3 },
            { 3,2,3,5 },
            { 2,4,2,4 },
        };
        Console.WriteLine("Truoc khi bien doi:");
        matrix.Print();
        Histogram.Equalize(ref matrix, 4);
        Console.WriteLine("Sau khi bien doi:");
        matrix.Print();
    }
}