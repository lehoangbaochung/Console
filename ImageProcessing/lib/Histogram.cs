namespace lib;

/// <summary>
/// Histogram của một ảnh với mức xám trong khoảng từ [0, L-1]
/// là một hàm rời rạc h(rk) = nk, trong đó rk là mức xám thứ k
/// và nk là số lượng pixel trong ảnh có mức xám rk.
/// Histogram là một đồ thị biểu diễn độ sáng của một bức ảnh
/// với trục hoành là độ sáng và trục tung là số lượng điểm ảnh ở
/// độ sáng tương ứng. Chiều cao của các cột trên đồ thị cũng thể
/// hiện số lượng pixel ở mức sáng tương ứng.
/// Histogram thường được chuẩn hóa.
/// </summary>
internal static class Histogram
{
    /// <summary>
    /// Tính cường độ sáng trung bình của các điểm ảnh trong ma trận
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <returns>Cường độ sáng trung bình</returns>
    public static double GetAverageLuminousIntensity(this int[,] matrix)
    {
        var result = 0d;
        foreach (var index in matrix)
        {
            result += index;
        }
        return result / matrix.Length;
    }   

    /// <summary>
    /// Tính chỉ số tương phản của các điểm ảnh trong ma trận
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <returns>Chỉ số tương phản</returns>
    public static double GetContrastIndex(this int[,] matrix)
    {
        var result = 0d;
        var m = matrix.GetAverageLuminousIntensity();
        var pairs = matrix.GetAppearanceCount();
        foreach (var pair in pairs)
        {
            result += Math.Pow(pair.Key - m, 2) * pair.Value;
        }
        return result / matrix.Length;
    }

    /// <summary>
    /// Tính số lần xuất hiện của các điểm ảnh trong ma trận
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <returns>Các cặp giá trị với điểm ảnh là khoá và số lần xuất hiện là giá trị</returns>
    public static Dictionary<int, int> GetAppearanceCount(this int[,] matrix)
    {
        var dictionary = new Dictionary<int, int>();
        foreach (var index in matrix)
        {
            if (dictionary.ContainsKey(index))
                dictionary[index] += 1;
            else
                dictionary.Add(index, 1);
        }
        return dictionary;
    }

    /// <summary>
    /// Tính giá trị của hàm phân bố tĩch lũy (CDF) cho các điểm ảnh trong ma trận
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <returns>Các cặp giá trị với điểm ảnh là khoá và giá trị của CDF là giá trị</returns>
    public static Dictionary<int, int> GetCdfValues(this int[,] matrix)
    {
        var cdf = 0;
        var cdfValues = new Dictionary<int, int>();
        var dictionary = matrix.GetAppearanceCount();
        foreach (var pair in dictionary)
        {
            cdf += pair.Value;
            cdfValues.Add(pair.Key, cdf);
        }
        return cdfValues;
    }

    /// <summary>
    /// Tính giá trị các điểm ảnh theo mức xám mới
    /// </summary>
    /// <param name="matrix">Ma trận điểm ảnh</param>
    /// <param name="grayLevel">Mức xám mới</param>
    /// <returns>Các cặp giá trị với điểm ảnh cũ là khoá và điểm ảnh mới là giá trị</returns>
    public static Dictionary<int, int> GetPixels(this int[,] matrix, int grayLevel)
    {
        var pixels = new Dictionary<int, int>();
        var appearanceCount = matrix.GetAppearanceCount();
        var cdfValues = new SortedDictionary<int, int>(matrix.GetCdfValues());
        cdfValues.OrderBy(p => p.Key);
        var minCdfValue = cdfValues.FirstOrDefault().Value;
        var currentCdfValue = 0d;
        foreach (var pair in appearanceCount)
        {
            currentCdfValue = (cdfValues[pair.Key] - minCdfValue) / (matrix.Length - minCdfValue);
            pixels.Add(pair.Key, (int)Math.Round(currentCdfValue * (grayLevel - 1)));
        }
        return pixels;
    }
}