namespace lib;

internal static class Search
{
    public static int LinearSearch(this int[] array, int number)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == number) return i;
        }
        return -1;
    }

    public static int BinarySearchByRecursion(this int[] array, int left, int right, int number)
    {
        if (right < left) return -1;
        int middle = left + (right - left) / 2;
        if (array[middle] == number) return middle;
        if (array[middle] > number) return array.BinarySearchByRecursion(left, middle - 1, number);
        return array.BinarySearchByRecursion(middle + 1, right, number);
    }

    public static int BinarySearchByLoop(this int[] array, int left, int right, int number)
    {
        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            if (array[middle] == number) return middle;
            if (array[middle] > number) left = middle + 1;
            else right = middle - 1;
        }
        return -1;
    }

    public static int InterpolationSearch(this int[] array, int left, int right, int number)
    {
        while (left <= right)
        {
            int middle = left + (number - array[left]) * ((right - left) / (array[right] - array[left]));
            if (array[middle] == number) return middle;
            if (array[middle] > number) left = middle + 1;
            else right = middle - 1;
        }
        return -1;
    }

    public static int LowerBoundSearch(this int[] array, int number)
    {
        var result = array.BinarySearchByLoop(array.Length / 2, array.Length / 2, number);
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] >= result) return i;
        }
        return -1;
    }

    public static int UpperBoundSearch(this int[] array, int number)
    {
        var result = array.BinarySearchByLoop(array.Length / 2, array.Length / 2, number);
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] > result) return i;
        }
        return -1;
    }
}