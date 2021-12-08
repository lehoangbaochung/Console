namespace lib;

internal static class Utils 
{
    public static double Sqrt(this double d, int i = 2) => Math.Ceiling(Math.Pow(d, (double)1 / i));
}
