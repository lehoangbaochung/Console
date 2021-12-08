namespace lib;

internal class Recursion
{
    public static void Print(int n)
    {
        if (n > 1) Print(n - 1);
        Console.Write(n);
    }

    public static int Combination(int k, int n)
    {
        if (k == n || k == 0) return 1;
        return Combination(k - 1, n - 1) + Combination(k, n - 1);
    }

    public static int Permutation(int k, int n)
    {
        return 1;
    }

    public static int Fibonacci(int n) 
    {
        if (n < 2) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}