internal class RainFence
{
    /// <summary>
    /// Plaintext được viết dịch xuống tuần tự theo các đường chéo rồi đọc trình tự theo các hàng
    /// </summary>
    /// <param name="plainText">Bản rõ cần được mã hoá</param>
    /// <param name="rowCount">Số hàng dịch xuống</param>
    /// <returns>Một chuỗi ký tự đã được mã hoá</returns>
    public static string Encode(string plainText, int rowCount, int? columnCount = null)
    {
        var cipherText = string.Empty;
        if (columnCount.HasValue)
        {
            var matrix = new string[rowCount, columnCount.Value];
            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount.Value; j++)
                {
                    matrix[i, j] += plainText[j];
                }
            }
            for (var i = 0; i < columnCount.Value; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    cipherText += matrix[j, i];
                }
            }
        }
        else
        {
            var rows = new string[rowCount];
            for (var i = 0; i < plainText.Length; i++)
            {
                rows[i % rowCount] += plainText[i];
            }
            foreach (var row in rows)
            {
                cipherText += row;
            }
        }
        return cipherText;
    }

    public static string Decode(string cipherText, int rowCount)
    {
        var plainText = string.Empty;
        for (var i = 0; i < cipherText.Length; i++)
        {

        }
        return plainText;
    }

    public static void Display(string plainText = "meetmeafterthetogaparty",
        int rowCount = 2, int? columnCount = null)
    {
        var cipherText = Encode(plainText, rowCount, columnCount);
        Console.WriteLine(Extension.ENCRYPT_TEXT + cipherText);
        Console.WriteLine(Extension.DECRYPT_TEXT + Decode(cipherText, rowCount));
    }
}

