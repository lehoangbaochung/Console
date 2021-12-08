/// <summary>
/// Mật mã khoá công khai giúp hàm <see cref="Hash"/> bảo vệ và xác thực thông điệp nhận được
/// Công thức (b): M || E(K, H(M))
/// a) Bảo mật thông điệp và xác thực nội dung
/// b) Chỉ bảo mật hàm Hash và xác thực nội dung (nhưng tốc độ truyền nhanh hơn vì không cần mã hoá M)
/// d) Có khả năng xác thực nguồn gốc M, bảo mật cho thông điệp nhờ mã hoá thông điệp trước khi gửi dữ liệu
/// </summary>
internal class Hash
{
    public static char GetCode(string text, int bit = 8, char customCharacter = 'X')
    {
        var hashCode = '0';
        var hashCharacters = new char[bit];
        for (var i = 0; i < hashCharacters.Length; i++) 
            hashCharacters[i] = customCharacter;
        while (text.Length % bit != 0) 
            text += customCharacter;
        for (var i = 0; i < text.Length / 8; i++)
            for (var j = 0; j < 8; j++) 
                hashCharacters[j] ^= text[i * 8 + j];
        foreach (var character in hashCharacters) 
            hashCode += character;
        return hashCode;
    }
}