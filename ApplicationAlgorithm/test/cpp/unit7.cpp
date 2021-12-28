#include <iostream>

using namespace std;

// Phân tích số n thành tổng của đúng m số nguyên dương
void function(int n, int m)
{
    if (n < m)
        return;
    else
    {
        int a[m];
        int j = 1;
        for (int i = 0; i < n; i++)
        {
            a[i] = j;
            a[i + 1] = m - j;
        }
        while (n - m >= m - 1)
        {
            cout << "";
            for (int i = 0; i < n; i++)
            {
                cout << a[i] << "+";
            }
        }
        
    }
}

int main()
{
    int n, m;
    cout << "Nhap n = ";
    cin >> n;
    cout << "Nhap m = ";
    cin >> m;
    function(n, m);
}