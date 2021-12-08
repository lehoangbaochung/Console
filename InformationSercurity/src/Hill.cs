/// <summary>
/// Mật mã <see cref="Hill"/> sẽ thay thế từng nhóm m kí tự trong bản rõ bởi m kí tự bản mã
/// </summary>
internal class Hill
{
    public static string Encode(string plainText, int[] key)
    {
        var cipherText = string.Empty;
        var rank = (int)Math.Sqrt(key.Length);
        for (var i = 0; i < plainText.Length; i += rank)
        {
            var c = 0;
            var index = i + i % rank;
            for (var j = 0; j < rank; j++)
            {

            }
            c += plainText[index].ToInt32() * key[index];
        }
        return cipherText;
    }
}