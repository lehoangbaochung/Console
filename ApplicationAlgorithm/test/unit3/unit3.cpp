#include <iostream>

using namespace std;

// Đếm số dãy con có tổng cho trước
int function(int a[], int m, int n) 
{
    if (n == 0)
        return m == 0 ? 1 : 0;
    else
        return function(a, m, n - 1) + function(a, m - a[n], n - 1);
}

int main()
{
    int m, n;
    cout << "Nhap m = ";
    cin >> m;
    cout << "Nhap n = ";
    cin >> n;
    int a[n];
    for (int i = 1; i <= n; i++)
    {
        cout << "a[" << i - 1 << "] = ";
        cin >> a[i];
    }
    cout << "Co tat ca " << function(a, m, n) << " cach phan tich.";
}
