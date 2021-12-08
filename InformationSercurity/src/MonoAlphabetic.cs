internal class MonoAlphabetic
{
    public static string Encrypt(string plainText, string key)
    {
        if (key.Length != 26)
        {
            throw new Exception("The length of key is not valid");
        }
        var cipherText = string.Empty;
        for (var i = 0; i < plainText.Length; i++)
        {
            var index = plainText.IndexOf(plainText[i]);
            cipherText += key[index];
        }
        return cipherText;
    }

    public static string Decrypt(string cipherText, string key)
    {
        return string.Empty;
    }

    private static void FillAlphabetCharacter(ref string plainText)
    {
        var alphabet = Enum.GetNames(typeof(Alphabet));
        for (var i = 0; i < plainText.Length; i++)
        {
            for (var j = 0; j < alphabet.Length; j++)
            {
                if (plainText[i].Equals(alphabet[j]))
                {
                    plainText += alphabet[j];
                }
            }
        }
    }

    public static int GetAppearanceCount(string text, char c)
    {
        int count = 0;
        foreach (var character in text)
        {
            if (character.Equals(c)) count++;
        }
        return count;
    }

    public static int GetAppearanceFrequency(string text, char c)
    {
        return GetAppearanceCount(text, c) / text.Length * 100;
    }

    private static string RemoveDuplicates(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (input[j].Equals(input[i]))
                {
                    input = input.Replace(input[j].ToString(), "");
                    j--;
                }
            }
        }
        return input.Length > 0 ? input : new string(input.ToCharArray().Distinct().ToArray());
    }

    public static void Display(string plainText = "abbcd",
        string key = "asdfghjklzxcvbnmqwertyuiop")
    {
        var cipherText = Encrypt(plainText, key);
        Console.WriteLine(Extension.KEY_TEXT + key);
        Console.WriteLine(Extension.PLAIN_TEXT + plainText);
        Console.WriteLine(Extension.ENCRYPT_TEXT + cipherText);
        Console.WriteLine(Extension.DECRYPT_TEXT + Decrypt(cipherText, key));
    }
}