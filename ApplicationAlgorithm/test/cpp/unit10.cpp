#include <iostream>
using namespace std;
const int MAX = 1000;
int m, a[MAX], c[MAX][MAX], b[MAX], n;
int main()
{
    cout << "Nhap m = ";
    cin >> m;
    for (int h = 1; h <= m; h++)
    {
        cout << "a[" << h << "] = ";
        cin >> a[h];
    }
    cout << "Nhap n = ";
    cin >> n;
    for (int h = 1; h <= n; h++)
    {
        cout << "b[" << h << "] = ";
        cin >> b[h];
    }
    for (int h = 0; h <= m; h++)
    {
        for (int k = 0; k <= n; k++)
        {
            if (h == 0 || k == 0)
                c[h][k] = 0;
            else if (a[h] == b[k])
                c[h][k] = c[h - 1][k - 1] + a[h];
            else
                c[h][k] = max(c[h - 1][k], c[h][k - 1]);
        }
    }
    cout << "Day con co tong lon nhat = " << c[m][n];
}