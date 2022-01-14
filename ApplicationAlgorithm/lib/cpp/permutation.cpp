#include <iostream>
using namespace std;

const int MAX = 100;
int a[MAX], n;
bool b[MAX]; // mảng đánh dấu, true nghĩa là chưa dùng

// in cấu hình A
void print(int n)
{
    for (int i = 1; i <= n; i++)
        cout << a[i];
    cout << endl;
}

// sinh phần tử thứ k
void gen(int k)
{
    // nếu đã sinh được n phần tử thì in ra và thoát
    if (k > n)
    {
        print(n);
        return;
    }
    // chọn giá trị cho a[k]
    for (int i = 1; i <= n; i++)
        if (b[i])
        {                 // nếu chưa đánh dấu
            b[i] = false; // đánh dấu
            a[k] = i;
            gen(k + 1);  // chọn giá trị và sinh tiếp
            b[i] = true; // bỏ đánh dấu
        }
}

int main()
{
    n = 4;
    for (int i = 1; i <= n; i++)
        b[i] = true;
    gen(1);
}