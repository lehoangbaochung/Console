/// <summary>
/// <see cref="RSA"/> là một thuật toán mã hoá khối, 
/// mỗi khối là một dãy bít nhị phân ứng với một số nguyên trong khoảng từ 0 đến n – 1. 
/// Kích thước điển hình của n là 1024 bit, hay 309 chữ số thập phân, tức là n < 2^1024. 
/// </summary>
internal class RSA
{
    private readonly int plainNumber, n, m;
    private int a, b, cipherNumber;

    public RSA(int plainNumber, int p, int q)
    {
        this.plainNumber = plainNumber;
        n = p * q;
        m = (p - 1) * (q - 1);
    }

    public (int, int) GetEncryptKey()
    {
        return (a, n);
    }

    public (int, int) GetDecryptKey()
    {
        return (b, n);
    }

    public int Encrypt()
    {
        // Tính a sao cho USCLN (m,a) = 1 và a < m
        for (var i = 2; i < m; i++)
        {
            var gcd = Extension.FindGreatestCommonDivisor(m, i);
            if (gcd == 1)
            {
                a = i;
                break;
            }
        }
        // Tính C = P^a mod n
        cipherNumber = (int)(Math.Pow(plainNumber, a) % n);
        return cipherNumber;
    }

    public int Decrypt()
    {
        // Tính b sao cho a.b mod m = 1 và b < m
        for (var i = 1; i < m; i++)
        {
            if (a * b % m == 1)
            {
                b = i;
                break;
            }
        }
        // Tính P = C^b mod n 
        return (int)(Math.Pow(cipherNumber, b) % n);
    }
}

