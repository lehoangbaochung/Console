internal class Caesar
{
    private const int MAX_KEY_COUNT = 26;

    public static string Encode(string plainText, int key = 3)
    {
        var cipherText = string.Empty;
        foreach (var character in plainText)
        {
            var index = character.ToInt32();
            index = (index + key) % MAX_KEY_COUNT;
            cipherText += index.ToChar();
        }
        return cipherText;
    }

    public static string[] Decode(string cipherText)
    {
        var plainTexts = new string[MAX_KEY_COUNT];
        for (int i = 0; i < plainTexts.Length; i++)
        {
            var plainText = string.Empty;
            foreach (var character in cipherText)
            {
                var index = character.ToInt32();
                index = (index - i + MAX_KEY_COUNT) % MAX_KEY_COUNT;
                plainText += index.ToChar();
            }
            plainTexts[i] = plainText;
        }
        return plainTexts;
    }
}
