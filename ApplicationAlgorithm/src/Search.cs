using lib;
namespace src;

internal class Search
{
    /// <summary>
    /// Solve a cubic equation with coefficients and a constant
    /// </summary>
    /// <param name="a">The first coefficient</param>
    /// <param name="b">The second coefficient</param>
    /// <param name="c">The third coefficient</param>
    /// <param name="d">The constant</param>
    /// <returns>The root(s) of cube equation</returns>
    /// <exception cref="Exception">Cannot solve the cubic equation</exception>
    public static double[] Unit1(double a, double b, double c, double d)
    {
        if (a == 0)
        {
            throw new Exception("Invalid cube equation");
        }
        var delta = b * b - 3 * a * c;
        if (delta == 0)
        {
            var deltaPlus = b * b * b - 27 * a * a * d;
            if (deltaPlus == 0)
            {
                return new double[] { -b / (3 * a) };
            }
            else
            {
                return new double[] { (-b + Utils.Sqrt(deltaPlus, 3)) / (3 * b) };
            }
        }
        var k = (9 * a * b * c - 2 * b * b * b - 27 * a * a * d) /
                2 * Utils.Sqrt(Math.Abs(delta) * Math.Abs(delta) * Math.Abs(delta));
        if (delta > 0)
        {
            var deltaSqrt = Utils.Sqrt(delta);
            if (Math.Abs(k) > 1)
            {
                var p1 = (Utils.Sqrt(Math.Abs(k)) * deltaSqrt) / (3 * a * k);
                var p2 = Utils.Sqrt(Math.Abs(k) + Utils.Sqrt(k * k - 1), 3);
                var p3 = Utils.Sqrt(Math.Abs(k) - Utils.Sqrt(k * k - 1), 3);
                var p4 = b / (3 * a);
                return new double[] { p1 * (p2 + p3) - p4 };
            }
            else
            {
                var x1 = (2 * deltaSqrt * Math.Cos(Math.Cosh(k) / 3) - b) / (3 * a);
                var x2 = (2 * deltaSqrt * Math.Cos((Math.Cosh(k) - 2 * Math.PI) / 3) - b) / (3 * a);
                var x3 = (2 * deltaSqrt * Math.Cos((Math.Cosh(k) + 2 * Math.PI) / 3) - b) / (3 * a);
                return new double[] { x1, x2, x3 };
            }
        }
        else
        {
            var p1 = Utils.Sqrt(Math.Abs(delta)) / (3 * a);
            var p2 = Utils.Sqrt(k + Utils.Sqrt(k * k + 1), 3);
            var p3 = Utils.Sqrt(k - Utils.Sqrt(k * k + 1), 3);
            var p4 = b / (3 * a);
            return new double[] { p1 * (p2 + p3) - p4 };
        }
        throw new Exception("Cannot solve the cubic equation");
    }

    /// <summary>
    /// Đếm xem có bao nhiêu cặp số trong dãy số A chênh lệch nhau đúng k đơn vị
    /// </summary>
    /// <param name="array">Dãy số A</param>
    /// <param name="k">Đơn vị k</param>
    /// <returns>Số lượng cặp số</returns>
    public static int Unit2(int[] array, int k)
    {
        if (array.Length < 2) return 0;
        var count = 0;
        foreach (var item in array) 
        {
            if (array.LinearSearch(item - k) != -1) count++;
            if (array.LinearSearch(item + k) != -1) count++;
        }
        return count / 2;
    }
}