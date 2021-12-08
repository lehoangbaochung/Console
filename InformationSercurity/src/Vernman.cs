/// <summary>
/// Mật mã Vernman được phát minh bởi kỹ sư Gilbert Vernman của AT&T vào năm năm 1918.
/// Hệ thống này làm việc trên dữ liệu nhị phân chứ không phải các ký tự. 
/// Plaintext được biểu diễn dưới dạng một chuỗi bit nhị phân.
/// Khoá K cũng được biểu diễn dưới dạng một chuỗi bit nhị phân.
/// Khoá K càng dài và càng ngẫu nhiên thì càng tốt.
/// </summary>
internal class Vernman
{
    /// <summary>
    /// Ciphertext được sinh ra bởi phép XOR giữa plaintext với khóa K
    /// </summary>
    /// <param name="plainText">Bản rõ</param>
    /// <param name="key">Khoá K</param>
    /// <returns>Bản mã</returns>
    public static string Encode(string plainText, string key)
    {
        var cipherText = string.Empty;
        for (var i = 0; i < plainText.Length; i++)
        {
            cipherText += (char)(plainText[i] ^ key[i]);
        }
        return cipherText;
    }

    public static string Decode(string cipherText, string key)
    {
        var plainText = string.Empty;
        for (var i = 0; i < cipherText.Length; i++)
        {
            plainText += (char)(cipherText[i] ^ key[i]);
        }
        return plainText;
    }

    public static string FetchKey(string plainText, string key)
    {
        var j = 0;
        while (key.Length < plainText.Length)
        {
            key += key[j];
            j++;
        }
        return key;
    }

    public static void Display(string plainText = "Cong nghe thong tin", string key = "cntt")
    {
        var newKey = FetchKey(plainText, key);
        var cipherText = Encode(plainText, newKey);
        Console.WriteLine(Extension.ENCRYPT_TEXT + cipherText);
        Console.WriteLine(Extension.DECRYPT_TEXT + Decode(cipherText, newKey));
    }
}
