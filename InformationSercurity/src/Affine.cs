internal class Affine
{
    public static string Encode(string plainText, int a, int b)
    {
        CheckKey(a, b);

        if (a == 1) return Caesar.Encode(plainText, b);

        var cipherText = string.Empty;
        foreach (var character in plainText)
        {
            var index = character.ToInt32();
            index = (index * a + b) % 26;
            cipherText += index.ToChar();
        }
        return cipherText;
    }

    public static string[,] Decode(string cipherText)
    {
        var plainTexts = new string[12, 26];
        for (int i = 0; i < plainTexts.GetLength(0); i++)
        {
            for (int j = 0; j < plainTexts.GetLength(1); j++)
            {
                var plainText = string.Empty;
                foreach (var character in cipherText)
                {
                    var index = character.ToInt32();
                    index = GetPointer(i) * (index - j + 26) % 26;
                    plainText += index.ToChar();
                }
                plainTexts[i, j] = plainText;
            }
        }
        return plainTexts;
    }

    private static void CheckKey(int a, int? b = null)
    {
        if (a % 2 == 0 || a == 13 || a < 1 || a > 25)
        {
            throw new Exception($"The number {a} is not valid");
        }

        if (!b.HasValue) return;

        if (b < 0 || b > 25)
        {
            throw new Exception($"The number {b} is not valid");
        }
    }

    private static int GetPointer(int a)
    {
        CheckKey(a);
        return a;
    }
}
