internal static class Extension
{
    public const string KEY_TEXT = "Khoa: ";
    public const string PLAIN_TEXT = "Chuoi ban dau: ";
    public const string ENCRYPT_TEXT = "Chuoi ma hoa: ";
    public const string DECRYPT_TEXT = "Chuoi giai ma: ";

    private const int ALPHABET_CHARACTER_COUNT = 26;
    private const char ALPHABET_FIRST_CHARACTER = 'A';

    public static int ToInt32(this char c)
    {
        return char.ToUpper(c) - ALPHABET_FIRST_CHARACTER;
    }

    public static char ToChar(this int i)
    {
        return (char)((i + ALPHABET_CHARACTER_COUNT)
            % ALPHABET_CHARACTER_COUNT + ALPHABET_FIRST_CHARACTER);
    }

    public static string ToBinary(this char c)
    {
        // 2: Binary code
        // 8: The length of result
        return Convert.ToString(c, 2).PadLeft(8, '0');
    }

    public static string ToBinary(this string s)
    {
        var r = string.Empty;
        foreach (var c in s)
        {
            r += Convert.ToString(c, 2).PadLeft(8, '0') + " ";
        }
        return r;
    }

    public static int FindGreatestCommonDivisor(int a, int b)
    {
        var result = 0;
        var j = (a < b) ? a : b;
        for (var i = 1; i <= j; i++)
        {
            if (a % i == 0 && b % i == 0)
            {
                result = i;
            }
        }
        return result;
    }
}
