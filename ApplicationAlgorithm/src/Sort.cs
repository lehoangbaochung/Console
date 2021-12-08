namespace src;
using lib;

internal class Sort
{
    /// <summary>
    /// Tìm các cặp phần tử có độ chênh lệch giữa chúng là nhỏ nhất trong dãy số A,
    /// nếu có nhiều cặp như vậy thì in ra tất cả
    /// </summary>
    /// <param name="array">Dãy số nguyên A</param>
    /// <returns>Các cặp phần tử gần nhau nhất trong dãy</returns>
    public static List<(int, int)> Unit1(int[] array) 
    {
        array.BubbleSort();
        var resultPairs = new List<(int, int)>();
        var minDiffValue = Math.Abs(array[array.Length - 1] - array[0]);
        for (var i = 1; i < array.Length; i++) 
        {
            var diffValue = Math.Abs(array[i] - array[i - 1]);
            if (diffValue < minDiffValue) minDiffValue = diffValue;
        }
        for (var i = 1; i < array.Length; i++)
        {
            var diffValue = Math.Abs(array[i] - array[i - 1]);
            if (diffValue == minDiffValue) resultPairs.Add(new(array[i], array[i - 1]));
        }
        if (Math.Abs(array[0] - array[array.Length - 1]) == minDiffValue)
            resultPairs.Add(new(array[0], array[array.Length - 1]));
        return resultPairs;
    }

    /// <summary>
    /// Chọn ra k số nguyên trong dãy số A tạo thành dãy số B 
    /// sao cho chênh lệch giữa số lớn nhất và số nhỏ nhất trong B là tối thiểu
    /// </summary>
    /// <param name="array">Dãy số nguyên A</param>
    /// <param name="k">Số nguyên dương k</param>
    /// <returns>Độ chênh lệch giữa số lớn nhất và số nhỏ nhất</returns>
    /// <exception cref="Exception">k lớn hơn số lượng phần tử của mảng A</exception>
    public static int Unit2(int[] array, int k)
    {
        if (array.Length < k) throw new Exception("Out of bound");
        array.BubbleSort(); 
        return array[k - 1] - array[0];
    }

    public static void Run()
    {
        Console.WriteLine("Bai 1: ");
        {
            var array = new int[] { -20, 737481, -73301, 30, -61594, 26854, -520, -470 };
            var resultPairs = Unit1(array);
            foreach (var resultPair in resultPairs)
                Console.WriteLine($"({ resultPair.Item1 }, { resultPair.Item2 })");
        }
        Console.WriteLine("Bai 2: ");
        {
            var array = new int[] { 2, 4, 6, 8, 10, 12, 13, 14, 15 }; // B = 12, 13, 14, 15
            Console.WriteLine(Unit2(array, 4)); // in ra 1
        }
    }
}
