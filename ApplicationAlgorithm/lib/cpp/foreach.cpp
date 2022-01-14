#include <iostream>
#include <stdlib.h>
#include <ctime>
using namespace std;
const int n = 5000000;
int a[n], m;

// ba vong for long nhau
void cach1()
{
    m = a[0];
    for (int dau = 0; dau < n; dau++)
        for (int cuoi = dau; cuoi < n; cuoi++)
        {
            // tinh tong doan a[dau]=>a[cuoi]
            int t = 0;
            for (int k = dau; k <= cuoi; k++)
                t = t + a[k];
            // ghi nhan tong lon nhat neu co
            if (t > m)
                m = t;
        }
}

// hai vong for
void cach2()
{
    m = a[0];
    for (int dau = 0; dau < n; dau++)
    {
        int t = 0;
        for (int cuoi = dau; cuoi < n; cuoi++)
        {
            // tinh tong doan a[dau]=>a[cuoi]
            t = t + a[cuoi];
            // ghi nhan tong lon nhat neu co
            if (t > m)
                m = t;
        }
    }
}

int trai(int dau, int giua)
{
    int m = a[giua], s = 0;
    for (int i = giua; i >= dau; i--)
    {
        s = s + a[i];
        if (s > m)
            m = s;
    }
    return m;
}

int phai(int giua, int cuoi)
{
    int m = a[giua], s = 0;
    for (int i = giua; i <= cuoi; i++)
    {
        s = s + a[i];
        if (s > m)
            m = s;
    }
    return m;
}

int timmax(int dau, int cuoi)
{
    if (dau == cuoi)
        return a[dau];
    int giua = (dau + cuoi) / 2;
    int max_s1 = timmax(dau, giua);
    int max_s2 = timmax(giua + 1, cuoi);
    int max_s0 = trai(dau, giua) + phai(giua + 1, cuoi);

    return max(max_s0, max(max_s1, max_s2));
}

void cach3()
{
    m = timmax(0, n - 1);
}

void cach4()
{
    int w0 = a[0];
    m = w0;
    for (int i = 1; i < n; i++)
    {
        int w1 = max(a[i], a[i] + w0);
        if (w1 > m)
            m = w1;
        w0 = w1;
    }
}

void khoitao()
{
    for (int i = 0; i < n; i++)
        a[i] = rand() % 100 - 50;
}

int main()
{
    khoitao();
    /*
    clock_t begin = clock();
    cach1();
    clock_t end = clock();
    cout << "Tong lon nhat la " << m << endl;
    cout << "Thoi gian thuc hien thuat toan: " << double(end - begin) / CLOCKS_PER_SEC << endl;

    clock_t begin = clock();
    cach2();
    clock_t end = clock();
    cout << "Tong lon nhat la " << m << endl;
    cout << "Thoi gian thuc hien thuat toan: " << double(end - begin) / CLOCKS_PER_SEC << endl;
    */
    clock_t begin = clock();
    cach3();
    clock_t end = clock();
    cout << "Tong lon nhat la " << m << endl;
    cout << "Thoi gian thuc hien thuat toan: " << double(end - begin) / CLOCKS_PER_SEC << endl;

    begin = clock();
    cach4();
    end = clock();
    cout << "Tong lon nhat la " << m << endl;
    cout << "Thoi gian thuc hien thuat toan: " << double(end - begin) / CLOCKS_PER_SEC << endl;
}