internal class Vigenere
{
    public static string Encode(string plainText, string key)
    {
        var cipherText = string.Empty;
        for (var i = 0; i < plainText.Length; i++)
        {
            cipherText += (plainText[i].ToInt32()
                + key[i % key.Length].ToInt32()).ToChar();
        }
        return cipherText;
    }

    public static string Decode(string cipherText, string key)
    {
        var plainText = string.Empty;
        for (var i = 0; i < cipherText.Length; i++)
        {
            plainText += (cipherText[i].ToInt32()
                - key[i % key.Length].ToInt32()).ToChar();
        }
        return plainText;
    }

    public static bool IsCaesar(string key)
    {
        var firstCharacter = key[0].ToInt32();
        for (var i = 0; i < key.Length; i++)
        {
            if (firstCharacter != key[i].ToInt32())
                return false;
        }
        return true;
    }

    public static void Display()
    {
        var key = "CIPHER";
        var plainText = "WEWILLMEETATMIDNIGHT";
        var cipherText = Encode(plainText, key);
        Console.WriteLine("Chuoi ma hoa: " + cipherText);
        Console.WriteLine("Chuoi giai ma: " + Decode(cipherText, key));
    }
}
