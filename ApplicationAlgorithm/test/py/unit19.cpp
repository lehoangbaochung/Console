#include <iostream>

using namespace std;

int n, tong = 0, dem = 0;

void solve(int k, int p){
    tong = 2 * k + 3 * p;
    if (tong>n)
        return;
    else if (tong == n)
    {
        dem++;
    } else {
        solve(k + 1, p);
        solve(k, p + 1);
    }
}

int main()
{
    cout << "";
    cin >> n;
    solve(0, 0);
    cout << dem;
}