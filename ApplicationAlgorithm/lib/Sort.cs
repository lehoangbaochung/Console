namespace lib;

internal static class Sort 
{
    /// <summary>
    /// Bubble sort
    /// </summary>
    /// <param name="array">An integer array</param>
    /// <param name="length">The first n elements of integer array</param>
    public static void BubbleSort(this int[] array, int? length = null)
    {
        if (length == null) length = array.Length;
        var isSwapped = true;
        while (isSwapped)
        {
            isSwapped = false;
            for (var i = 1; i < length.Value; i++)
            {
                if (array[i] < array[i - 1])
                {
                    Swap(ref array[i], ref array[i - 1]);
                    isSwapped = true;
                }
            }
        }
    }

    /// <summary>
    /// Insertion sort
    /// </summary>
    /// <param name="array">An integer array</param>
    /// <param name="length">The first n elements of integer array</param>
    public static void Insertion(ref int[] array, int? length = null) 
    {
        if (length == null) length = array.Length;
        for (var i = 1; i < length.Value; i++)
        {
            var j = i;
            var last = array[i]; 
            while (j > 0 && array[j - 1] > last)
            {
                array[j] = array[j - 1];
                j--;
            }
            array[j] = last;
        }
    }

    /// <summary>
    /// Selection sort
    /// </summary>
    /// <param name="array">An integer array</param>
    /// <param name="length">The first n elements of integer array</param>
    public static void Selection(ref int[] array, int? length = null) 
    {
        if (length == null) length = array.Length;
        for (var k = 0; k < length - 1; k++)
        {
            var m = k;
            for (var i = k + 1; i < length; i++)
                if (array[m] > array[i]) m = i;
            Swap(ref array[k], ref array[m]);
        }
    }

    /// <summary>
    /// Trộn hai dãy con từ startIndex đến endIndex
    /// hoặc từ startIndex đến middleIndex và middleIndex + 1 đến endIndex
    /// </summary>
    /// <param name="array">The integer array</param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <param name="middleIndex"></param> 
    public static void MergeSort(this int[] array, int startIndex, int endIndex, int? middleIndex = null) 
    {
        if (middleIndex == null)
        {
            if (startIndex < endIndex)
            {
                middleIndex = (startIndex + endIndex) / 2;
                array.MergeSort(startIndex, middleIndex.Value);
                array.MergeSort(middleIndex.Value + 1, endIndex);
                array.MergeSort(startIndex, middleIndex.Value, endIndex);
            }
        }
        else 
        {
            var i = startIndex;
            var j = middleIndex.Value + 1;
            var mergeArray = new int[array.Length];
            for (var k = startIndex; k <= endIndex; k++)
            {
                if (i > middleIndex) mergeArray[k] = array[j++];
                else
                {
                    if (j > endIndex) mergeArray[k] = array[i++];
                    else
                    {
                        if (array[i] < array[j]) mergeArray[k] = array[i++];
                        else mergeArray[k] = array[j++];
                    }
                }
            }
            for (int k = startIndex; k <= endIndex; k++) array[k] = mergeArray[k];
        } 
    }

    /// <summary>
    /// Sắp xếp nhanh dãy số từ startIndex đến endIndex
    /// </summary>
    /// <param name="array"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    public static void QuickSort(this int[] array, int startIndex, int endIndex) 
    {
        if (startIndex < endIndex)
        {
            var middleIndex = Partition(ref array, startIndex, endIndex);
            array.QuickSort(startIndex, middleIndex - 1);
            array.QuickSort(middleIndex + 1, endIndex);
        }
    }

    /// <summary>
    /// Sắp xếp vun đống: n phần tử của array tính từ array[1]
    /// </summary>
    /// <param name="array">Mảng số nguyên</param>
    /// <param name="number">Số phần tử của mảng</param>
    public static void Heap(ref int[] array, int number)
    {
        BuildHeap(ref array, number);
        for (var i = number; i > 1; i--)
        {
            Swap(ref array[1], ref array[i]);
            Heapify(ref array, 1, i - 1);
        }
    }

    /// <summary>
    /// Swap two numbers without third variable
    /// </summary>
    /// <param name="a">The first number</param>
    /// <param name="b">The second number</param>
    private static void Swap(ref int a, ref int b) 
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    /// <summary>
    /// Phân hoạch mảng làm hai
    /// </summary>
    /// <param name="array">Mảng số nguyên</param>
    /// <param name="startIndex">Vị trí bắt đầu</param>
    /// <param name="endIndex">Vị trí kết thúc</param>
    /// <returns></returns>
    private static int Partition(ref int[] array, int startIndex, int endIndex) 
    {
        var middleIndex = (startIndex + endIndex) / 2;
        var pivot = array[middleIndex];
        Swap(ref array[middleIndex], ref array[endIndex]);
        var store = startIndex;
        for (int i = startIndex; i <= endIndex - 1; i++)
            if (array[i] < pivot)
            {
                Swap(ref array[store], ref array[i]);
                store++;
            }
        Swap(ref array[store], ref array[endIndex]);
        return store;
    }

    /// <summary>
    /// Chinh lai heap do loi cua phan tu i, heap toi da n phan tu
    /// </summary>
    /// <param name="array">Mảng số nguyên</param>
    /// <param name="index"></param>
    /// <param name="number">Số lượng phần tử</param>
    private static void Heapify(ref int[] array, int index, int number)
    {
        var startIndex = index * 2;
        var endIndex = index * 2 + 1;
        var middleIndex = index;
        if (startIndex <= number && array[startIndex] > array[middleIndex]) middleIndex = startIndex;
        if (endIndex <= number && array[endIndex] > array[middleIndex]) middleIndex = endIndex;
        if (middleIndex != index)
        {
            Swap(ref array[index], ref array[middleIndex]);
            Heapify(ref array, middleIndex, number);
        }
    }

    /// <summary>
    /// Tao một đống từ vị trí 1 đến vị trí kết thúc của một mảng
    /// </summary>
    /// <param name="array">Mảng số nguyên</param>
    /// <param name="endIndex">Vị trí kết thúc</param>
    private static void BuildHeap(ref int[] array, int endIndex)
    {
        for (var i = endIndex / 2; i >= 1; i--) Heapify(ref array, i, endIndex);
    }
}