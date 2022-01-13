#include <iostream>

using namespace std;

const int MAX = 5;
int c[MAX] = {100, 25, 10, 5, 1};
int a[MAX], n;

int main()
{
    cout << "N = ";
    cin >> n;
    for (int i = 0; i < MAX; i++)
    {
        a[i] = n / c[i];
        cout << "So xu " << c[i] << ": " << a[i] << endl;
        n = n - c[i] * a[i];
    }
}
